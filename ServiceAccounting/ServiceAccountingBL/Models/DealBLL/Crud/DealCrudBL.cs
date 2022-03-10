using System.Linq;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Mapper;
using ServiceAccountingDA.Models;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public class DealCrudBL : IDealCrudBL
    {
        private readonly ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL> createDeal;
        private readonly IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL> updateDeal;
        private readonly IRemover<Deal> removeDeal;
        private readonly IGetter<ResponseGetDealDtoBL> getDeal;
        private readonly IDealAdditionalOperations dealAdditionalOperations;
        private readonly IServiceAccountingContext context;

        public DealCrudBL(
            IAggregatorDealBL aggregator,
            IDealAdditionalOperations dealAdditionalOperations,
            IServiceAccountingContext context)
        {
            this.createDeal = aggregator.CreateDeal;
            this.updateDeal = aggregator.UpdateDeal;
            this.removeDeal = aggregator.RemoveDeal;
            this.getDeal = aggregator.GetDeal;
            this.dealAdditionalOperations = dealAdditionalOperations;
            this.context = context;
        }

        public async Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL, CancellationToken token = default)
        {
            var client = await this.context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.ClientCard)
                .Include(x => x.Subscriptions)
                .FirstOrDefaultAsync(x => x.Id == createDealDtoBL.ClientId, token);

            if (createDealDtoBL.ClubCardId is not null)
            {
                if (client.ClientCard is not null)
                    throw new ElementAlreadyExistException($"{nameof(Client)} has have this {nameof(ClubCard)} yet");
            }

            if (createDealDtoBL.SubscriptionId is not null)
            {
                var subscritions = await Task.Factory
                    .StartNew(() =>client.Subscriptions
                        .FirstOrDefault(x => x.SubscriptionId == createDealDtoBL.SubscriptionId), token);

                if (subscritions is not null)
                    throw new ElementAlreadyExistException($"{nameof(Client)} has have this {nameof(Subscription)} yet");
            }

            //AttributeValidation
            await dealAdditionalOperations.AddClientCard(createDealDtoBL, token);
            await dealAdditionalOperations.AddSubscriptionToClient(createDealDtoBL, token);

            return await createDeal.Create(createDealDtoBL, token);
        }

        public async Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL, CancellationToken token = default)
        {
            //AttributeValidation
            var deal = await context.Set<Deal>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == updateDealDtoBL.Id, token);

            await dealAdditionalOperations.DeleteClientCard(deal.ClientId);
            await dealAdditionalOperations.DeleteSubscriptionToClient(deal.ClientId, deal.SubscriptionId ?? default, token);

            var createDtoBL = DealCrudMapperBL.Map<AcceptCreateDealDtoBL>(updateDealDtoBL);

            await dealAdditionalOperations.AddClientCard(createDtoBL, token);
            await dealAdditionalOperations.AddSubscriptionToClient(createDtoBL, token);

            return await updateDeal.Update(updateDealDtoBL, token);
        }

        public async Task DeleteDeal(int id, CancellationToken token = default)
            => await removeDeal.Remove(id, token);

        public async Task<ResponseGetDealDtoBL> GetDeal(int id, CancellationToken token = default)
            => await getDeal.Get(id, token);
    }
}
