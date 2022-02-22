using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingUI.Interfaces;

namespace ServiceAccountingUI.Redis
{
    public interface IRedisAddOrUpdateElement<Response, Crud>
        where Response : class, IRedisResponse
        where Crud : class
    {
        Task<Response?> TryChangeRedisComponentsAsync<Accept>(
            Accept acceptElement, RedisAddOrUpdateElement<Response, Crud>.CrudOperationOverDb<Accept> crudOperationOverDb,
            CancellationToken token) where Accept : class;
    }
}