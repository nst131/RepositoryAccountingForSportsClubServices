using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Crud;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Fetchers;
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
        public async Task<ActionResult<ICollection<ResponseGetDealDtoUI>>> GetAll()
        {
            var allDealsDtoBL = await dealFetchers.GetDealAll();

            if (allDealsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allDealDtoUI = ReadDealMapperUI.Map<ICollection<ResponseGetDealDtoUI>>(allDealsDtoBL);
            return new JsonResult(allDealDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetDealDtoUI>> Get([FromRoute] AcceptGetDealDtoUI acceptGetDealDtoUI)
        {
            if (acceptGetDealDtoUI is null)
                throw new ElementNullReferenceException();

            var dealDtoBL = await dealCrudBL.GetDeal(Convert.ToInt32(acceptGetDealDtoUI.Id));

            if (dealDtoBL is null)
                throw new ElementByIdNotFoundException();

            var dealDtoUI = ReadDealMapperUI.Map<ResponseGetDealDtoUI>(dealDtoBL);
            return new JsonResult(dealDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseDealDtoUI>> Create([FromBody] AcceptCreateDealDtoUI createDealDtoUI)
        {
            if (createDealDtoUI is null)
                throw new ElementNullReferenceException();

            var createDealBL = CreateDealMapperUI.Map<AcceptCreateDealDtoBL>(createDealDtoUI);
            var dealDtoBL = await dealCrudBL.CreateDeal(createDealBL);
            var dealDtoUI = CreateDealMapperUI.Map<ResponseDealDtoUI>(dealDtoBL);

            return new JsonResult(dealDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseDealDtoUI>> Update([FromBody] AcceptUpdateDealDtoUI updateDealDtoUI)
        {
            if (updateDealDtoUI is null)
                throw new ElementNullReferenceException();

            var updateDealBL = UpdateDealMapperUI.Map<AcceptUpdateDealDtoBL>(updateDealDtoUI);
            var dealDtoBL = await dealCrudBL.UpdateDeal(updateDealBL);
            var dealDtoUI = UpdateDealMapperUI.Map<ResponseGetDealDtoUI>(dealDtoBL);

            return new JsonResult(dealDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteDealDtoUI deleteDealDtoUI)
        {
            if (deleteDealDtoUI is null)
                throw new ElementNullReferenceException();

            await dealCrudBL.DeleteDeal(deleteDealDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
