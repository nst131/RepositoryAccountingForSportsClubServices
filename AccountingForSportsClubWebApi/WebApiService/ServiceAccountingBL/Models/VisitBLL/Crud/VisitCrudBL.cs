using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Aggregator;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.VisitBLL.Crud
{
    public class VisitCrudBL : IVisitCrudBL
    {
        private readonly ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL> createVisit;
        private readonly IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL> updateVisit;
        private readonly IRemover<Visit> removeVisit;
        private readonly IGetter<ResponseGetVisitDtoBL> getVisit;

        public VisitCrudBL(IAggregatorVisitBL aggregator)
        {
            this.createVisit = aggregator.CreateVisit;
            this.updateVisit = aggregator.UpdateVisit;
            this.removeVisit = aggregator.RemoveVisit;
            this.getVisit = aggregator.GetVisit;
        }

        public async Task<ResponseVisitDtoBL> CreateVisit(AcceptCreateVisitDtoBL createVisitDtoBL, CancellationToken token = default)
            => await createVisit.Create(createVisitDtoBL, token);

        public async Task<ResponseVisitDtoBL> UpdateVisit(AcceptUpdateVisitDtoBL updateVisitDtoBL, CancellationToken token = default)
            => await updateVisit.Update(updateVisitDtoBL, token);

        public async Task DeleteVisit(int id, CancellationToken token = default)
            => await removeVisit.Remove(id, token);

        public async Task<ResponseGetVisitDtoBL> GetVisit(int id, CancellationToken token = default)
            => await getVisit.Get(id, token);
    }
}
