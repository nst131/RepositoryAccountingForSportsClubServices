using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public class ResponsePlaceMapperBL : IMapperAsync<Place, ResponsePlaceDtoBL>
    {
        public async Task<ResponsePlaceDtoBL> Map(Place dto)
        {
            return await Task.FromResult(new ResponsePlaceDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
            });
        }
    }
}
