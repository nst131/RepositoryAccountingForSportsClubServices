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
        private readonly Lazy<ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL>> createResponsible;
        private readonly Lazy<IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL>> updateResponsible;
        private readonly Lazy<IRemover<Responsible>> removeResponsible;

        public AggregatorResponsibleBL(Lazy<IResponsibleCrudBL> responsibleCrudBL,
            Lazy<IResponsibleFetchersBL> responsibleFetchersBL,
            Lazy<ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL>> createResponsible,
            Lazy<IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL>> updateResponsible,
            Lazy<IRemover<Responsible>> removeResponsible)
        {
            this.responsibleCrudBL = responsibleCrudBL;
            this.responsibleFetchersBL = responsibleFetchersBL;
            this.createResponsible = createResponsible;
            this.updateResponsible = updateResponsible;
            this.removeResponsible = removeResponsible;
        }

        public IResponsibleCrudBL ResponsibleCrudBL => responsibleCrudBL.Value;
        public IResponsibleFetchersBL ResponsibleFetchersBL => responsibleFetchersBL.Value;
        public ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL> CreateResponsible => createResponsible.Value;
        public IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL> UpdateResponsible => updateResponsible.Value;
        public IRemover<Responsible> RemoveResponsible => removeResponsible.Value;
    }
}
