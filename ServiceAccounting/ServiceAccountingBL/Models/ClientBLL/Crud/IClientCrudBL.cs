using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientBLL.Dto;

namespace ServiceAccountingBL.Models.ClientBLL.Crud
{
    public interface IClientCrudBL
    {
        Task<ClientDtoBL> CreateClient(CreateClientDtoBL createClientDtoBL);
        Task DeleteClient(int id);
        Task<GetClientDtoBL> GetClient(int id);
        Task<ClientDtoBL> UpdateClient(UpdateClientDtoBL updateClientDtoBL);
    }
}