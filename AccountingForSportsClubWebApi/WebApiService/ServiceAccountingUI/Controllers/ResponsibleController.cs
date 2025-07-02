using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Models;
using RabbitMQLibrary;
using ServiceAccountingBL.Models.CommonBL;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleCrudBL responsibleCrudBL;
        private readonly ICommonFetchers commonFetchers;
        private readonly IResponsibleFetchersBL ResponsibleFetchersBl;
        private readonly IEventBus eventBus;

        public ResponsibleController(IAggregatorResponsibleBL aggregatorResponsibleBL, ICommonFetchers commonFetchers, IEventBus eventBus)
        {
            this.commonFetchers = commonFetchers;
            this.eventBus = eventBus;
            this.responsibleCrudBL = aggregatorResponsibleBL.ResponsibleCrudBL;
            this.ResponsibleFetchersBl = aggregatorResponsibleBL.ResponsibleFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetResponsibleDtoUI>>> GetAll(CancellationToken token)
        {
            var allResponsiblesDtoBL = await ResponsibleFetchersBl.GetResponsibleAll(token);

            if (allResponsiblesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allResponsibleDtoUI = ReadResponsibleMapperUI.Map<ICollection<ResponseGetResponsibleDtoUI>>(allResponsiblesDtoBL);
            return new JsonResult(allResponsibleDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetResponsibleDtoUI>> Get([FromRoute] AcceptGetResponsibleDtoUI getResponsibleDtoUI, CancellationToken token)
        {
            if (getResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var responsibleDtoBL = await responsibleCrudBL.GetResponsible(getResponsibleDtoUI.Id, token);

            if (responsibleDtoBL is null)
                throw new ElementByIdNotFoundException();

            var responsibleDtoUI = ReadResponsibleMapperUI.Map<ResponseGetResponsibleDtoUI>(responsibleDtoBL);
            return new JsonResult(responsibleDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseResponsibleDtoUI>> Create([FromBody] AcceptCreateResponsibleDtoUI createResponsibleDtoUI, CancellationToken token)
        {
            if (createResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var createResponsibleBL = CreateResponsibleMapperUI.Map<AcceptCreateResponsibleDtoBL>(createResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.CreateResponsible(createResponsibleBL, token);
            var responsibleDtoUI = CreateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<ActionResult<ResponseResponsibleDtoUI>> Update([FromBody] AcceptUpdateResponsibleDtoUI updateResponsibleDtoUI, CancellationToken token)
        {
            if (updateResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var updateResponsibleBL = UpdateResponsibleMapperUI.Map<AcceptUpdateResponsibleDtoBL>(updateResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.UpdateResponsible(updateResponsibleBL, token);
            var responsibleDtoUI = UpdateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteResponsibleDtoUI deleteResponsibleDtoUI, CancellationToken token)
        {
            if(deleteResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var email = await this.commonFetchers.GetEmailById<Responsible>(deleteResponsibleDtoUI.Id, token);

            var deleteonMain = this.responsibleCrudBL.DeleteResponsible(deleteResponsibleDtoUI.Id, token);
            var deleteOnAuth = this.eventBus.Publish(new DeleteUserModel() { Email = email });

            await Task.WhenAll(deleteonMain, deleteOnAuth);

            return new JsonResult("Delete was success");
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<int?> GetIdByEmail([FromBody] AcceptGetResponsibleIdByEmail acceptGetIdByEmail, CancellationToken token)
        {
            var id = await this.commonFetchers.GetIdByEmail<Responsible>(acceptGetIdByEmail.Email, token);

            return id is (int)ErrorCode.None ? null : id;
        }
    }
}
