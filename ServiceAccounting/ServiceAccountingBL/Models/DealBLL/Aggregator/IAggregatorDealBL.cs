using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Crud;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Aggregator
{
    public interface IAggregatorDealBL
    {
        IDealCrudBL DealCrudBL { get; }
        IDealFetchersBL DealFetchersBL { get; }
        ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL> CreateDeal { get; }
        IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL> UpdateDeal { get; }
        IRemover<Deal> RemoveDeal { get; }
        IGetter<ResponseGetDealDtoBL> GetDeal { get; }
    }
}