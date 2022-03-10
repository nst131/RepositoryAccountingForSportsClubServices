using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Crud;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.DealUI.Dto;
using ServiceAccountingUI.Models.DealUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealCrudBL dealCrudBL;
        private readonly IDealFetchersBL dealFetchers;

        public DealController(IAggregatorDealBL aggregatorDealBL)
        {
            this.dealCrudBL = aggregatorDealBL.DealCrudBL;
            this.dealFetchers = aggregatorDealBL.DealFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetDealDtoUI>>> GetAll(CancellationToken token)
        {
            var allDealsDtoBL = await dealFetchers.GetDealAll(token);

            if (allDealsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allDealDtoUI = ReadDealMapperUI.Map<ICollection<ResponseGetDealDtoUI>>(allDealsDtoBL);
            return new JsonResult(allDealDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetDealDtoUI>> Get([FromRoute] AcceptGetDealDtoUI acceptGetDealDtoUI, CancellationToken token)
        {
            if (acceptGetDealDtoUI is null)
                throw new ElementNullReferenceException();

            var dealDtoBL = await dealCrudBL.GetDeal(acceptGetDealDtoUI.Id, token);

            if (dealDtoBL is null)
                throw new ElementByIdNotFoundException();

            var dealDtoUI = ReadDealMapperUI.Map<ResponseGetDealDtoUI>(dealDtoBL);
            return new JsonResult(dealDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<ActionResult<ResponseDealDtoUI>> Create([FromBody] AcceptCreateDealDtoUI createDealDtoUI, CancellationToken token)
        {
            if (createDealDtoUI is null)
                throw new ElementNullReferenceException();

            var createDealBL = CreateDealMapperUI.Map<AcceptCreateDealDtoBL>(createDealDtoUI);
            var dealDtoBL = await dealCrudBL.CreateDeal(createDealBL, token);
            var dealDtoUI = CreateDealMapperUI.Map<ResponseDealDtoUI>(dealDtoBL);

            return new JsonResult(dealDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<ActionResult<ResponseDealDtoUI>> Update([FromBody] AcceptUpdateDealDtoUI updateDealDtoUI, CancellationToken token)
        {
            if (updateDealDtoUI is null)
                throw new ElementNullReferenceException();

            var updateDealBL = UpdateDealMapperUI.Map<AcceptUpdateDealDtoBL>(updateDealDtoUI);
            var dealDtoBL = await dealCrudBL.UpdateDeal(updateDealBL, token);
            var dealDtoUI = UpdateDealMapperUI.Map<ResponseDealDtoUI>(dealDtoBL);

            return new JsonResult(dealDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteDealDtoUI deleteDealDtoUI, CancellationToken token)
        {
            if (deleteDealDtoUI is null)
                throw new ElementNullReferenceException();

            await dealCrudBL.DeleteDeal(deleteDealDtoUI.Id, token);

            return new JsonResult("Delete was success");
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Responsible)]
        public async Task<ActionResult<int>> GetResponsibleIdByDealId([FromRoute] AcceptGetResponsibleIdBtDealIdDtoUI acceptResponsibleIdBtDealIdDtoUI, CancellationToken token)
        {
            var responsibleId = await dealFetchers.GetResponsibleIdByDealId(acceptResponsibleIdBtDealIdDtoUI.Id, token);
            return responsibleId;
        }
    }
}
