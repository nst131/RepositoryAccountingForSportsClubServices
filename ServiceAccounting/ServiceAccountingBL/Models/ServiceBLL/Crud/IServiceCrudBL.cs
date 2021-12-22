using System.Threading.Tasks;
using ServiceAccountingBL.Models.ServiceBLL.Dto;

namespace ServiceAccountingBL.Models.ServiceBLL.Crud
{
    public interface IServiceCrudBL
    {
        Task<ResponseServiceDtoBL> CreateService(AcceptCreateServiceDtoBL createServiceDtoBL);
        Task<ResponseServiceDtoBL> UpdateService(AcceptUpdateServiceDtoBL updateServiceDtoBL);
        Task DeleteService(int id);
        Task<ResponseGetServiceDtoBL> GetService(int id);
    }
}