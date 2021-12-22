using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Aggregator;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Crud
{
    public class VisitCrudBL : IVisitCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL> createVisit;
        private readonly IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL> updateVisit;
        private readonly IRemover<Visit> removeVisit;

        public VisitCrudBL(IServiceAccountingContext context, IAggregatorVisitBL aggregator)
        {
            this.context = context;
            this.createVisit = aggregator.CreateVisit;
            this.updateVisit = aggregator.UpdateVisit;
            this.removeVisit = aggregator.RemoveVisit;
        }
        // In ResponseVisitMapperBL writed Include
        public async Task<ResponseVisitDtoBL> CreateVisit(AcceptCreateVisitDtoBL createVisitDtoBL)
        {
            return await createVisit.Create(createVisitDtoBL);
        }
        // In ResponseVisitMapperBL writed Include
        public async Task<ResponseVisitDtoBL> UpdateVisit(AcceptUpdateVisitDtoBL updateVisitDtoBL)
        {
            return await updateVisit.Update(updateVisitDtoBL);
        }

        public async Task DeleteVisit(int id)
        {
            await removeVisit.Remove(id);
        }

        public async Task<ResponseGetVisitDtoBL> GetVisit(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Visit)} is less 0");

            var visit = await context.Set<Visit>()
                .Include(x => x.Client)
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (visit is null)
                throw new ElementByIdNotFoundException($"{nameof(Visit)} by Id not Found");

            return ReadVisitMapperBL.Map<ResponseGetVisitDtoBL>(visit);
        }
    }
}
