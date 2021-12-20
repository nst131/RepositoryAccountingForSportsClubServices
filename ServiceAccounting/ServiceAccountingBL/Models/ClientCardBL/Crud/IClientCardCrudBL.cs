using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientCardBL.Dto;

namespace ServiceAccountingBL.Models.ClientCardBL.Crud
{
    public interface IClientCardCrudBL
    {
        Task<ResponseClientCardDtoBL> CreateClientCard(AcceptCreateClientCardDtoBL createClientCardDtoBL);
        Task<ResponseClientCardDtoBL> UpdateClientCard(AcceptUpdateClientCardDtoBL updateClientCardDtoBL);
        Task DeleteClientCard(int id);
        Task<ResponseGetClientCardDtoBL> GetClientCard(int id);
    }
}