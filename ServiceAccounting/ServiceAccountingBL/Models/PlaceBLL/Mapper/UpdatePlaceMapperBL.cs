using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public class UpdatePlaceMapperBL : IMapper<AcceptUpdatePlaceDtoBL, Place>
    {
        public Place Map(AcceptUpdatePlaceDtoBL dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }
    }
}
