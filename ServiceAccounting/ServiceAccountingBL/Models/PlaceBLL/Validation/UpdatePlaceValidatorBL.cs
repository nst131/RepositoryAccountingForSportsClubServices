using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Validation
{
    public class UpdatePlaceValidatorBL : IValidator<AcceptUpdatePlaceDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdatePlaceValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdatePlaceDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreatePlaceDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Place>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Place)} by Id not Found"); ;
        }
    }
}