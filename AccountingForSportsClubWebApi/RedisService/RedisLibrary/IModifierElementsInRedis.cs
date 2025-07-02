using System.Threading;
using System.Threading.Tasks;

namespace RedisLibrary
{
    public interface IModifierElementsInRedis<Response, Crud>
        where Response : class, IRedisResponse
        where Crud : class
    {
        Task<Response> TryChangeRedisComponentsAsync<Accept>(
            Accept acceptElement, ModifierElementsInRedis<Response, Crud>.CrudOperationOverDb<Accept> crudOperationOverDb,
            CancellationToken token) where Accept : class;
    }
}
