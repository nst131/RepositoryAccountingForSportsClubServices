using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Models;
using RabbitMQLibrary;
using ServiceAccountingBL.Models.CommonBL;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingDA.Models;
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
        private readonly ICommonFetchers commonFetchers;
        private readonly ITrainerFetchersBL trainerFetchersBL;
        private readonly IEventBus eventBus;
        private readonly IMapper mapper;

        public TrainerController(IAggregatorTrainerBL aggregatorTrainerBL, IEventBus eventBus, ICommonFetchers commonFetchers, IMapper mapper)
        {
            this.eventBus = eventBus;
            this.commonFetchers = commonFetchers;
            this.mapper = mapper;
            this.trainerCrudBL = aggregatorTrainerBL.TrainerCrudBL;
            this.trainerFetchersBL = aggregatorTrainerBL.TrainerFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetTrainerDtoUI>>> GetAll(CancellationToken token)
        {
            var allTrainersDtoBL = await trainerFetchersBL.GetTrainerAll(token);

            if (allTrainersDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allTrainerDtoUI = ReadTrainerMapperUI.Map<ICollection<ResponseGetTrainerDtoUI>>(allTrainersDtoBL);
            return new JsonResult(allTrainerDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetTrainerDtoUI>> Get([FromRoute] AcceptGetTrainerDtoUI getTrainerDtoUI, CancellationToken token)
        {
            if (getTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var trainerDtoBL = await trainerCrudBL.GetTrainer(getTrainerDtoUI.Id, token);

            if (trainerDtoBL is null)
                throw new ElementByIdNotFoundException();

            var trainerDtoUI = ReadTrainerMapperUI.Map<ResponseGetTrainerDtoUI>(trainerDtoBL);
            return new JsonResult(trainerDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseTrainerDtoUI>> Create([FromBody] AcceptCreateTrainerDtoUI createTrainerDtoUI, CancellationToken token)
        {
            if (createTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var createTrainerBL = CreateTrainerMapperUI.Map<AcceptCreateTrainerDtoBL>(createTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.CreateTrainer(createTrainerBL, token);
            var trainerDtoUI = CreateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ActionResult<ResponseTrainerDtoUI>> Update([FromBody] AcceptUpdateTrainerDtoUI updateTrainerDtoUI, CancellationToken token)
        {
            if (updateTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var updateTrainerBL = UpdateTrainerMapperUI.Map<AcceptUpdateTrainerDtoBL>(updateTrainerDtoUI);
            var trainerDtoBL = await trainerCrudBL.UpdateTrainer(updateTrainerBL, token);
            var trainerDtoUI = UpdateTrainerMapperUI.Map<ResponseTrainerDtoUI>(trainerDtoBL);

            return new JsonResult(trainerDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteTrainerDtoUI deleteTrainerDtoUI, CancellationToken token)
        {
            if (deleteTrainerDtoUI is null)
                throw new ElementNullReferenceException();

            var email = await this.commonFetchers.GetEmailById<Trainer>(deleteTrainerDtoUI.Id, token);

            var deleteonMain = this.trainerCrudBL.DeleteTrainer(deleteTrainerDtoUI.Id, token);
            var deleteOnAuth = this.eventBus.Publish(new DeleteUserModel() { Email = email });

            await Task.WhenAll(deleteonMain, deleteOnAuth);

            return new JsonResult("Delete was success");
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<int?> GetIdByEmail([FromBody] AcceptGetTrainerIdByEmail acceptGetIdByEmail, CancellationToken token)
        {
            var id = await this.commonFetchers.GetIdByEmail<Trainer>(acceptGetIdByEmail.Email, token);

            return id is (int)ErrorCode.None ? null : id;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Trainer)]
        public async Task<ResponseGetServiceByTrainerIdDtoUI> GetServiceByTrainerId([FromBody] AcceptGetServiceByTrainerIdDtoUI acceptGetService, CancellationToken token)
        {
            var serviceBL = await this.trainerFetchersBL.GetServiceByTrainerId(acceptGetService.Id, token);

            return this.mapper.Map<ResponseGetServiceByTrainerIdDtoUI>(serviceBL);
        }
    }
}
