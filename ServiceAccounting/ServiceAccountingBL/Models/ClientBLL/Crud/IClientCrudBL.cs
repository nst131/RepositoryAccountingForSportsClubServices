using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientBLL.Dto;

namespace ServiceAccountingBL.Models.ClientBLL.Crud
{
    public interface IClientCrudBL
    {
        Task<ResponseClientDtoBL> CreateClient(AcceptCreateClientDtoBL createClientDtoBL, CancellationToken token = default);
        Task DeleteClient(int id, CancellationToken token = default);
        Task<ResponseGetClientDtoBL> GetClient(int id, CancellationToken token = default);
        Task<ResponseClientDtoBL> UpdateClient(AcceptUpdateClientDtoBL updateClientDtoBL, CancellationToken token = default);
    }
}