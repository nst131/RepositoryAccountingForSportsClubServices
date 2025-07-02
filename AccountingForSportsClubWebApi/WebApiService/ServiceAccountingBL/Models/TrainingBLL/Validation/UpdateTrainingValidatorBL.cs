using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.TrainingBLL.Validation
{
    public class UpdateTrainingValidatorBL : IValidator<AcceptUpdateTrainingDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateTrainingValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateTrainingDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateTrainingDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<Training>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new ElementByIdNotFoundException($"{nameof(Training)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Trainer>().AsNoTracking().ToList().Exists(x => x.Id == dto.TrainerId)))
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == dto.ServicesId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
