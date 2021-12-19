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
        ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL> CreateResponsible { get; }
        IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL> UpdateResponsible { get; }
        IRemover<Responsible> RemoveResponsible { get; }
    }
}