using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Aggregator
{
    public interface IAggregatorResponsibleBL
    {
        IResponsibleCrudBL ResponsibleCrudBL { get; }
        IResponsibleFetchersBL ResponsibleFetchersBL { get; }
        ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL> CreateResponsible { get; }
        IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL> UpdateResponsible { get; }
        IRemover<Responsible> RemoveResponsible { get; }
        IGetter<ResponseGetResponsibleDtoBL> GetResponsible { get; }
    }
}