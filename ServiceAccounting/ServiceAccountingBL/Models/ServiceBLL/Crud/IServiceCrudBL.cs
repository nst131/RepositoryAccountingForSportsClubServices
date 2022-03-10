using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ServiceBLL.Dto;

namespace ServiceAccountingBL.Models.ServiceBLL.Crud
{
    public interface IServiceCrudBL
    {
        Task<ResponseServiceDtoBL> CreateService(AcceptCreateServiceDtoBL createServiceDtoBL, CancellationToken token = default);
        Task<ResponseServiceDtoBL> UpdateService(AcceptUpdateServiceDtoBL updateServiceDtoBL, CancellationToken token = default);
        Task DeleteService(int id, CancellationToken token = default);
        Task<ResponseGetServiceDtoBL> GetService(int id, CancellationToken token = default);
    }
}