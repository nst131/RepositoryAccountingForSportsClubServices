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
        
        public async Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL)
            => await createDeal.Create(createDealDtoBL);

        public async Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL)
            => await updateDeal.Update(updateDealDtoBL);

        public async Task DeleteDeal(int id)
            => await removeDeal.Remove(id);

        public async Task<ResponseGetDealDtoBL> GetDeal(int id)
            => await getDeal.Get(id);
    }
}
