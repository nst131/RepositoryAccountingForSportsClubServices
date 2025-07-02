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
    public class CreateClubCardValidatorBL : IValidator<AcceptCreateClubCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClubCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateClubCardDtoBL createClubCardDtoBL)
        {
            if (createClubCardDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateClubCardDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == createClubCardDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
