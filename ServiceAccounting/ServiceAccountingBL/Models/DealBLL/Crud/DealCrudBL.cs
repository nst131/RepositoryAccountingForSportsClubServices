using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public class DealCrudBL : IDealCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL> createDeal;
        private readonly IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL> updateDeal;
        private readonly IRemover<Deal> removeDeal;

        public DealCrudBL(IServiceAccountingContext context, IAggregatorDealBL aggregator)
        {
            this.context = context;
            this.createDeal = aggregator.CreateDeal;
            this.updateDeal = aggregator.UpdateDeal;
            this.removeDeal = aggregator.RemoveDeal;
        }
        // In ResponseDealMapperBL writed Include
        public async Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL)
        {
            return await createDeal.Create(createDealDtoBL);
        }
        // In ResponseDealMapperBL writed Include
        public async Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL)
        {
            return await updateDeal.Update(updateDealDtoBL);
        }

        public async Task DeleteDeal(int id)
        {
            await removeDeal.Remove(id);
        }

        public async Task<ResponseGetDealDtoBL> GetDeal(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Deal)} is less 0");

            var deal = await context.Set<Deal>()
                .Include(x => x.Subscription)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.ClubCard)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (deal is null)
                throw new ElementByIdNotFoundException($"{nameof(Deal)} by Id not Found");

            return ReadDealMapperBL.Map<ResponseGetDealDtoBL>(deal);
        }
    }
}
