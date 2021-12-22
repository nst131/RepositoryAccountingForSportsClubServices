using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Validation
{
    public class CreateServiceValidatorBL : IValidator<AcceptCreateServiceDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateServiceValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateServiceDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateServiceDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ElementNotAssignException($"{nameof(AcceptCreateServiceDtoBL.Name)} is not assigned");

            if (dto.Price < 0)
                throw new ElementOutOfRangeException($"{nameof(AcceptCreateServiceDtoBL.Price)} can not less 0");

            if (dto.DurationInMinutes < 0)
                throw new ElementOutOfRangeException($"{nameof(AcceptCreateServiceDtoBL.DurationInMinutes)} can not less 0");

            if (await Task.Factory.StartNew(() => !context.Set<Place>().AsNoTracking().ToList().Exists(x => x.Id == dto.PlaceId)))
                throw new ElementByIdNotFoundException($"{nameof(Place)} by Id not Found");
        }
    }
}
