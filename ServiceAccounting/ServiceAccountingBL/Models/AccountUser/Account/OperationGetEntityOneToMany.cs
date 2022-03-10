using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public class OperationGetEntityOneToMany<ResponseEntity, BaseEntity> : IOperationGetEntityOneToMany<ResponseEntity, BaseEntity>
        where ResponseEntity : class, new()
        where BaseEntity : class, IEntity
    {
        private readonly IMapper mapper;
        public delegate Task<ICollection<BaseEntity>> ActionGetEntity(int entityId, IServiceAccountingContext context);

        public OperationGetEntityOneToMany(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseEntity>> GetEntityOneToMany(
            ActionGetEntity getCollectionEntity,
            IServiceAccountingContext context,
            int entityId,
            CancellationToken token)
        {
            var collectionEntity = await getCollectionEntity(entityId, context);

            if (collectionEntity is null || collectionEntity.Count == 0)
                return new List<ResponseEntity>() { new() };

            return collectionEntity.Select(entity => this.mapper.Map<ResponseEntity>(entity)).ToList();
        }
    }
}
