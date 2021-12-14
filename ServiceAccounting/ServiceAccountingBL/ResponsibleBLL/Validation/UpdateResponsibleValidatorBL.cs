
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ResponsibleBLL.Validation
{
    public class UpdateResponsibleValidatorBL : IResponsibleValidator<UpdateResponsibleDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateResponsibleValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(UpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            if (updateResponsibleDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(UpdateResponsibleDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Responsible>().AsNoTracking().ToList().Exists(x => x.Id == updateResponsibleDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");

            if (string.IsNullOrWhiteSpace(updateResponsibleDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(UpdateResponsibleDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(updateResponsibleDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(UpdateResponsibleDtoBL.SerName)} is not assigned");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(updateResponsibleDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(UpdateResponsibleDtoBL.Telephone)} is not valid by regex");
        }
    }
}
