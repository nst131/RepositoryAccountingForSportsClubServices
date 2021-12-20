using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Validation
{
    public class CreateClientValidatorBL : IValidator<AcceptCreateClientDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClientValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateClientDtoBL createClientDtoBL)
        {
            if (createClientDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateClientDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(AcceptCreateClientDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(AcceptCreateClientDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createClientDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createClientDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(AcceptCreateClientDtoBL.Telephone)} is not valid by regex");
        }
    }
}
