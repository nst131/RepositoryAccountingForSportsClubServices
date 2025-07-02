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
    public class CreateVisitValidatorBL : IValidator<AcceptCreateVisitDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateVisitValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }
        
        public async Task Validate(AcceptCreateVisitDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreatePlaceDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClientId)))
                    throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
