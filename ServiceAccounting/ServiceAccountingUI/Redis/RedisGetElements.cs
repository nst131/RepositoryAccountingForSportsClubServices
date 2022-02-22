using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Redis
{
    public class RedisGetElements<Response, Fetchers> : IRedisGetElements<Response, Fetchers>
        where Response : class, IRedisResponse
        where Fetchers : class
    {
        private readonly IDistributedCache distributedCache;
        private readonly ILogger<RedisGetElements<Response, Fetchers>> logger;
        private readonly IConfiguration configuration;
        private readonly Fetchers fetchers;

        public delegate Task<ICollection<Response>> GetEntity(Fetchers fetchers, CancellationToken token);

        public RedisGetElements(IDistributedCache distributedCache,
            ILogger<RedisGetElements<Response, Fetchers>> logger,
            IConfiguration configuration, Fetchers fetchers)
        {
            this.distributedCache = distributedCache;
            this.logger = logger;
            this.configuration = configuration;
            this.fetchers = fetchers;
        }

        public async Task<ICollection<Response>> TryGetElementsAsync(GetEntity getEntity, CancellationToken token)
        {
            string teg = "";

            try
            {
                var attributes = typeof(Fetchers).GetCustomAttributes(false);

                foreach (var attr in attributes)
                {
                    if (attr is TegForRedis attribute)
                    {
                        teg = attribute.GetKeyTeg;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(teg))
                    throw new ElementNullReferenceException("Do not assign teg for redis name");

                var elementsRedis = await distributedCache.GetAsync(teg, token);
                if (elementsRedis != null)
                {
                    var serializedElements = Encoding.UTF8.GetString(elementsRedis);
                    return JsonConvert.DeserializeObject<ICollection<Response>>(serializedElements);
                }
            }
            catch (Exception exc)
            {
                logger.LogError($"Redis Server is invalid {exc.Message}, StackTrace {exc.StackTrace}");
                return await getEntity(fetchers, token);
            }

            var elements = await getEntity(fetchers, token);


#pragma warning disable 4014
            WriteElementsInRedis(elements, teg, token);
#pragma warning restore 4014

            return elements;
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
