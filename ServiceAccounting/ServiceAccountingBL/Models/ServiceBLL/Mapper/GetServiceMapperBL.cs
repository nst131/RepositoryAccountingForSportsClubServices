using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Mapper
{
    public class GetServiceMapperBL : IMapperAsync<int, ResponseGetServiceDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetServiceMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetServiceDtoBL> Map(int id)
        {
            var dto = await context.Set<Service>()
                .Include(x => x.Place)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetServiceDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceName = dto.Place.Name
            };
        }
    }
}
