using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public static class ReadPlaceMapperBL
    {
        public static ResponseGetPlaceDtoBL Map<Result>(Place dto)
            where Result : ResponseGetPlaceDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }

        public static ICollection<ResponseGetPlaceDtoBL> Map<Result>(ICollection<Place> allDto)
            where Result : ICollection<ResponseGetPlaceDtoBL>
        {
            return allDto.Select(dto => Map<ResponseGetPlaceDtoBL>(dto)).ToList();
        }
    }
}
