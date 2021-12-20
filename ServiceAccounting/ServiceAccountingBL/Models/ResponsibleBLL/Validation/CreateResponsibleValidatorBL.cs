using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Validation
{
    public class CreateResponsibleValidatorBL : IValidator<AcceptCreateResponsibleDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateResponsibleValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateResponsibleDtoBL createResponsibleDtoBL)
        {
            if (createResponsibleDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateResponsibleDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createResponsibleDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(AcceptCreateResponsibleDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createResponsibleDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(AcceptCreateResponsibleDtoBL.SerName)} is not assigned");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createResponsibleDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(AcceptCreateResponsibleDtoBL.Telephone)} is not valid by regex");

            await Task.CompletedTask;
        }
    }
}
