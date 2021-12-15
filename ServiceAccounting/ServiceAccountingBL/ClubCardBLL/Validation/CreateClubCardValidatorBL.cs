using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClubCardBLL.Validation
{
    public class CreateClubCardValidatorBL : IClubCardValidator<CreateClubCardDtoBL>
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
