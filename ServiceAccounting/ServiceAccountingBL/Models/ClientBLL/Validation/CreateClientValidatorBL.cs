using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

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

            if (await Task.Factory.StartNew(() => !context.Set<TypeOfSex>().AsNoTracking().ToList().Exists(x => x.Id == createClientDtoBL.TypeSexId)))
                throw new ElementByIdNotFoundException($"{nameof(TypeOfSex)} by Id not Found");
        }
    }
}
