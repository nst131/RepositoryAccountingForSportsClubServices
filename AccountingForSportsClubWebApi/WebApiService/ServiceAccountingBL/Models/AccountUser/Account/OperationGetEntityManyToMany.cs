using AutoMapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public class OperationGetEntityManyToMany<ResponseEntity, BaseEntity, BindingEntity> : IOperationGetEntityManyToMany<ResponseEntity, BaseEntity, BindingEntity>
        where ResponseEntity : class, new()
        where BaseEntity : class, IEntity
        where BindingEntity : class
    {
        private readonly IMapper mapper;
        public delegate Task<ICollection<BindingEntity>> ActionGetBindEntity(int entityId, IServiceAccountingContext context);
        public delegate Task<BaseEntity> ActionGetBaseEntity(BindingEntity bindingEntity, IServiceAccountingContext context);

        public OperationGetEntityManyToMany(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseEntity>> GetEntityManyToMany(
            ActionGetBindEntity getCollectionBindEntity,
            ActionGetBaseEntity getBaseEntity,
            IServiceAccountingContext context,
            int entityId,
            CancellationToken token)
        {
            var collectionBindEntity = await getCollectionBindEntity(entityId, context);

            if (collectionBindEntity is null || collectionBindEntity.Count == 0)
                return new List<ResponseEntity>() { new() };

            var listBaseEntity = new List<BaseEntity>();

            foreach (var bindingEntity in collectionBindEntity)
            {
                listBaseEntity.Add(await getBaseEntity(bindingEntity, context));
            }

            var listResponseEntity = new List<ResponseEntity>();
            listBaseEntity.ForEach(x => listResponseEntity.Add(this.mapper.Map<ResponseEntity>(x)));

            return listResponseEntity;
        }
    }
}
