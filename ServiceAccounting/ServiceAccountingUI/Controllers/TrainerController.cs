using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.TrainerBLL.Aggregator;
using ServiceAccountingBL.TrainerBLL.Crud;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingUI.TrainerUI.Dto;
using ServiceAccountingUI.TrainerUI.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerCrudBL trainerCrudBL;

        public TrainerController(IAggregatorTrainerBL aggregatorTrainerBL)
        {
            this.trainerCrudBL = aggregatorTrainerBL.TrainerCrudBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTrainerById(int trainerId)
        {
            var trainerDtoBL = await trainerCrudBL.GetTrainer(trainerId);

            if (trainerDtoBL is null)
                throw new ElementByIdNotFoundException();

            var trainerDtoUI = GetTrainerMapperUI.Map<GetTrainerDtoUI>(trainerDtoBL);
            return new JsonResult(trainerDtoUI);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTrainers()
        {
            var allTrainersDtoBL = await trainerCrudBL.GetTrainerAll();

            if (allTrainersDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainerDtoUI = GetTrainerMapperUI.Map<ICollection<GetTrainerDtoUI>>(allTrainersDtoBL);
            return new JsonResult(allTrainerDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTrainer(CreateTrainerDtoUI createTrainerDtoUI)
        {
            if (createTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainerBL = CreateTrainerMapperUI.Map<CreateTrainerDtoBL>(createTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.CreateTrainer(createTrainerBL);
            var trainerDtoUI = CreateTrainerMapperUI.Map<TrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTrainer(UpdateTrainerDtoUI updateTrainerDtoUI)
        {
            if (updateTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainerBL = UpdateTrainerMapperUI.Map<UpdateTrainerDtoBL>(updateTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.UpdateTrainer(updateTrainerBL);
            var trainerDtoUI = UpdateTrainerMapperUI.Map<TrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException();

            await trainerCrudBL.DeleteTrainer(id);

            return new JsonResult("Delete was success");
        }
    }
}
