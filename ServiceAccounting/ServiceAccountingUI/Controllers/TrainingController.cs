using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.TrainingBLL.Aggregator;
using ServiceAccountingBL.Models.TrainingBLL.Crud;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Fetchers;
using ServiceAccountingUI.Models.TrainingUI.Dto;
using ServiceAccountingUI.Models.TrainingUI.Mapper;

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
        public async Task<ActionResult<ICollection<ResponseGetTrainingDtoUI>>> GetAll()
        {
            var allTrainingsDtoBL = await trainingFetchers.GetTrainingAll();

            if (allTrainingsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainingDtoUI = ReadTrainingMapperUI.Map<ICollection<ResponseGetTrainingDtoUI>>(allTrainingsDtoBL);
            return new JsonResult(allTrainingDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetTrainingDtoUI>> Get([FromRoute] AcceptGetTrainingDtoUI acceptGetTrainingDtoUI)
        {
            if (acceptGetTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var trainingDtoBL = await trainingCrudBL.GetTraining(Convert.ToInt32(acceptGetTrainingDtoUI.Id));

            if (trainingDtoBL is null)
                throw new ElementByIdNotFoundException();

            var trainingDtoUI = ReadTrainingMapperUI.Map<ResponseGetTrainingDtoUI>(trainingDtoBL);
            return new JsonResult(trainingDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseTrainingDtoUI>> Create([FromBody] AcceptCreateTrainingDtoUI createTrainingDtoUI)
        {
            if (createTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainingBL = CreateTrainingMapperUI.Map<AcceptCreateTrainingDtoBL>(createTrainingDtoUI);
            var trainingDtoBL = await trainingCrudBL.CreateTraining(createTrainingBL);
            var trainingDtoUI = CreateTrainingMapperUI.Map<ResponseTrainingDtoUI>(trainingDtoBL);

            return new JsonResult(trainingDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseTrainingDtoUI>> Update([FromBody] AcceptUpdateTrainingDtoUI updateTrainingDtoUI)
        {
            if (updateTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainingBL = UpdateTrainingMapperUI.Map<AcceptUpdateTrainingDtoBL>(updateTrainingDtoUI);
            var trainingDtoBL = await trainingCrudBL.UpdateTraining(updateTrainingBL);
            var trainingDtoUI = UpdateTrainingMapperUI.Map<ResponseTrainingDtoUI>(trainingDtoBL);

            return new JsonResult(trainingDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteTrainingDtoUI deleteTrainingDtoUI)
        {
            if (deleteTrainingDtoUI is null)
                throw new ElementNullReferenceException();

            await trainingCrudBL.DeleteTraining(deleteTrainingDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
