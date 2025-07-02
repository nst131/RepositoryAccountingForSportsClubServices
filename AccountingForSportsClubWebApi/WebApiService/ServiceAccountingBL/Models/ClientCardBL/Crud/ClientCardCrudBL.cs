using System.Threading;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Aggregator;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.ClientCardBL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ServiceAccountingBL.Models.ClientCardBL.Crud
{
    public class ClientCardCrudBL : IClientCardCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<AcceptCreateClientCardDtoBL> createValidator;
        private readonly IValidator<AcceptUpdateClientCardDtoBL> updateValidator;
        private readonly IRemover<ClientCard> removeClientCard;
        private readonly IGetter<ResponseGetClientCardDtoBL> getClientCard;

        public ClientCardCrudBL(IServiceAccountingContext context, IAggregatorClientCardBL aggregator)
        {
            this.context = context;
            this.removeClientCard = aggregator.RemoveClientCard;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getClientCard = aggregator.GetClientCard;
        }

        public async Task<ResponseClientCardDtoBL> CreateClientCard(AcceptCreateClientCardDtoBL createClientCardDtoBL, CancellationToken token = default)
        {
            var addedClientCard = await CreateClientCardWithoutSaveChanges(createClientCardDtoBL, token);
            await context.SaveChangesAsync(token);

            return ResponseClientCardMapperBL.Map<ResponseClientCardDtoBL>(addedClientCard.Entity);
        }

        public async Task<EntityEntry<ClientCard>> CreateClientCardWithoutSaveChanges(AcceptCreateClientCardDtoBL createClientCardDtoBL, 
            CancellationToken token = default)
        {
            await createValidator.Validate(createClientCardDtoBL);

            var clientCard = CreateClientCardMapperBL.Map<ClientCard>(createClientCardDtoBL);

            var clubCard = await context.Set<ClubCard>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == clientCard.ClubCardId, token);

            clientCard.DateExpiration = clientCard.DateActivation.AddDays(clubCard.DurationInDays);
            clientCard.ServiceId = clubCard.ServiceId;

            return await context.Set<ClientCard>().AddAsync(clientCard, token);
        }

        public async Task<ResponseClientCardDtoBL> UpdateClientCard(AcceptUpdateClientCardDtoBL updateClientCardDtoBL, CancellationToken token = default)
        {
            await updateValidator.Validate(updateClientCardDtoBL);

            var clientCard = UpdateClientCardMapperBL.Map<ClientCard>(updateClientCardDtoBL);

            var clubCard = await context.Set<ClubCard>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == clientCard.ClubCardId, token);

            clientCard.DateExpiration = clientCard.DateActivation.AddDays(clubCard.DurationInDays);
            clientCard.ServiceId = clubCard.ServiceId;
            var updatedClientCard = await Task.Factory.StartNew(() => 
                    token.IsCancellationRequested ? throw new TaskCanceledException() : context.Set<ClientCard>().Update(clientCard), token);
            await context.SaveChangesAsync(token);

            return ResponseClientCardMapperBL.Map<ResponseClientCardDtoBL>(updatedClientCard.Entity);
        }

        public async Task DeleteClientCard(int id, CancellationToken token = default)
            => await removeClientCard.Remove(id, token);

        public async Task<ResponseGetClientCardDtoBL> GetClientCard(int id, CancellationToken token = default)
            => await getClientCard.Get(id, token);
    }
}
