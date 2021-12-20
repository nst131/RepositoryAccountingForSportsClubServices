using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Crud
{
    public class ResponsibleCrudBL : IResponsibleCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL> createResponsible;
        private readonly IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL> updateResponsible;
        private readonly IRemover<Responsible> removeResponsible;

        public ResponsibleCrudBL(IServiceAccountingContext context, IAggregatorResponsibleBL aggregator)
        {
            this.context = context;
            this.createResponsible = aggregator.CreateResponsible;
            this.updateResponsible = aggregator.UpdateResponsible;
            this.removeResponsible = aggregator.RemoveResponsible;
        }

        public async Task<ResponseResponsibleDtoBL> CreateResponsible(AcceptCreateResponsibleDtoBL createResponsibleDtoBL)
        {
            return await createResponsible.Create(createResponsibleDtoBL);
        }

        public async Task<ResponseResponsibleDtoBL> UpdateResponsible(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            return await updateResponsible.Update(updateResponsibleDtoBL);
        }

        public async Task DeleteResponsible(int id)
        {
            await removeResponsible.Remove(id);
        }

        public async Task<ResponseGetResponsibleDtoBL> GetResponsible(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Responsible)} is less 0");

            var responsible = await context.Set<Responsible>().FirstOrDefaultAsync(x => x.Id == id);

            if(responsible is null)
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");

            return ReadResponsibleMapperBL.Map<ResponseGetResponsibleDtoBL>(responsible);
        }
    }
}
