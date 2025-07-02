using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public static class ReadServiceMapperBL
    {
        public static ResponseGetServiceDtoBL Map<Result>(Service dto)
            where Result: ResponseGetServiceDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceName = dto.Place.Name
            };
        }

        public static ICollection<ResponseGetServiceDtoBL> Map<Result>(ICollection<Service> dto)
            where Result : ICollection<ResponseGetServiceDtoBL>
        {
            return dto.Select(x => Map<ResponseGetServiceDtoBL>(x)).ToList();
        }
    }
}