using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public class CreatePlaceMapperBL : IMapper<AcceptCreatePlaceDtoBL, Place>
    {
        public Place Map(AcceptCreatePlaceDtoBL dto)
        {
            return new()
            {
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }
    }
}
