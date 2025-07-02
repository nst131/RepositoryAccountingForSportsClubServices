using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Crud
{
    public interface IClientCardCrudBL
    {
        Task<ResponseClientCardDtoBL> CreateClientCard(AcceptCreateClientCardDtoBL createClientCardDtoBL, CancellationToken token = default);
        Task<ResponseClientCardDtoBL> UpdateClientCard(AcceptUpdateClientCardDtoBL updateClientCardDtoBL, CancellationToken token = default);
        Task DeleteClientCard(int id, CancellationToken token = default);
        Task<ResponseGetClientCardDtoBL> GetClientCard(int id, CancellationToken token = default);

        Task<EntityEntry<ClientCard>> CreateClientCardWithoutSaveChanges(AcceptCreateClientCardDtoBL createClientCardDtoBL, 
            CancellationToken token = default);
    }
}