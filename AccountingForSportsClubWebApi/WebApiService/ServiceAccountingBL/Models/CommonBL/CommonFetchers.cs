using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.CommonBL
{
    public class CommonFetchers : ICommonFetchers
    {
        private readonly IServiceAccountingContext context;

        public CommonFetchers(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<int?> GetIdByEmail<TEntity>(string email, CancellationToken token = default)
            where TEntity : class, IEmail
        {
            if (!await context.Set<TEntity>().AnyAsync(token))
                return null;

            return await context.Set<TEntity>()
                .AsNoTracking()
                .Where(x => x.Email == email)
                .Select(x => x.Id)
                .FirstOrDefaultAsync(token);
        }

        public async Task<string> GetEmailById<TEntity>(int id, CancellationToken token = default)
            where TEntity : class, IEmail
        {
            if (!await context.Set<TEntity>().AnyAsync(token))
                return null;

            return await context.Set<TEntity>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.Email)
                .FirstOrDefaultAsync(token);
        }
    }
}
