using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;

namespace ServiceAccountingBL.BaseCrud
{
    public class Updater<Entity, UpdateDto, DtoResponse> : IUpdater<UpdateDto, DtoResponse>
        where Entity : class
        where UpdateDto : class
        where DtoResponse : class
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<UpdateDto> validator;
        private readonly IMapper<UpdateDto, Entity> mapperUpdate;
        private readonly IMapper<Entity, DtoResponse> mapperResponse;

        public Updater(IServiceAccountingContext context,
            IValidator<UpdateDto> validator,
            IMapper<Entity, DtoResponse> mapperResponse,
            IMapper<UpdateDto, Entity> mapperUpdate)
        {
            this.context = context;
            this.validator = validator;
            this.mapperResponse = mapperResponse;
            this.mapperUpdate = mapperUpdate;
        }

        public async Task<DtoResponse> Update(UpdateDto updateDto)
        {
            await validator.Validate(updateDto);

            var entity = mapperUpdate.Map(updateDto);

            var entry = await Task.Factory.StartNew(() => context.Set<Entity>().Update(entity));

            await context.SaveChangesAsync();

            return mapperResponse.Map(entry.Entity);
        }
    }
}
