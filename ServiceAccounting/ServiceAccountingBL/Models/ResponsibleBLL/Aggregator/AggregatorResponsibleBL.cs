using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Models;
using System;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Aggregator
{
    public class AggregatorResponsibleBL : IAggregatorResponsibleBL
    {
        private readonly Lazy<IResponsibleCrudBL> responsibleCrudBL;
        private readonly Lazy<IResponsibleFetchersBL> responsibleFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>> createResponsible;
        private readonly Lazy<IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>> updateResponsible;
        private readonly Lazy<IRemover<Responsible>> removeResponsible;
        private readonly Lazy<IGetter<ResponseGetResponsibleDtoBL>> getResponsible;

        public AggregatorResponsibleBL(Lazy<IResponsibleCrudBL> responsibleCrudBL,
            Lazy<IResponsibleFetchersBL> responsibleFetchersBL,
            Lazy<ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>> createResponsible,
            Lazy<IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>> updateResponsible,
            Lazy<IRemover<Responsible>> removeResponsible,
            Lazy<IGetter<ResponseGetResponsibleDtoBL>> getResponsible)
        {
            this.responsibleCrudBL = responsibleCrudBL;
            this.responsibleFetchersBL = responsibleFetchersBL;
            this.createResponsible = createResponsible;
            this.updateResponsible = updateResponsible;
            this.removeResponsible = removeResponsible;
            this.getResponsible = getResponsible;
        }

        public IResponsibleCrudBL ResponsibleCrudBL => responsibleCrudBL.Value;
        public IResponsibleFetchersBL ResponsibleFetchersBL => responsibleFetchersBL.Value;
        public ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL> CreateResponsible => createResponsible.Value;
        public IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL> UpdateResponsible => updateResponsible.Value;
        public IRemover<Responsible> RemoveResponsible => removeResponsible.Value;
        public IGetter<ResponseGetResponsibleDtoBL> GetResponsible => getResponsible.Value;
    }
}
