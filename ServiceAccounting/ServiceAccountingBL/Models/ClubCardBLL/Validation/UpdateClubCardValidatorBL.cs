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
    public class UpdateClubCardValidatorBL : IValidator<AcceptUpdateClubCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateClubCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateClubCardDtoBL updateClubCardDtoBL)
        {
            if (updateClubCardDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptUpdateClubCardDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<ClubCard>().AsNoTracking().ToList().Exists(x => x.Id == updateClubCardDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == updateClubCardDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
