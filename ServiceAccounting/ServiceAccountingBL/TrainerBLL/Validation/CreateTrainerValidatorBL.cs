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
    public class CreateTrainerValidatorBL : ITrainerValidator<CreateTrainerDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateTrainerValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(CreateTrainerDtoBL createTrainerDtoBL)
        {
            if (createTrainerDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(CreateTrainerDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createTrainerDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(CreateTrainerDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createTrainerDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(CreateTrainerDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createTrainerDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createTrainerDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(CreateTrainerDtoBL.Telephone)} is not valid by regex");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == createTrainerDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
