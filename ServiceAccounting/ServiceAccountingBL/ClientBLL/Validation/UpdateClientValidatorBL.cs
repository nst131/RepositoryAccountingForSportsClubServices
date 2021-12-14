using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Validation
{
    public class UpdateClientValidatorBL : IClientValidator<UpdateClientDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateClientValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(UpdateClientDtoBL createClientDtoBL)
        {
            if (createClientDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(UpdateClientDtoBL)} is null");

            if(await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == createClientDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(UpdateClientDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(UpdateClientDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createClientDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createClientDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(UpdateClientDtoBL.Telephone)} is not valid by regex");
        }
    }
}
