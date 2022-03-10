using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedisLibrary.Attributes;

namespace RedisLibrary
{
    public class RedisGetElements<Response, Fetchers> : IRedisGetElements<Response, Fetchers>
          where Response : class, IRedisResponse
          where Fetchers : class
    {
        private readonly IDistributedCache distributedCache;
        private readonly ILogger<RedisGetElements<Response, Fetchers>> logger;
        private readonly Fetchers fetchers;
        private readonly DistributedCacheEntryOptions options;

        public delegate Task<ICollection<Response>> GetEntity(Fetchers fetchers, CancellationToken token);

        public RedisGetElements(IServiceProvider provider, DistributedCacheEntryOptions options)
        {
            this.distributedCache = ActivatorUtilities.GetServiceOrCreateInstance<IDistributedCache>(provider);
            this.logger = ActivatorUtilities.GetServiceOrCreateInstance<ILogger<RedisGetElements<Response, Fetchers>>>(provider);
            this.fetchers = ActivatorUtilities.GetServiceOrCreateInstance<Fetchers>(provider);
            this.options = options;
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
                    throw new NullReferenceException("Do not assign teg for redis name");

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
            CrudOperationRedis<Response>.WriteElementsInRedis(elements, teg, options, distributedCache, token);
#pragma warning restore 4014

            return elements;
        }
    }
}
