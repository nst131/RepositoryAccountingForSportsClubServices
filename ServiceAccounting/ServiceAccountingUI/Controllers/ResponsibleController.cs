using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.ResponsibleBLL.Crud;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingUI.ResponsibleUI.Dto;
using ServiceAccountingUI.ResponsibleUI.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleCrudBL responsibleCrudBL;

        public ResponsibleController(IAggregatorResponsibleBL aggregatorResponsibleBL)
        {
            this.responsibleCrudBL = aggregatorResponsibleBL.ResponsibleCrudBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetResponsibleById(int responsibleId)
        {
            var responsibleDtoBL = await responsibleCrudBL.GetResponsible(responsibleId);

            if (responsibleDtoBL is null)
                throw new ElementByIdNotFoundException();

            var responsibleDtoUI = GetResponsibleMapperUI.Map<GetResponsibleDtoUI>(responsibleDtoBL);
            return new JsonResult(responsibleDtoUI);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllResponsibles()
        {
            var allResponsiblesDtoBL = await responsibleCrudBL.GetResponsibleAll();

            if (allResponsiblesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allResponsibleDtoUI = GetResponsibleMapperUI.Map<ICollection<GetResponsibleDtoUI>>(allResponsiblesDtoBL);
            return new JsonResult(allResponsibleDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateResponsible(CreateResponsibleDtoUI createResponsibleDtoUI)
        {
            if (createResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var createResponsibleBL = CreateResponsibleMapperUI.Map<CreateResponsibleDtoBL>(createResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.CreateResponsible(createResponsibleBL);
            var responsibleDtoUI = CreateResponsibleMapperUI.Map<ResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateResponsible(UpdateResponsibleDtoUI updateResponsibleDtoUI)
        {
            if (updateResponsibleDtoUI is null)
                throw new ElementNullReferenceException();

            var updateResponsibleBL = UpdateResponsibleMapperUI.Map<UpdateResponsibleDtoBL>(updateResponsibleDtoUI);
            var responsibleDtoBL = await responsibleCrudBL.UpdateResponsible(updateResponsibleBL);
            var responsibleDtoUI = UpdateResponsibleMapperUI.Map<ResponsibleDtoUI>(responsibleDtoBL);

            return new JsonResult(responsibleDtoUI);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteResponsible(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException();

            await responsibleCrudBL.DeleteResponsible(id);

            return new JsonResult("Delete was success");
        }
    }
}
