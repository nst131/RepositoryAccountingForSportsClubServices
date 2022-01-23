using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.AttributeValidation
{
    public class UniqueEmailBL : IUniqueEmailBL
    {
        private readonly IServiceAccountingContext context;

        public UniqueEmailBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUnique<T>(string email) where T : class, IEmail
        {
            return await context.Set<T>().AnyAsync(x => x.Email == email);
        }
    }
}
