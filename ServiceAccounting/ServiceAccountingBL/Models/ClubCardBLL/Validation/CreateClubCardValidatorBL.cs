using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Validation
{
    public class CreateClubCardValidatorBL : IValidator<CreateClubCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClubCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(CreateClubCardDtoBL createClubCardDtoBL)
        {
            if (createClubCardDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(CreateClubCardDtoBL)} is null");

            if (string.IsNullOrWhiteSpace(createClubCardDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(CreateClubCardDtoBL.Name)} is not assigned");

            if (createClubCardDtoBL.Price < 0)
                throw new ElementOutOfRangeException($"{nameof(CreateClubCardDtoBL.Price)} can not less 0");

            if (createClubCardDtoBL.DurationInDays < 0)
                throw new ElementOutOfRangeException($"{nameof(CreateClubCardDtoBL.DurationInDays)} can not less 0");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == createClubCardDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
