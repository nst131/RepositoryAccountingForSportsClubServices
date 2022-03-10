using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisLibrary
{
    internal static class CrudOperationRedis<Response> where Response : class, IRedisResponse
    {
        internal static async Task WriteElementsInRedis(
            ICollection<Response> elements,
            string teg,
            DistributedCacheEntryOptions option,
            IDistributedCache dist,
            CancellationToken token)
        {
            var obj = await Task.Factory.StartNew(() =>
            {
                var serealizedSubscription = JsonConvert.SerializeObject(elements);

                return new { serealizedSubscription, option };
            }, token);

            await dist.SetAsync(teg, Encoding.UTF8.GetBytes(obj.serealizedSubscription), obj.option, token);
        }

        internal static ICollection<Response> DeleteElementInRedis(
            ICollection<Response> allElementsInRedis,
            Response elementToDeleteInRedis)
        {
            var list = allElementsInRedis.ToList();
            list.RemoveAll(x => x.Id == elementToDeleteInRedis.Id);
            return list;
        }

        internal static ICollection<Response> AddElemenInRedis(
            ICollection<Response> allElementsInRedis,
            Response elementToAddInRedis)
        {
            allElementsInRedis.Add(elementToAddInRedis);
            return allElementsInRedis;
        }

        internal static ICollection<Response> UpdateElementInRedis(
            ICollection<Response> allElementsInRedis,
            Response elementToUpdateInRedis)
        {
            var list = allElementsInRedis.ToList();
            list.RemoveAll(x => x.Id == elementToUpdateInRedis.Id);
            list.Add(elementToUpdateInRedis);
            return list;
        }
    }
}
