using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class GetClientMapperBL : IMapperAsync<int ,ResponseGetClientDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetClientMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetClientDtoBL> Map(int id)
        {
            var client = await context.Set<Client>()
                .Include(x => x.TypeSex)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetClientDtoBL()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSex = client.TypeSex.Name,
                Email = client.Email
            };
        }
    }
}
