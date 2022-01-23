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

        public async Task<ResponseResponsibleDtoBL> CreateResponsible(AcceptCreateResponsibleDtoBL createResponsibleDtoBL)
            => await createResponsible.Create(createResponsibleDtoBL);

        public async Task<ResponseResponsibleDtoBL> UpdateResponsible(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL)
            => await updateResponsible.Update(updateResponsibleDtoBL);

        public async Task DeleteResponsible(int id)
            => await removeResponsible.Remove(id);

        public async Task<ResponseGetResponsibleDtoBL> GetResponsible(int id)
            => await getResponsible.Get(id);
    }
}
