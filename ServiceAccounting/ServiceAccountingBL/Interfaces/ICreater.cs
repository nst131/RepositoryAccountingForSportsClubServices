using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface ICreater< CreateDto, DtoResponse>
        where CreateDto : class
        where DtoResponse : class
    {
        Task<DtoResponse> Create(CreateDto createDto, CancellationToken token = default);
    }
}