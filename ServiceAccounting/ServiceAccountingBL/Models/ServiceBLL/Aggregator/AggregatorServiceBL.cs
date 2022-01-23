using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Crud;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Aggregator
{
    public class AggregatorServiceBL : IAggregatorServiceBL
    {
        private readonly Lazy<IServiceCrudBL> serviceCrudBL;
        private readonly Lazy<IServiceFetchersBL> serviceFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL>> createService;
        private readonly Lazy<IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>> updateService;
        private readonly Lazy<IRemover<Service>> removeService;
        private readonly Lazy<IGetter<ResponseGetServiceDtoBL>> getService;

        public AggregatorServiceBL(Lazy<IServiceCrudBL> serviceCrudBL,
            Lazy<IServiceFetchersBL> serviceFetchersBL,
            Lazy<ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL>> createService,
            Lazy<IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>> updateService,
            Lazy<IRemover<Service>> removeService,
            Lazy<IGetter<ResponseGetServiceDtoBL>> getService)
        {
            this.serviceCrudBL = serviceCrudBL;
            this.serviceFetchersBL = serviceFetchersBL;
            this.createService = createService;
            this.updateService = updateService;
            this.removeService = removeService;
            this.getService = getService;   
        }

        public IServiceCrudBL ServiceCrudBL => serviceCrudBL.Value;
        public IServiceFetchersBL ServiceFetchersBL => serviceFetchersBL.Value;
        public ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL> CreateService => createService.Value;
        public IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL> UpdateService => updateService.Value;
        public IRemover<Service> RemoveService => removeService.Value;
        public IGetter<ResponseGetServiceDtoBL> GetService => getService.Value;
    }
}
