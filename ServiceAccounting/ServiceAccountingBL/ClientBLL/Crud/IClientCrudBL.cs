using ServiceAccountingBL.ClientBLL.Dto;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Crud
{
    public interface IClientCrudBL
    {
        Task<ClientDtoBL> CreateClient(CreateClientDtoBL createClientDtoBL);
    }
}