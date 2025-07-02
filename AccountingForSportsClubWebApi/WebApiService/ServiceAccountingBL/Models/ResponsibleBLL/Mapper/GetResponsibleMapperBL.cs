using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class GetResponsibleMapperBL : IMapperAsync<int, ResponseGetResponsibleDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetResponsibleMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetResponsibleDtoBL> Map(int id)
        {
            var dto = await context.Set<Responsible>()
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetResponsibleDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                SerName = dto.SerName,
                Telephone = dto.Telephone,
                Email = dto.Email
            };
        }
    }
}
