using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class UpdateClientMapperBL : IMapper<AcceptUpdateClientDtoBL, Client>
    {
        private readonly IServiceAccountingContext context;

        public UpdateClientMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public Client Map(AcceptUpdateClientDtoBL updateClientDtoBL)
        {
            var obj = context.Set<Client>()
                .AsNoTracking()
                .Where(x => x.Id == updateClientDtoBL.Id)
                .Select(x => new {email = x.Email, create = x.CreatedAt}).FirstOrDefaultAsync().Result;

            return new Client()
            {
                Id = updateClientDtoBL.Id,
                Name = updateClientDtoBL.Name,
                SerName = updateClientDtoBL.SerName,
                Telephone = updateClientDtoBL.Telephone,
                TypeSexId = updateClientDtoBL.TypeSexId,
                Email = obj.email,
                CreatedAt = obj.create
            };
        }
    }
}
