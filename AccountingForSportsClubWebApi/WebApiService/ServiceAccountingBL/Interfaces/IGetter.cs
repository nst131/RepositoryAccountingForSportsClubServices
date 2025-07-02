using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IGetter<DtoGetResponse>
        where DtoGetResponse : class 
    {
        Task<DtoGetResponse> Get(int id, CancellationToken token = default);
    }
}