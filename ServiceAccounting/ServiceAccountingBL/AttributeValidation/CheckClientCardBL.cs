using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.AttributeValidation
{
    public class CheckClientCardBL : ICheckClientCardBL
    {
        private readonly IServiceAccountingContext context;

        public CheckClientCardBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExistClientCard(int clientId)
        {
            var client = await context.Set<Client>()
                .Include(x => x.ClientCard)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == clientId);

            if(client is null)
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            return client.ClientCard is not null;
        }
    }
}
