using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Aggregator;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Crud
{
    public class ServiceCrudBL : IServiceCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL> createService;
        private readonly IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL> updateService;
        private readonly IRemover<Service> removeService;

        public ServiceCrudBL(IServiceAccountingContext context, IAggregatorServiceBL aggregator)
        {
            this.context = context;
            this.createService = aggregator.CreateService;
            this.updateService = aggregator.UpdateService;
            this.removeService = aggregator.RemoveService;
        }

        public async Task<ResponseServiceDtoBL> CreateService(AcceptCreateServiceDtoBL createServiceDtoBL)
        {
            return await createService.Create(createServiceDtoBL);
        }

        public async Task<ResponseServiceDtoBL> UpdateService(AcceptUpdateServiceDtoBL updateServiceDtoBL)
        {
            return await updateService.Update(updateServiceDtoBL);
        }

        public async Task DeleteService(int id)
        {
            await removeService.Remove(id);
        }

        public async Task<ResponseGetServiceDtoBL> GetService(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Service)} is less 0");

            var service = await context.Set<Service>()
                .Include(x => x.Place)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (service is null)
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");

            return ReadServiceMapperBL.Map<ResponseGetServiceDtoBL>(service);
        }
    }
}
