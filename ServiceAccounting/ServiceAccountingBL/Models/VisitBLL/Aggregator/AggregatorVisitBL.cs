using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Crud;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Aggregator
{
    public class AggregatorVisitBL : IAggregatorVisitBL
    {
        private readonly Lazy<IVisitCrudBL> visitCrudBL;
        private readonly Lazy<IVisitFetchersBL> visitFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL>> createVisit;
        private readonly Lazy<IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>> updateVisit;
        private readonly Lazy<IRemover<Visit>> removeVisit;

        public AggregatorVisitBL(Lazy<IVisitCrudBL> visitCrudBL,
            Lazy<IVisitFetchersBL> visitFetchersBL,
            Lazy<ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL>> createVisit,
            Lazy<IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>> updateVisit,
            Lazy<IRemover<Visit>> removeVisit)
        {
            this.visitCrudBL = visitCrudBL;
            this.visitFetchersBL = visitFetchersBL;
            this.createVisit = createVisit;
            this.updateVisit = updateVisit;
            this.removeVisit = removeVisit;
        }

        public IVisitCrudBL VisitCrudBL => visitCrudBL.Value;
        public IVisitFetchersBL VisitFetchersBL => visitFetchersBL.Value;
        public ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL> CreateVisit => createVisit.Value;
        public IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL> UpdateVisit => updateVisit.Value;
        public IRemover<Visit> RemoveVisit => removeVisit.Value;
    }
}
