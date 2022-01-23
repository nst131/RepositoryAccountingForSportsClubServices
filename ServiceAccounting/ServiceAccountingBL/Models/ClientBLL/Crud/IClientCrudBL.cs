using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientBLL.Dto;

namespace ServiceAccountingBL.Models.ClientBLL.Crud
{
    public interface IClientCrudBL
    {
        Task<ResponseClientDtoBL> CreateClient(AcceptCreateClientDtoBL createClientDtoBL);
        Task DeleteClient(int id);
        Task<ResponseGetClientDtoBL> GetClient(int id);
        Task<ResponseClientDtoBL> UpdateClient(AcceptUpdateClientDtoBL updateClientDtoBL);
    }
}