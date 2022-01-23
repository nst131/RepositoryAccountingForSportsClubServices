using System.Linq;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.BaseCrud
{
    public class Getter<Entity, DtoGetResponse> : IGetter<DtoGetResponse>
        where Entity : class, IEntity
        where DtoGetResponse : class
    {
        private readonly IMapperAsync<int, DtoGetResponse> mapperResponse;
        private readonly IServiceAccountingContext context;

        public Getter(IMapperAsync<int, DtoGetResponse> mapperResponse, IServiceAccountingContext context)
        {
            this.mapperResponse = mapperResponse;
            this.context = context;
        }

        public async Task<DtoGetResponse> Get(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Entity)} is less 0");

            if(await Task.Factory.StartNew(() => context.Set<Entity>().AsNoTracking().ToList().Exists(x => x.Id == id)) is false)
                throw new ElementByIdNotFoundException($"{nameof(Entity)} by Id not Found");

            return await mapperResponse.Map(id);
        }
    }
}
