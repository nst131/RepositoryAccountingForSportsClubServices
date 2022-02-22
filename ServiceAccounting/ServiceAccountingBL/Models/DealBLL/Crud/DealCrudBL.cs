using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public class DealCrudBL : IDealCrudBL
    {
        private readonly ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL> createDeal;
        private readonly IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL> updateDeal;
        private readonly IRemover<Deal> removeDeal;
        private readonly IGetter<ResponseGetDealDtoBL> getDeal;

        public DealCrudBL(IAggregatorDealBL aggregator)
        {
            this.createDeal = aggregator.CreateDeal;
            this.updateDeal = aggregator.UpdateDeal;
            this.removeDeal = aggregator.RemoveDeal;
            this.getDeal = aggregator.GetDeal;
        }
        
        public async Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL, CancellationToken token = default)
            => await createDeal.Create(createDealDtoBL, token);

        public async Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL, CancellationToken token = default)
            => await updateDeal.Update(updateDealDtoBL, token);

        public async Task DeleteDeal(int id, CancellationToken token = default)
            => await removeDeal.Remove(id, token);

        public async Task<ResponseGetDealDtoBL> GetDeal(int id, CancellationToken token = default)
            => await getDeal.Get(id, token);
    }
}
