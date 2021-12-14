using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceAccountingBL.TrainerBLL.Validation
{
    public class UpdateTrainerValidatorBL : ITrainerValidator<UpdateTrainerDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateTrainerValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(UpdateTrainerDtoBL updateTrainerDtoBL)
        {
            if (updateTrainerDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(UpdateTrainerDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Trainer>().AsNoTracking().ToList().Exists(x => x.Id == updateTrainerDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");

            if (string.IsNullOrWhiteSpace(updateTrainerDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(UpdateTrainerDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(updateTrainerDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(UpdateTrainerDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == updateTrainerDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(updateTrainerDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(UpdateTrainerDtoBL.Telephone)} is not valid by regex");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == updateTrainerDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
