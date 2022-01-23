using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Mapper
{
    public class GetPlaceMapperBL : IMapperAsync<int, ResponseGetPlaceDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetPlaceMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetPlaceDtoBL> Map(int id)
        {
            var dto = await context.Set<Place>()
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetPlaceDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountFreePlace = dto.AmountFreePlace
            };
        }
    }
}
