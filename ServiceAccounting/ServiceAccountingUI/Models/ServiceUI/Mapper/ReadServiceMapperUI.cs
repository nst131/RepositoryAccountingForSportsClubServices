using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingUI.Models.ServiceUI.Dto;

namespace ServiceAccountingUI.Models.ServiceUI.Mapper
{
    public class ReadServiceMapperUI
    {
        public static ResponseGetServiceDtoUI Map<Result>(ResponseGetServiceDtoBL dto)
            where Result : ResponseGetServiceDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price.ToString(),
                DurationInMinutes = dto.DurationInMinutes.ToString(),
                PlaceName = dto.PlaceName
            };
        }

        public static ICollection<ResponseGetServiceDtoUI> Map<Result>(ICollection<ResponseGetServiceDtoBL> dtos)
            where Result : ICollection<ResponseGetServiceDtoUI>
        {
            return dtos.Select(dto => Map<ResponseGetServiceDtoUI>(dto)).ToList();
        }
    }
}
