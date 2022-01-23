using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
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
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetTrainerDtoUI>>> GetAll()
        {
            var allTrainersDtoBL = await trainerFetchersBL.GetTrainerAll();

            if (allTrainersDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainerDtoUI = ReadTrainerMapperUI.Map<ICollection<ResponseGetTrainerDtoUI>>(allTrainersDtoBL);
            return new JsonResult(allTrainerDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetTrainerDtoUI>> Get([FromRoute] AcceptGetTrainerDtoUI getTrainerDtoUI)
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
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseTrainerDtoUI>> Create([FromBody] AcceptCreateTrainerDtoUI createTrainerDtoUI)
        {
            if (createTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainerBL = CreateTrainerMapperUI.Map<AcceptCreateTrainerDtoBL>(createTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.CreateTrainer(createTrainerBL);
            var trainerDtoUI = CreateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ActionResult<ResponseTrainerDtoUI>> Update([FromBody] AcceptUpdateTrainerDtoUI updateTrainerDtoUI)
        {
            if (updateTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainerBL = UpdateTrainerMapperUI.Map<AcceptUpdateTrainerDtoBL>(updateTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.UpdateTrainer(updateTrainerBL);
            var trainerDtoUI = UpdateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteTrainerDtoUI deleteTrainerDtoUI)
        {
            if(deleteTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            await trainerCrudBL.DeleteTrainer(deleteTrainerDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
