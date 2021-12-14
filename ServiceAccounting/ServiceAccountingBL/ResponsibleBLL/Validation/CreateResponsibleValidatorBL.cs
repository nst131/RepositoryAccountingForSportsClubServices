﻿using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ResponsibleBLL.Validation
{
    public class CreateResponsibleValidatorBL : IResponsibleValidator<CreateResponsibleDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateResponsibleValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(CreateResponsibleDtoBL createResponsibleDtoBL)
        {
            if (createResponsibleDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(CreateResponsibleDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createResponsibleDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(CreateResponsibleDtoBL.Name)} is not assigned");

            if (string.IsNullOrWhiteSpace(createResponsibleDtoBL.SerName))
                throw new ElementNotAssignException($"{nameof(CreateResponsibleDtoBL.SerName)} is not assigned");

            var regex = new Regex("[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}");

            if (!regex.IsMatch(createResponsibleDtoBL.Telephone))
                throw new ElementNotValidByRegexException($"{nameof(CreateResponsibleDtoBL.Telephone)} is not valid by regex");

            await Task.CompletedTask;
        }
    }
}
