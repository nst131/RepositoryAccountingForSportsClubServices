using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.CustomAttributes;
using ServiceAccountingUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.AttributeValidation;

namespace ServiceAccountingUI.Redis
{
    public class RedisAddOrUpdateElement<Response, Crud> : IRedisAddOrUpdateElement<Response, Crud>
        where Response : class, IRedisResponse
        where Crud : class
    {
        private readonly IDistributedCache distributedCache;
        private readonly IConfiguration configuration;
        private readonly ILogger<RedisGetElements<Response, Crud>> logger;
        private readonly Crud crud;

        public delegate ICollection<Response> CrudOperationOverRedis(ICollection<Response> allElements, Response element);
        public delegate Task<Response> CrudOperationOverDb<in Accept>(Accept accept, Crud crud, CancellationToken token)
            where Accept : class;

        public RedisAddOrUpdateElement(IConfiguration configuration,
            ILogger<RedisGetElements<Response, Crud>> logger,
            IDistributedCache distributedCache,
            Crud crud)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.distributedCache = distributedCache;
            this.crud = crud;
        }

        public async Task<Response?> TryChangeRedisComponentsAsync<Accept>(
            Accept acceptElement,
            CrudOperationOverDb<Accept> crudOperationOverDb,
            CancellationToken token) where Accept : class
        {
            if (acceptElement is null)
                throw new ElementNullReferenceException();

            var result = await crudOperationOverDb(acceptElement, crud, token);

            try
            {
                var attributesTegs = typeof(Crud).GetCustomAttributes(false);
                string teg = "";

                foreach (var attr in attributesTegs)
                {
                    if (attr is TegForRedis attribute)
                    {
                        teg = attribute.GetKeyTeg;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(teg))
                    throw new ElementNullReferenceException("Do not assign teg for redis name");

                var allElementsBytesInRedis = await distributedCache.GetAsync(teg, token);

                if (allElementsBytesInRedis is not null)
                {
                    var attributesOperations = crudOperationOverDb.Method.GetCustomAttributes(false);

                    foreach (var attr in attributesOperations)
                    {
                        if (attr is ViewOperation attribute)
                        {
                            CrudOperationOverRedis action = attribute switch
                            {
                                { GetOperation: Operation.Create } => AddElemenInRedis,
                                { GetOperation: Operation.Update } => UpdateElementInRedis,
                                { GetOperation: Operation.Delete } => DeleteElementInRedis,
                                _ => throw new Exception("Do not attach attribute On Operation")
                            };
#pragma warning disable 4014
                            this.ChangeRedisComponentsAsync(allElementsBytesInRedis, teg, result, action, token);
#pragma warning restore 4014

                            break;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                logger.LogError($"Redis Server is not valid {exc.Message} Stack Trace {exc.StackTrace}");
            }

            return result;
        }

        private async Task ChangeRedisComponentsAsync(
            byte[] elementsInRedis,
            string teg,
            Response elementToAddInRedis,
            CrudOperationOverRedis crudOperationOverRedis,
            CancellationToken token)
        {
            var newAllElementsInRedis = await Task.Factory.StartNew(() =>
            {
                var serializedElementsInRedis = Encoding.UTF8.GetString(elementsInRedis);
                var allElementsInRedis = JsonConvert.DeserializeObject<ICollection<Response>>(serializedElementsInRedis);
                return crudOperationOverRedis(allElementsInRedis, elementToAddInRedis);
            }, token);

            await WriteElementsInRedis(newAllElementsInRedis, teg, token);
        }

        private static ICollection<Response> DeleteElementInRedis(ICollection<Response> allElementsInRedis, Response elementToDeleteInRedis)
        {
            var list = allElementsInRedis.ToList();
            list.RemoveAll(x => x.Id == elementToDeleteInRedis.Id);
            return list;
        }

        private static ICollection<Response> AddElemenInRedis(ICollection<Response> allElementsInRedis, Response elementToAddInRedis)
        {
            allElementsInRedis.Add(elementToAddInRedis);
            return allElementsInRedis;
        }

        private static ICollection<Response> UpdateElementInRedis(ICollection<Response> allElementsInRedis, Response elementToUpdateInRedis)
        {
            var list = allElementsInRedis.ToList();
            list.RemoveAll(x => x.Id == elementToUpdateInRedis.Id);
            list.Add(elementToUpdateInRedis);
            return list;
        }

        private async Task WriteElementsInRedis(ICollection<Response> elements, string teg, CancellationToken token)
        {
            var obj = await Task.Factory.StartNew(() =>
            {
                var serealizedSubscription = JsonConvert.SerializeObject(elements);
                var option = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(int.Parse(configuration["Redis:AbsoluteExpiration"])))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(int.Parse(configuration["Redis:SlidingExpiration"])));
                return new { serealizedSubscription, option };
            }, token);

            await distributedCache.SetAsync(teg, Encoding.UTF8.GetBytes(obj.serealizedSubscription), obj.option, token);
        }
    }
}
