using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingUI.Models.PlaceUI.Dto;

namespace ServiceAccountingUI.Models.PlaceUI.Mapper
{
    public class ReadPlaceMapperUI
    {
        public static ResponseGetPlaceDtoUI Map<Result>(ResponseGetPlaceDtoBL dto)
            where Result : ResponseGetPlaceDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }

        public static ICollection<ResponseGetPlaceDtoUI> Map<Result>(ICollection<ResponseGetPlaceDtoBL> dtos)
            where Result : ICollection<ResponseGetPlaceDtoUI>
        {
            return dtos.Select(dto => Map<ResponseGetPlaceDtoUI>(dto)).ToList();
        }
    }
}
