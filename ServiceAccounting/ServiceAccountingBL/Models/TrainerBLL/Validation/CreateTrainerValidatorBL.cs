using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Validation
{
    public class CreateTrainerValidatorBL : IValidator<AcceptCreateTrainerDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateTrainerValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateTrainerDtoBL createTrainerDtoBL)
        {
            if (createTrainerDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateTrainerDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createTrainerDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(AcceptCreateTrainerDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createTrainerDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(AcceptCreateTrainerDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createTrainerDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createTrainerDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(AcceptCreateTrainerDtoBL.Telephone)} is not valid by regex");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == createTrainerDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
