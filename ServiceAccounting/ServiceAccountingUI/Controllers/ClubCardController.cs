using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ServiceAccountingBL.Models.ClubCardBLL.Aggregator;
using ServiceAccountingBL.Models.ClubCardBLL.Crud;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.ClubCardUI.Dto;
using ServiceAccountingUI.Models.ClubCardUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClubCardController : ControllerBase
    {
        private readonly IClubCardCrudBL clubCardCrudBL;
        private readonly IClubCardFetchersBL clubCardFetchersBL;

        public ClubCardController(IAggregatorClubCardBL aggregatorClubCardBL)
        {
            this.clubCardCrudBL = aggregatorClubCardBL.ClubCardCrudBL;
            this.clubCardFetchersBL = aggregatorClubCardBL.ClubCardFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetClubCardDtoUI>>> GetAll()
        {
            var allClubCardsDtoBL = await clubCardFetchersBL.GetClubCardAll();

            if (allClubCardsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClubCardDtoUI = ReadClubCardMapperUI.Map<ICollection<ResponseGetClubCardDtoUI>>(allClubCardsDtoBL);
            return new JsonResult(allClubCardDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetClubCardDtoUI>> Get([FromRoute] AcceptGetClubCardDtoUI getClubCardDtoUI)
        {
            if(getClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            var clubCardDtoBL = await clubCardCrudBL.GetClubCard(getClubCardDtoUI.Id);

            if (clubCardDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clubCardDtoUI = ReadClubCardMapperUI.Map<ResponseGetClubCardDtoUI>(clubCardDtoBL);
            return new JsonResult(clubCardDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseClubCardDtoUI>> Create([FromBody] AcceptCreateClubCardDtoUI createClubCardDtoUI)
        {
            if (createClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            var createClubCardBL = CreateClubCardMapperUI.Map<AcceptCreateClubCardDtoBL>(createClubCardDtoUI);
            var clubCardDtoBL = await clubCardCrudBL.CreateClubCard(createClubCardBL);
            var clubCardDtoUI = CreateClubCardMapperUI.Map<ResponseClubCardDtoUI>(clubCardDtoBL);

            return new JsonResult(clubCardDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseClubCardDtoUI>> Update([FromBody] AcceptUpdateClubCardDtoUI updateClubCardDtoUI)
        {
            if (updateClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClubCardBL = UpdateClubCardMapperUI.Map<AcceptUpdateClubCardDtoBL>(updateClubCardDtoUI);
            var clubCardDtoBL = await clubCardCrudBL.UpdateClubCard(updateClubCardBL);
            var clubCardDtoUI = UpdateClubCardMapperUI.Map<ResponseClubCardDtoUI>(clubCardDtoBL);

            return new JsonResult(clubCardDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteClubCardDtoUI deleteClubCardDtoUI)
        {
            if(deleteClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            await clubCardCrudBL.DeleteClubCard(deleteClubCardDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
