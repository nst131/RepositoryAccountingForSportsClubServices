using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Validation
{
    public class CreateClientValidatorBL : IClientValidator<CreateClientDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClientValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(CreateClientDtoBL createClientDtoBL)
        {
            if (createClientDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(CreateClientDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(CreateClientDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createClientDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(CreateClientDtoBL.SerName)} is not assigned");

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createClientDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createClientDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(CreateClientDtoBL.Telephone)} is not valid by regex");
        }
    }
}
