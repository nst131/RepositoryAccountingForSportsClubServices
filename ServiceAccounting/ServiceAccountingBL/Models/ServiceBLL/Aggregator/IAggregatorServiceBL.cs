using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Crud;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Aggregator
{
    public interface IAggregatorServiceBL
    {
        IServiceCrudBL ServiceCrudBL { get; }
        IServiceFetchersBL ServiceFetchersBL { get; }
        ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL> CreateService { get; }
        IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL> UpdateService { get; }
        IRemover<Service> RemoveService { get; }
        IGetter<ResponseGetServiceDtoBL> GetService { get; }
    }
}