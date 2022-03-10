using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public interface IOperationGetEntityOneToMany<ResponseEntity, BaseEntity>
        where ResponseEntity : class, new()
        where BaseEntity : class, IEntity
    {
        Task<ICollection<ResponseEntity>> GetEntityOneToMany(
            OperationGetEntityOneToMany<ResponseEntity, BaseEntity>.ActionGetEntity getCollectionEntity,
            IServiceAccountingContext context,
            int entityId,
            CancellationToken token);
    }
}