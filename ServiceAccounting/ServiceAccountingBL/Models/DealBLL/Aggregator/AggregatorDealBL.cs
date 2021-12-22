using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Crud;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Aggregator
{
    public class AggregatorDealBL : IAggregatorDealBL
    {
        private readonly Lazy<IDealCrudBL> dealCrudBL;
        private readonly Lazy<IDealFetchersBL> dealFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL>> createDeal;
        private readonly Lazy<IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL>> updateDeal;
        private readonly Lazy<IRemover<Deal>> removeDeal;

        public AggregatorDealBL(Lazy<IDealCrudBL> dealCrudBL,
            Lazy<IDealFetchersBL> dealFetchersBL,
            Lazy<ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL>> createDeal,
            Lazy<IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL>> updateDeal,
            Lazy<IRemover<Deal>> removeDeal)
        {
            this.dealCrudBL = dealCrudBL;
            this.dealFetchersBL = dealFetchersBL;
            this.createDeal = createDeal;
            this.updateDeal = updateDeal;
            this.removeDeal = removeDeal;
        }

        public IDealCrudBL DealCrudBL => dealCrudBL.Value;
        public IDealFetchersBL DealFetchersBL => dealFetchersBL.Value;
        public ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL> CreateDeal => createDeal.Value;
        public IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL> UpdateDeal => updateDeal.Value;
        public IRemover<Deal> RemoveDeal => removeDeal.Value;
    }
}
