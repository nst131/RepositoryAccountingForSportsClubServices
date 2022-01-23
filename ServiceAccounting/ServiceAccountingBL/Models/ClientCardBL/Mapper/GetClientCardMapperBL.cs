using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Mapper
{
    public class GetClientCardMapperBL : IMapperAsync<int, ResponseGetClientCardDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetClientCardMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetClientCardDtoBL> Map(int id)
        {
            var dto = await context.Set<ClientCard>()
                .Include(x => x.Service)
                .Include(x => x.ClubCard)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetClientCardDtoBL()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                DateExpiration = dto.DateExpiration,
                ServiceName = dto.Service.Name,
                ClubCardName = dto.ClubCard.Name
            };
        }
    }
}
