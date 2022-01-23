using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
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
        public IResponsibleFetchersBL ResponsibleFetchersBl { get; }

        public ResponsibleController(IAggregatorResponsibleBL aggregatorResponsibleBL)
        {
            this.responsibleCrudBL = aggregatorResponsibleBL.ResponsibleCrudBL;
            this.ResponsibleFetchersBl = aggregatorResponsibleBL.ResponsibleFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetResponsibleDtoUI>>> GetAll()
        {
            var allResponsiblesDtoBL = await ResponsibleFetchersBl.GetResponsibleAll();

            if (allResponsiblesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allResponsibleDtoUI = ReadResponsibleMapperUI.Map<ICollection<ResponseGetResponsibleDtoUI>>(allResponsiblesDtoBL);
            return new JsonResult(allResponsibleDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetResponsibleDtoUI>> Get([FromRoute] AcceptGetResponsibleDtoUI getResponsibleDtoUI)
        {
            if (getResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var responsibleDtoBL = await responsibleCrudBL.GetResponsible(getResponsibleDtoUI.Id);

            if (responsibleDtoBL is null)
                throw new ElementByIdNotFoundException();

            var responsibleDtoUI = ReadResponsibleMapperUI.Map<ResponseGetResponsibleDtoUI>(responsibleDtoBL);
            return new JsonResult(responsibleDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseResponsibleDtoUI>> Create([FromBody] AcceptCreateResponsibleDtoUI createResponsibleDtoUI)
        {
            if (createResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var createResponsibleBL = CreateResponsibleMapperUI.Map<AcceptCreateResponsibleDtoBL>(createResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.CreateResponsible(createResponsibleBL);
            var responsibleDtoUI = CreateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<ActionResult<ResponseResponsibleDtoUI>> Update([FromBody] AcceptUpdateResponsibleDtoUI updateResponsibleDtoUI)
        {
            if (updateResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var updateResponsibleBL = UpdateResponsibleMapperUI.Map<AcceptUpdateResponsibleDtoBL>(updateResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.UpdateResponsible(updateResponsibleBL);
            var responsibleDtoUI = UpdateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteResponsibleDtoUI deleteResponsibleDtoUI)
        {
            if(deleteResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            await responsibleCrudBL.DeleteResponsible(deleteResponsibleDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
