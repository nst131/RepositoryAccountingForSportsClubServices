using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.PlaceBLL.Validation
{
    public class CreatePlaceValidatorBL : IValidator<AcceptCreatePlaceDtoBL>
    {
        public async Task Validate(AcceptCreatePlaceDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreatePlaceDtoBL)} is null");

            await Task.CompletedTask;
        }
    }
}
