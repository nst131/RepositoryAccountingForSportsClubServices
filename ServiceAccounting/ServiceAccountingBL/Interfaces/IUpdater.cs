using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IUpdater<UpdateDto, DtoResponse>
        where UpdateDto : class
        where DtoResponse : class
    {
        Task<DtoResponse> Update(UpdateDto updateDto, CancellationToken token = default);
    }
}