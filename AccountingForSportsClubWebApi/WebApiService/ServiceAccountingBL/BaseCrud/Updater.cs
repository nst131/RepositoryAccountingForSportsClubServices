using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.BaseCrud
{
    public class Updater<Entity, UpdateDto, DtoResponse> : IUpdater<UpdateDto, DtoResponse>
        where Entity : class, IEntity
        where UpdateDto : class
        where DtoResponse : class
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<UpdateDto> validator;
        private readonly IMapper<UpdateDto, Entity> mapperUpdate;
        private readonly IMapperAsync<Entity, DtoResponse> mapperResponse;

        public Updater(IServiceAccountingContext context,
            IValidator<UpdateDto> validator,
            IMapper<UpdateDto, Entity> mapperUpdate,
            IMapperAsync<Entity, DtoResponse> mapperResponse)
        {
            this.context = context;
            this.validator = validator;
            this.mapperResponse = mapperResponse;
            this.mapperUpdate = mapperUpdate;
        }

        public async Task<DtoResponse> Update(UpdateDto updateDto, CancellationToken token = default)
        {
            await validator.Validate(updateDto);

            var entity = mapperUpdate.Map(updateDto);

            var entry = await Task.Factory.StartNew(() => context.Set<Entity>().Update(entity), token);

            await context.SaveChangesAsync(token);

            return await mapperResponse.Map(entry.Entity);
        }
    }
}
