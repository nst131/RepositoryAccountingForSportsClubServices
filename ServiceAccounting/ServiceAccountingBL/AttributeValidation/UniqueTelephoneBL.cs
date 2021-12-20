using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;

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