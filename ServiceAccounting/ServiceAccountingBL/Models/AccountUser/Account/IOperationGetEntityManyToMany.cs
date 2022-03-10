using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public interface IOperationGetEntityManyToMany<ResponseEntity, BaseEntity, BindingEntity>
        where ResponseEntity : class, new()
        where BaseEntity : class, IEntity
        where BindingEntity : class
    {
        Task<ICollection<ResponseEntity>> GetEntityManyToMany(
            OperationGetEntityManyToMany<ResponseEntity, BaseEntity, BindingEntity>.ActionGetBindEntity getCollectionBindEntity,
            OperationGetEntityManyToMany<ResponseEntity, BaseEntity, BindingEntity>.ActionGetBaseEntity getBaseEntity,
            IServiceAccountingContext context,
            int entityId,
            CancellationToken token);
    }
}