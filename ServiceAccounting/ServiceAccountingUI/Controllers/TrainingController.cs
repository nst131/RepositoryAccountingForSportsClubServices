using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.TrainingBLL.Aggregator;
using ServiceAccountingBL.Models.TrainingBLL.Crud;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.TrainingUI.Dto;
using ServiceAccountingUI.Models.TrainingUI.Mapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingCrudBL trainingCrudBL;
        private readonly ITrainingFetchersBL trainingFetchers;

        public TrainingController(IAggregatorTrainingBL aggregatorTrainingBL)
        {
            this.trainingCrudBL = aggregatorTrainingBL.TrainingCrudBL;
            this.trainingFetchers = aggregatorTrainingBL.TrainingFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetTrainingDtoUI>>> GetAll(CancellationToken token)
        {
            var allTrainingsDtoBL = await trainingFetchers.GetTrainingAll(token);

            if (allTrainingsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainingDtoUI = ReadTrainingMapperUI.Map<ICollection<ResponseGetTrainingDtoUI>>(allTrainingsDtoBL);
            return new JsonResult(allTrainingDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetTrainingDtoUI>> Get([FromRoute] AcceptGetTrainingDtoUI acceptGetTrainingDtoUI, CancellationToken token)
        {
            if (acceptGetTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var trainingDtoBL = await trainingCrudBL.GetTraining(acceptGetTrainingDtoUI.Id, token);

            if (trainingDtoBL is null)
                throw new ElementByIdNotFoundException();

            var trainingDtoUI = ReadTrainingMapperUI.Map<ResponseGetTrainingDtoUI>(trainingDtoBL);
            return new JsonResult(trainingDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ActionResult<ResponseTrainingDtoUI>> CreateByClubCard([FromBody] AcceptCreateTrainingDtoUI createTrainingDtoUI, CancellationToken token)
        {
            if (createTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainingBL = CreateTrainingMapperUI.Map<AcceptCreateTrainingDtoBL>(createTrainingDtoUI);
            var trainingDtoBL = await trainingCrudBL.CreateTrainingByClubCard(createTrainingBL, token);
            var trainingDtoUI = CreateTrainingMapperUI.Map<ResponseTrainingDtoUI>(trainingDtoBL);

            return new JsonResult(trainingDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ActionResult<ResponseTrainingDtoUI>> UpdateByClubCard([FromBody] AcceptUpdateTrainingDtoUI updateTrainingDtoUI, CancellationToken token)
        {
            if (updateTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainingBL = UpdateTrainingMapperUI.Map<AcceptUpdateTrainingDtoBL>(updateTrainingDtoUI);
            var trainingDtoBL = await trainingCrudBL.UpdateTrainingByClubCard(updateTrainingBL, token);
            var trainingDtoUI = UpdateTrainingMapperUI.Map<ResponseTrainingDtoUI>(trainingDtoBL);

            return new JsonResult(trainingDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteTrainingDtoUI deleteTrainingDtoUI, CancellationToken token)
        {
            if (deleteTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            await trainingCrudBL.DeleteTraining(deleteTrainingDtoUI.Id, token);

            return new JsonResult("Delete was success");
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ActionResult<int>> GetTrainerIdByTrainingId([FromRoute] AcceptGetTrainerIdByTrainingIdDtoUI acceptGetTrainerIdByTraining, CancellationToken token)
        {
            var responsibleId = await trainingFetchers.GetTrainerIdByTrainingId(acceptGetTrainerIdByTraining.Id, token);
            return responsibleId;
        }
    }
}
