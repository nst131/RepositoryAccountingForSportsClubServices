using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Validation
{
    public class CreateTrainingValidatorBL : IValidator<AcceptCreateTrainingDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateTrainingValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateTrainingDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateTrainingDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Trainer>().AsNoTracking().ToList().Exists(x => x.Id == dto.TrainerId)))
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.ServicesId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
