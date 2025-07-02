using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;
using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public class UniqueTelephoneBL : IUniqueTelephoneBL
    {
        private readonly IServiceAccountingContext context;

        public UniqueTelephoneBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUnique<T>(string telephone) where T : class, ITelephone
        {
            return await context.Set<T>().AnyAsync(x => x.Telephone == telephone);
        }
    }
}