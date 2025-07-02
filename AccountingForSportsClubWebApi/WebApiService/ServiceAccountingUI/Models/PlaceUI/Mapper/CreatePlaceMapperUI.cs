using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingUI.Models.PlaceUI.Dto;

namespace ServiceAccountingUI.Models.PlaceUI.Mapper
{
    public static class CreatePlaceMapperUI
    {
        public static AcceptCreatePlaceDtoBL Map<Result>(AcceptCreatePlaceDtoUI dto)
            where Result : AcceptCreatePlaceDtoBL
        {
            return new()
            {
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
