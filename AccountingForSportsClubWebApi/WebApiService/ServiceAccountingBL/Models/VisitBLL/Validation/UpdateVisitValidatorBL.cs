using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Validation
{
    public class UpdateVisitValidatorBL : IValidator<AcceptUpdateVisitDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateVisitValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateVisitDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreatePlaceDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Visit>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Visit)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClientId)))
                    throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
