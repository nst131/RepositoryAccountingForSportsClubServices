using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Validation
{
    public class CreateResponsibleValidatorBL : IValidator<AcceptCreateResponsibleDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateResponsibleValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateResponsibleDtoBL createResponsibleDtoBL)
        {
            if (createResponsibleDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateResponsibleDtoBL)} is null");

            await Task.CompletedTask;
        }
    }
}
