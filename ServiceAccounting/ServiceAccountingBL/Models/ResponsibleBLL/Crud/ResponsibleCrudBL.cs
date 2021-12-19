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
        private readonly ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL> createResponsible;
        private readonly IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL> updateResponsible;
        private readonly IRemover<Responsible> removeResponsible;

        public ResponsibleCrudBL(IServiceAccountingContext context, IAggregatorResponsibleBL aggregator)
        {
            this.context = context;
            this.createResponsible = aggregator.CreateResponsible;
            this.updateResponsible = aggregator.UpdateResponsible;
            this.removeResponsible = aggregator.RemoveResponsible;
        }

        public async Task<ResponsibleDtoBL> CreateResponsible(CreateResponsibleDtoBL createResponsibleDtoBL)
        {
            return await createResponsible.Create(createResponsibleDtoBL);
        }

        public async Task<ResponsibleDtoBL> UpdateResponsible(UpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            return await updateResponsible.Update(updateResponsibleDtoBL);
        }

        public async Task DeleteResponsible(int id)
        {
            await removeResponsible.Remove(id);
        }

        public async Task<GetResponsibleDtoBL> GetResponsible(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Responsible)} is less 0");

            var responsible = await context.Set<Responsible>().FirstOrDefaultAsync(x => x.Id == id);

            if(responsible is null)
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");

            return ReadResponsibleMapperBL.Map<GetResponsibleDtoBL>(responsible);
        }
    }
}
