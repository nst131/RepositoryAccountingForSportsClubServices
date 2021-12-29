using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class GetClubCardMapperBL : IMapperAsync<int, ResponseGetClubCardDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetClubCardMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetClubCardDtoBL> Map(int id)
        {
            var dto = await context.Set<ClubCard>()
                .Include(x => x.Service)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetClubCardDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                DurationInDays = dto.DurationInDays,
                Service = dto.Service.Name
            };
        }
    }
}
