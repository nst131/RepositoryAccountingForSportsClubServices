using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Validation
{
    public class UpdateResponsibleValidatorBL : IValidator<AcceptUpdateResponsibleDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateResponsibleValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            if (updateResponsibleDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptUpdateResponsibleDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Responsible>().AsNoTracking().ToList().Exists(x => x.Id == updateResponsibleDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Responsible)} by Id not Found");
        }
    }
}
