using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ServiceBLL.Validation
{
    public class UpdateServiceValidatorBL : IValidator<AcceptUpdateServiceDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateServiceValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateServiceDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateServiceDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Place>().AsNoTracking().ToList().Exists(x => x.Id == dto.PlaceId)))
                throw new ElementByIdNotFoundException($"{nameof(Place)} by Id not Found");
        }
    }
}
