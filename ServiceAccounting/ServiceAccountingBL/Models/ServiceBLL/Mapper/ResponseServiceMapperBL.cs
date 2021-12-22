using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public class ResponseServiceMapperBL : IMapper<Service, ResponseServiceDtoBL>
    {
        public ResponseServiceDtoBL Map(Service dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}