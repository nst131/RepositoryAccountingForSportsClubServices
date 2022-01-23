using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClientBLL.Validation
{
    public class CreateClientValidatorBL : IValidator<AcceptCreateClientDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClientValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateClientDtoBL createClientDtoBL)
        {
            if (createClientDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateClientDtoBL)} is null");

            await Task.CompletedTask;
        }
    }
}
