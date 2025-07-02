using System.Threading;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.BaseCrud
{
    public class Remover<Entity> : IRemover<Entity>
        where Entity: class, IEntity
    {
        private readonly IServiceAccountingContext context;

        public Remover(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<int> Remove(int id, CancellationToken token = default)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Entity)} is less 0");

            var entity = await context.Set<Entity>().FirstOrDefaultAsync(x => x.Id == id, token);

            if (entity is null)
                throw new ElementByIdNotFoundException($"{nameof(Entity)} by Id not Found");

            await Task.Factory.StartNew(() => token.IsCancellationRequested ? throw new TaskCanceledException() : context.Set<Entity>().Remove(entity), token);
            await context.SaveChangesAsync(token);

            return id;
        }
    }
}
