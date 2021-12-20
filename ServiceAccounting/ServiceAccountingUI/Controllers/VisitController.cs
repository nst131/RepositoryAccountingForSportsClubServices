using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.VisitBLL.Aggregator;
using ServiceAccountingBL.Models.VisitBLL.Crud;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Fetchers;
using ServiceAccountingUI.Models.VisitUI.Dto;
using ServiceAccountingUI.Models.VisitUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitCrudBL visitCrudBL;
        private readonly IVisitFetchersBL visitFetchers;

        public VisitController(IAggregatorVisitBL aggregatorVisitBL)
        {
            this.visitCrudBL = aggregatorVisitBL.VisitCrudBL;
            this.visitFetchers = aggregatorVisitBL.VisitFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetVisitDtoUI>>> GetAll()
        {
            var allVisitsDtoBL = await visitFetchers.GetVisitAll();

            if (allVisitsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allVisitDtoUI = ReadVisitMapperUI.Map<ICollection<ResponseGetVisitDtoUI>>(allVisitsDtoBL);
            return new JsonResult(allVisitDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetVisitDtoUI>> Get([FromRoute] AcceptGetVisitDtoUI acceptGetVisitDtoUI)
        {
            if (acceptGetVisitDtoUI is null)
                throw new ElementNullReferenceException();

            var visitDtoBL = await visitCrudBL.GetVisit(Convert.ToInt32(acceptGetVisitDtoUI.Id));

            if (visitDtoBL is null)
                throw new ElementByIdNotFoundException();

            var visitDtoUI = ReadVisitMapperUI.Map<ResponseGetVisitDtoUI>(visitDtoBL);
            return new JsonResult(visitDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseVisitDtoUI>> Create([FromBody] AcceptCreateVisitDtoUI createVisitDtoUI)
        {
            if (createVisitDtoUI is null)
                throw new ElementNullReferenceException();

            var createVisitBL = CreateVisitMapperUI.Map<AcceptCreateVisitDtoBL>(createVisitDtoUI);
            var visitDtoBL = await visitCrudBL.CreateVisit(createVisitBL);
            var visitDtoUI = CreateVisitMapperUI.Map<ResponseVisitDtoUI>(visitDtoBL);

            return new JsonResult(visitDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseVisitDtoUI>> Update([FromBody] AcceptUpdateVisitDtoUI updateVisitDtoUI)
        {
            if (updateVisitDtoUI is null)
                throw new ElementNullReferenceException();

            var updateVisitBL = UpdateVisitMapperUI.Map<AcceptUpdateVisitDtoBL>(updateVisitDtoUI);
            var visitDtoBL = await visitCrudBL.UpdateVisit(updateVisitBL);
            var visitDtoUI = UpdateVisitMapperUI.Map<ResponseGetVisitDtoUI>(visitDtoBL);

            return new JsonResult(visitDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteVisitDtoUI deleteVisitDtoUI)
        {
            if (deleteVisitDtoUI is null)
                throw new ElementNullReferenceException();

            await visitCrudBL.DeleteVisit(deleteVisitDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
