using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleCrudBL responsibleCrudBL;
        private readonly IResponsibleFetchersBL responsibleFetchersBL;

        public ResponsibleController(IAggregatorResponsibleBL aggregatorResponsibleBL)
        {
            this.responsibleCrudBL = aggregatorResponsibleBL.ResponsibleCrudBL;
            this.responsibleFetchersBL = aggregatorResponsibleBL.ResponsibleFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllResponsibles()
        {
            var allResponsiblesDtoBL = await responsibleFetchersBL.GetResponsibleAll();

            if (allResponsiblesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allResponsibleDtoUI = ReadResponsibleMapperUI.Map<ICollection<ResponseGetResponsibleDtoUI>>(allResponsiblesDtoBL);
            return new JsonResult(allResponsibleDtoUI);
        }

        [HttpPost]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetResponsibleById([FromRoute] AcceptGetResponsibleDtoUI getResponsibleDtoUI)
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
        public async Task<IActionResult> CreateResponsible([FromBody] AcceptCreateResponsibleDtoUI createResponsibleDtoUI)
        {
            if (createResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var createResponsibleBL = CreateResponsibleMapperUI.Map<CreateResponsibleDtoBL>(createResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.CreateResponsible(createResponsibleBL);
            var responsibleDtoUI = CreateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateResponsible([FromBody] AcceptUpdateResponsibleDtoUI updateResponsibleDtoUI)
        {
            if (updateResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var updateResponsibleBL = UpdateResponsibleMapperUI.Map<UpdateResponsibleDtoBL>(updateResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.UpdateResponsible(updateResponsibleBL);
            var responsibleDtoUI = UpdateResponsibleMapperUI.Map<ResponseResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteResponsible([FromRoute] AcceptDeleteResponsibleDtoUI deleteResponsibleDtoUI)
        {
            if(deleteResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            await responsibleCrudBL.DeleteResponsible(deleteResponsibleDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
