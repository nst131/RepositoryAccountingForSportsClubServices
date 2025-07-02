using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Aggregator;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ServiceBLL.Crud
{
    public class ServiceCrudBL : IServiceCrudBL
    {
        private readonly ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL> createService;
        private readonly IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL> updateService;
        private readonly IRemover<Service> removeService;
        private readonly IGetter<ResponseGetServiceDtoBL> getService;

        public ServiceCrudBL(IAggregatorServiceBL aggregator)
        {
            this.createService = aggregator.CreateService;
            this.updateService = aggregator.UpdateService;
            this.removeService = aggregator.RemoveService;
            this.getService = aggregator.GetService;
        }

        public async Task<ResponseServiceDtoBL> CreateService(AcceptCreateServiceDtoBL createServiceDtoBL, CancellationToken token = default)
            => await createService.Create(createServiceDtoBL, token);

        public async Task<ResponseServiceDtoBL> UpdateService(AcceptUpdateServiceDtoBL updateServiceDtoBL, CancellationToken token = default)
            => await updateService.Update(updateServiceDtoBL, token);

        public async Task DeleteService(int id, CancellationToken token = default)
            => await removeService.Remove(id, token);

        public async Task<ResponseGetServiceDtoBL> GetService(int id, CancellationToken token = default)
            => await getService.Get(id, token);
    }
}
