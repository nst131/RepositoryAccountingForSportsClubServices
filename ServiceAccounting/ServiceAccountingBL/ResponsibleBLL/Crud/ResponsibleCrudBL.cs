using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingBL.ResponsibleBLL.Mapper;
using ServiceAccountingBL.ResponsibleBLL.Validation;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ResponsibleBLL.Crud
{
    public class ResponsibleCrudBL : IResponsibleCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IResponsibleValidator<CreateResponsibleDtoBL> validatorCreate;
        private readonly IResponsibleValidator<UpdateResponsibleDtoBL> validatorUpdate;

        public ResponsibleCrudBL(IServiceAccountingContext context, IAggregatorResponsibleBL aggregator)
        {
            this.context = context;
            validatorCreate = aggregator.CreateResponsibleValidator;
            validatorUpdate = aggregator.UpdateResponsibleValidator;
        }

        public async Task<ResponsibleDtoBL> CreateResponsible(CreateResponsibleDtoBL createResponsibleDtoBL)
        {
            await validatorCreate.Validate(createResponsibleDtoBL);
            var responsible = CreateResponsibleMapperBL.Map<Responsible>(createResponsibleDtoBL);
            var addedResponsible = await context.Set<Responsible>().AddAsync(responsible);
            await context.SaveChangesAsync();

            return ResponsibleMapperBL.Map<ResponsibleDtoBL>(addedResponsible.Entity);
        }

        public async Task<ResponsibleDtoBL> UpdateResponsible(UpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            await validatorUpdate.Validate(updateResponsibleDtoBL);
            var responsible = UpdateResponsibleMapperBL.Map<Responsible>(updateResponsibleDtoBL);
            var updatedResponsible = await Task.Factory.StartNew(() => context.Set<Responsible>().Update(responsible));
            await context.SaveChangesAsync();

            return ResponsibleMapperBL.Map<ResponsibleDtoBL>(updatedResponsible.Entity);
        }

        public async Task DeleteResponsible(int id)
        {
            try
            {
                var responsible = await context.Set<Responsible>().FirstOrDefaultAsync(x => x.Id == id);
                await Task.Factory.StartNew(() => context.Set<Responsible>().Remove(responsible));
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");
            }
        }

        public async Task<GetResponsibleDtoBL> GetResponsible(int id)
        {
            try
            {
                var responsible = await context.Set<Responsible>().FirstOrDefaultAsync(x => x.Id == id);
                return GetResponsibleMapperBL.Map<GetResponsibleDtoBL>(responsible);
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");
            }
        }

        public async Task<ICollection<GetResponsibleDtoBL>> GetResponsibleAll()
        {
            if (await context.Set<Responsible>().AnyAsync())
            {
                var allResponsibles = await context.Set<Responsible>().ToListAsync();

                return GetResponsibleMapperBL.Map<ICollection<GetResponsibleDtoBL>>(allResponsibles);
            }

            return new List<GetResponsibleDtoBL>();
        }
    }
}
