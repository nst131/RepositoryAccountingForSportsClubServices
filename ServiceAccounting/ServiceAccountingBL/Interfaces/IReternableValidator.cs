using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.Interfaces
{
    public interface IReternableValidator<Entity, ReturnableEntity>
        where Entity : class
        where ReturnableEntity : class, IEntity
    {
        Task<ReturnableEntity> Validate(Entity dto, CancellationToken token);
    }
}
