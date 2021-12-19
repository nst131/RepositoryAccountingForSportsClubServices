using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;

namespace ServiceAccountingBL.BaseCrud
{
    public class Creater<Entity, CreateDto, DtoResponse> : ICreater<CreateDto, DtoResponse>
        where Entity : class
        where CreateDto : class
        where DtoResponse : class
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<CreateDto> validator;
        private readonly IMapper<CreateDto, Entity> mapperCreate;
        private readonly IMapper<Entity, DtoResponse> mapperResponse;

        public Creater(IServiceAccountingContext context,
            IValidator<CreateDto> validator,
            IMapper<Entity, DtoResponse> mapperResponse,
             IMapper<CreateDto, Entity> mapperCreate)
        {
            this.context = context;
            this.validator = validator;
            this.mapperResponse = mapperResponse;
            this.mapperCreate = mapperCreate;
        }

        public async Task<DtoResponse> Create(CreateDto createDto)
        {
            await validator.Validate(createDto);

            var entity = mapperCreate.Map(createDto);

            var entry = await context.Set<Entity>().AddAsync(entity);

            await context.SaveChangesAsync();

            return mapperResponse.Map(entry.Entity);
        }
    }
}
