using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingUI.Models.ServiceUI.Dto;

namespace ServiceAccountingUI.Models.ServiceUI.Mapper
{
    public class CreateServiceMapperUI
    {
        public static AcceptCreateServiceDtoBL Map<Result>(AcceptCreateServiceDtoUI dto)
            where Result : AcceptCreateServiceDtoBL
        {
            return new()
            {
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceId = dto.PlaceId 
            };
        }

        public static ResponseServiceDtoUI Map<Result>(ResponseServiceDtoBL dto)
            where Result : ResponseServiceDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
