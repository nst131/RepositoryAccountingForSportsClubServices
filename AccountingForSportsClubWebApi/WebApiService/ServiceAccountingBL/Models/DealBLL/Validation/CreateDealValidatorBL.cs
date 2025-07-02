using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Validation
{
    public class CreateDealValidatorBL : IValidator<AcceptCreateDealDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateDealValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateDealDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateDealDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClientId)))
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Responsible>().AsNoTracking().ToList().Exists(x => x.Id == dto.ResponsibleId)))
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");

            if(dto.SubscriptionId is not null)
                if (await Task.Factory.StartNew(() => !context.Set<Subscription>().AsNoTracking().ToList().Exists(x => x.Id == dto.SubscriptionId)))
                    throw new ElementByIdNotFoundException($"{nameof(Subscription)} by Id not Found");

            if(dto.ClubCardId is not null)
                if (await Task.Factory.StartNew(() => !context.Set<ClubCard>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClubCardId)))
                    throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");
        }
    }
}

