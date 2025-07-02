using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisLibrary
{
    public interface IRedisGetElements<Response, Fetchers>
        where Response : class, IRedisResponse
        where Fetchers : class
    {
        Task<ICollection<Response>> TryGetElementsAsync(RedisGetElements<Response, Fetchers>.GetEntity getEntity, CancellationToken token);
    }
}
