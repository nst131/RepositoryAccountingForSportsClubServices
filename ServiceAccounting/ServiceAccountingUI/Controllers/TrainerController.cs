using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingUI.Models.TrainerUI.Dto;
using ServiceAccountingUI.Models.TrainerUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerCrudBL trainerCrudBL;
        private readonly ITrainerFetchersBL trainerFetchersBL; 

        public TrainerController(IAggregatorTrainerBL aggregatorTrainerBL)
        {
            this.trainerCrudBL = aggregatorTrainerBL.TrainerCrudBL;
            this.trainerFetchersBL = aggregatorTrainerBL.TrainerFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTrainers()
        {
            var allTrainersDtoBL = await trainerFetchersBL.GetTrainerAll();

            if (allTrainersDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainerDtoUI = ReadTrainerMapperUI.Map<ICollection<ResponseGetTrainerDtoUI>>(allTrainersDtoBL);
            return new JsonResult(allTrainerDtoUI);
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> GetTrainerById([FromRoute] AcceptGetTrainerDtoUI getTrainerDtoUI)
        {
            if (getTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var trainerDtoBL = await trainerCrudBL.GetTrainer(getTrainerDtoUI.Id);

            if (trainerDtoBL is null)
                throw new ElementByIdNotFoundException();

            var trainerDtoUI = ReadTrainerMapperUI.Map<ResponseGetTrainerDtoUI>(trainerDtoBL);
            return new JsonResult(trainerDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTrainer([FromBody] AcceptCreateTrainerDtoUI createTrainerDtoUI)
        {
            if (createTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainerBL = CreateTrainerMapperUI.Map<CreateTrainerDtoBL>(createTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.CreateTrainer(createTrainerBL);
            var trainerDtoUI = CreateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTrainer([FromBody] AcceptUpdateTrainerDtoUI updateTrainerDtoUI)
        {
            if (updateTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainerBL = UpdateTrainerMapperUI.Map<UpdateTrainerDtoBL>(updateTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.UpdateTrainer(updateTrainerBL);
            var trainerDtoUI = UpdateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteTrainer([FromRoute] AcceptDeleteTrainerDtoUI deleteTrainerDtoUI)
        {
            if(deleteTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            await trainerCrudBL.DeleteTrainer(deleteTrainerDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
