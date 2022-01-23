using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingUI.Models.PlaceUI.Dto;

namespace ServiceAccountingUI.Models.PlaceUI.Mapper
{
    public class UpdatePlaceMapperUI
    {
        public static AcceptUpdatePlaceDtoBL Map<Result>(AcceptUpdatePlaceDtoUI dto)
            where Result : AcceptUpdatePlaceDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }

        public static ResponsePlaceDtoUI Map<Result>(ResponsePlaceDtoBL dto)
            where Result : ResponsePlaceDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
