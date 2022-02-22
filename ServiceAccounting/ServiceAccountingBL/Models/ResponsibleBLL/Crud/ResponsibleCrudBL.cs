using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Crud
{
    public class ResponsibleCrudBL : IResponsibleCrudBL
    {
        private readonly ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL> createResponsible;
        private readonly IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL> updateResponsible;
        private readonly IRemover<Responsible> removeResponsible;
        private readonly IGetter<ResponseGetResponsibleDtoBL> getResponsible;

        public ResponsibleCrudBL(IAggregatorResponsibleBL aggregator)
        {
            this.createResponsible = aggregator.CreateResponsible;
            this.updateResponsible = aggregator.UpdateResponsible;
            this.removeResponsible = aggregator.RemoveResponsible;
            this.getResponsible = aggregator.GetResponsible;
        }

        public async Task<ResponseResponsibleDtoBL> CreateResponsible(AcceptCreateResponsibleDtoBL createResponsibleDtoBL, CancellationToken token = default)
            => await createResponsible.Create(createResponsibleDtoBL, token);

        public async Task<ResponseResponsibleDtoBL> UpdateResponsible(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL, CancellationToken token = default)
            => await updateResponsible.Update(updateResponsibleDtoBL, token);

        public async Task DeleteResponsible(int id, CancellationToken token = default)
            => await removeResponsible.Remove(id, token);

        public async Task<ResponseGetResponsibleDtoBL> GetResponsible(int id, CancellationToken token = default)
            => await getResponsible.Get(id, token);
    }
}
