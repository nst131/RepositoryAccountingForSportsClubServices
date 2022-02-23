using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedisLibrary.Attributes;
using RedisLibrary.Models;

namespace RedisLibrary
{
    public class ModifierElementsInRedis<Response, Crud> : IModifierElementsInRedis<Response, Crud>
        where Response : class, IRedisResponse
        where Crud : class
    {
        private readonly IDistributedCache distributedCache;
        private readonly ILogger<RedisGetElements<Response, Crud>> logger;
        private readonly Crud crud;
        private readonly DistributedCacheEntryOptions options;

        public delegate ICollection<Response> CrudOperationOverRedis(ICollection<Response> allElements, Response element);
        public delegate Task<Response> CrudOperationOverDb<in Accept>(Accept accept, Crud crud, CancellationToken token)
            where Accept : class;

        public ModifierElementsInRedis(IServiceProvider provider,
            DistributedCacheEntryOptions options)
        {
            this.distributedCache = ActivatorUtilities.GetServiceOrCreateInstance<IDistributedCache>(provider);
            this.logger = ActivatorUtilities.GetServiceOrCreateInstance<ILogger<RedisGetElements<Response, Crud>>>(provider);
            this.crud = ActivatorUtilities.GetServiceOrCreateInstance<Crud>(provider);
            this.options = options;
        }

        public async Task<Response> TryChangeRedisComponentsAsync<Accept>(
            Accept acceptElement,
            CrudOperationOverDb<Accept> crudOperationOverDb,
            CancellationToken token) where Accept : class
        {
            if (acceptElement is null)
                throw new NullReferenceException();

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
                    throw new NullReferenceException("Do not assign teg for redis name");

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
                                { GetOperation: Operation.Create } => CrudOperationRedis<Response>.AddElemenInRedis,
                                { GetOperation: Operation.Update } => CrudOperationRedis<Response>.UpdateElementInRedis,
                                { GetOperation: Operation.Delete } => CrudOperationRedis<Response>.DeleteElementInRedis,
                                _ => throw new Exception("Do not attach attribute On Operation")
                            };
#pragma warning disable 4014
                            ChangeRedisComponentsAsync(allElementsBytesInRedis, teg, result, action, token);
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

            await CrudOperationRedis<Response>.WriteElementsInRedis(newAllElementsInRedis, teg, options, distributedCache, token);
        }
    }
}
