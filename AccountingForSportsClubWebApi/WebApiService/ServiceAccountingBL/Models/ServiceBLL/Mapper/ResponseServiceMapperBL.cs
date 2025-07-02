using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public class ResponseServiceMapperBL : IMapperAsync<Service, ResponseServiceDtoBL>
    {
        public async Task<ResponseServiceDtoBL> Map(Service dto)
        {
            return await Task.FromResult(new ResponseServiceDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name
            });
        }
    }
}