using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Validation
{
    public class CreateTrainerValidatorBL : IValidator<AcceptCreateTrainerDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateTrainerValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateTrainerDtoBL createTrainerDtoBL)
        {
            if (createTrainerDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateTrainerDtoBL)} is null");

            await Task.CompletedTask;
        }
    }
}
