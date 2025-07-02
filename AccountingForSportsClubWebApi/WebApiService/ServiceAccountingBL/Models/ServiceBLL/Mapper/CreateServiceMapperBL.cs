using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public class CreateServiceMapperBL : IMapper<AcceptCreateServiceDtoBL, Service>
    {
        public Service Map(AcceptCreateServiceDtoBL dto)
        {
            return new()
            {
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceId = dto.PlaceId
            };
        }
    }
}
