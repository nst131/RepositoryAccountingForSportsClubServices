using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public class UpdateServiceMapperBL : IMapper<AcceptUpdateServiceDtoBL, Service>
    {
        public Service Map(AcceptUpdateServiceDtoBL dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceId = dto.PlaceId
            };
        }
    }
}