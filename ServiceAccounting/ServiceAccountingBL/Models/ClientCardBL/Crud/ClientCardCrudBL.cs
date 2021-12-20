using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Aggregator;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.ClientCardBL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClientCardBL.Crud
{
    public class ClientCardCrudBL : IClientCardCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<AcceptCreateClientCardDtoBL> createValidator;
        private readonly IValidator<AcceptUpdateClientCardDtoBL> updateValidator;
        private readonly IRemover<ClientCard> removeClientCard;

        public ClientCardCrudBL(IServiceAccountingContext context, IAggregatorClientCardBL aggregator)
        {
            this.context = context;
            this.removeClientCard = aggregator.RemoveClientCard;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
        }

        public async Task<ResponseClientCardDtoBL> CreateClientCard(AcceptCreateClientCardDtoBL createClientCardDtoBL)
        {
            await createValidator.Validate(createClientCardDtoBL);

            var clientCard = CreateClientCardMapperBL.Map<ClientCard>(createClientCardDtoBL);

            var clubCard = await context.Set<ClubCard>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == clientCard.ClubCardId);

            clientCard.DateExpiration = clientCard.DateActivation.AddDays(clubCard.DurationInDays);
            clientCard.ServiceId = clubCard.ServiceId;
            var addedClientCard = await context.Set<ClientCard>().AddAsync(clientCard);
            await context.SaveChangesAsync();

            return ResponseClientCardMapperBL.Map<ResponseClientCardDtoBL>(addedClientCard.Entity);
        }

        public async Task<ResponseClientCardDtoBL> UpdateClientCard(AcceptUpdateClientCardDtoBL updateClientCardDtoBL)
        {
            await updateValidator.Validate(updateClientCardDtoBL);

            var clientCard = UpdateClientCardMapperBL.Map<ClientCard>(updateClientCardDtoBL);

            var clubCard = await context.Set<ClubCard>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == clientCard.ClubCardId);

            clientCard.DateExpiration = clientCard.DateActivation.AddDays(clubCard.DurationInDays);
            clientCard.ServiceId = clubCard.ServiceId;
            var updatedClientCard = await Task.Factory.StartNew(() => context.Set<ClientCard>().Update(clientCard));
            await context.SaveChangesAsync();

            return ResponseClientCardMapperBL.Map<ResponseClientCardDtoBL>(updatedClientCard.Entity);
        }

        public async Task DeleteClientCard(int id)
        {
            await removeClientCard.Remove(id);
        }

        public async Task<ResponseGetClientCardDtoBL> GetClientCard(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(ClientCard)} is less 0");

            var clientCard = await context.Set<ClientCard>()
                .Include(x => x.Service)
                .Include(x => x.ClubCard)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (clientCard is null)
                throw new ElementByIdNotFoundException($"{nameof(ClientCard)} by Id not Found");

            return ReadClientCardMapperBL.Map<ResponseGetClientCardDtoBL>(clientCard);
        }
    }
}
