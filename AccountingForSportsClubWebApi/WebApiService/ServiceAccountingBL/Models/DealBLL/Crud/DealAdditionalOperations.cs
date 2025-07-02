using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public class DealAdditionalOperations : IDealAdditionalOperations
    {
        private readonly IClientCardCrudBL clientCardCrud;
        private readonly IServiceAccountingContext context;

        public DealAdditionalOperations(IClientCardCrudBL clientCardCrud, IServiceAccountingContext context)
        {
            this.clientCardCrud = clientCardCrud;
            this.context = context;
        }

        public async Task AddClientCard(AcceptCreateDealDtoBL createDealDealDtoBl, CancellationToken token)
        {
            if (createDealDealDtoBl.ClubCardId is null)
                return;

            var createClientCard = DealCrudMapperBL.Map<AcceptCreateClientCardDtoBL>(createDealDealDtoBl);
            await this.clientCardCrud.CreateClientCardWithoutSaveChanges(createClientCard, token);
        }

        public async Task AddSubscriptionToClient(AcceptCreateDealDtoBL createDealDealDtoBl, CancellationToken token)
        {
            if (createDealDealDtoBl.SubscriptionId is null)
                return;

            var subsToclient = DealCrudMapperBL.Map<SubscriptionToClient>(createDealDealDtoBl);
            await this.context.Set<SubscriptionToClient>().AddAsync(subsToclient, token);
        }

        public async Task DeleteClientCard(int clientId)
        {
            var client = await this.context.Set<Client>()
                .Include(x => x.ClientCard)
                .FirstOrDefaultAsync(x => x.Id == clientId);

            if (client.ClientCard is not null)
            {
                await Task.Run(() => this.context.Set<ClientCard>().Remove(client.ClientCard));
            }
        }

        public async Task DeleteSubscriptionToClient(int clientId, int subscriptionId, CancellationToken token)
        {
            var subsToClient = await this.context.Set<SubscriptionToClient>()
                .FirstOrDefaultAsync(x => x.ClientId == clientId && x.SubscriptionId == subscriptionId, token);

            if (subsToClient is null)
                return;

            await Task.Run(() => this.context.Set<SubscriptionToClient>().Remove(subsToClient), token);
        }
    }
}
