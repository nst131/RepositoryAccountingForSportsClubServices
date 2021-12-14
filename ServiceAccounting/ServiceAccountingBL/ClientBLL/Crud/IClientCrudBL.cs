using ServiceAccountingBL.ClientBLL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Crud
{
    public interface IClientCrudBL
    {
        Task<ClientDtoBL> CreateClient(CreateClientDtoBL createClientDtoBL);
        Task DeleteClient(int id);
        Task<GetClientDtoBL> GetClient(int id);
        Task<ICollection<GetClientDtoBL>> GetClientAll();
        Task<ClientDtoBL> UpdateClient(UpdateClientDtoBL updateClientDtoBL);
    }
}