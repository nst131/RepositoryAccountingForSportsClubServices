using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Crud;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Aggregator
{
    public interface IAggregatorVisitBL
    {
        IVisitCrudBL VisitCrudBL { get; }
        IVisitFetchersBL VisitFetchersBL { get; }
        ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL> CreateVisit { get; }
        IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL> UpdateVisit { get; }
        IRemover<Visit> RemoveVisit { get; }
        IGetter<ResponseGetVisitDtoBL> GetVisit { get; }
    }
}