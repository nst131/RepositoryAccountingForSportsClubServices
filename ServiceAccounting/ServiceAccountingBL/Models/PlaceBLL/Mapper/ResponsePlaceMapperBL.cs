using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public class ResponsePlaceMapperBL : IMapper<Place, ResponsePlaceDtoBL>
    {
        public ResponsePlaceDtoBL Map(Place dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
