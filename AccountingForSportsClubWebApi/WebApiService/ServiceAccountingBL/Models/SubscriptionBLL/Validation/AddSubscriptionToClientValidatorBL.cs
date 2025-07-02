using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Validation
{
    public class AddSubscriptionToClientValidatorBL : IValidator<AcceptAddSubscriptionToClientDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public AddSubscriptionToClientValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptAddSubscriptionToClientDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptAddSubscriptionToClientDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Subscription>().AsNoTracking().ToList().Exists(x => x.Id == dto.SubscriptionId)))
                throw new ElementByIdNotFoundException($"{nameof(Subscription)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClientId)))
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
        }
    }
}
