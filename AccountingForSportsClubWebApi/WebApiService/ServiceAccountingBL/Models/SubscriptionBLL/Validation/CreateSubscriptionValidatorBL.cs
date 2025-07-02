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
    public class CreateSubscriptionValidatorBL : IValidator<AcceptCreateSubscriptionDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateSubscriptionValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateSubscriptionDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateSubscriptionDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");

            if (dto.ClientsId is not null && dto.ClientsId.Any())
            {
                foreach (var id in dto.ClientsId)
                {
                    if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == id)))
                        throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
                }
            }
        }
    }
}
