using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;

namespace ServiceAccountingBL.BaseCrud
{
    public class Remover<Entity> : IRemover<Entity>
        where Entity: class
    {
        private readonly IServiceAccountingContext context;

        public Remover(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Remove(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Entity)} is less 0");

            var entity = await context.Set<Entity>().FindAsync(id);

            if (entity is null)
                throw new ElementByIdNotFoundException($"{nameof(Entity)} by Id not Found");

            await Task.Factory.StartNew(() => context.Set<Entity>().Remove(entity));
            await context.SaveChangesAsync();
        }
    }
}
