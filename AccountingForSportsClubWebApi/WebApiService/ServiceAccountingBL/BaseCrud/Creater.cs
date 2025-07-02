using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.BaseCrud
{
    public class Creater<Entity, CreateDto, DtoResponse> : ICreater<CreateDto, DtoResponse>
        where Entity : class, IEntity
        where CreateDto : class
        where DtoResponse : class
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<CreateDto> validator;
        private readonly IMapper<CreateDto, Entity> mapperCreate;
        private readonly IMapperAsync<Entity, DtoResponse> mapperResponse;

        public Creater(IServiceAccountingContext context,
            IValidator<CreateDto> validator,
            IMapper<CreateDto, Entity> mapperCreate,
            IMapperAsync<Entity, DtoResponse> mapperResponse)
        {
            this.context = context;
            this.validator = validator;
            this.mapperResponse = mapperResponse;
            this.mapperCreate = mapperCreate;
        }

        public async Task<DtoResponse> Create(CreateDto createDto, CancellationToken token = default)
        {
            await validator.Validate(createDto);

            var entity = mapperCreate.Map(createDto);

            var entry = await context.Set<Entity>().AddAsync(entity, token);

            await context.SaveChangesAsync(token);

            return await mapperResponse.Map(entry.Entity);
        }
    }
}
