using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.ClubCardBLL.Aggregator;
using ServiceAccountingBL.ClubCardBLL.Crud;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingUI.ClubCardUI.Dto;
using ServiceAccountingUI.ClubCardUI.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubCardController : ControllerBase
    {
        private readonly IClubCardCrudBL clubCardCrudBL;

        public ClubCardController(IAggregatorClubCardBL aggregatorClubCardBL)
        {
            this.clubCardCrudBL = aggregatorClubCardBL.ClubCardCrudBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetClubCardById(int clubCardId)
        {
            var clubCardDtoBL = await clubCardCrudBL.GetClubCard(clubCardId);

            if (clubCardDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clubCardDtoUI = GetClubCardMapperUI.Map<GetClubCardDtoUI>(clubCardDtoBL);
            return new JsonResult(clubCardDtoUI);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllClubCards()
        {
            var allClubCardsDtoBL = await clubCardCrudBL.GetClubCardAll();

            if (allClubCardsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClubCardDtoUI = GetClubCardMapperUI.Map<ICollection<GetClubCardDtoUI>>(allClubCardsDtoBL);
            return new JsonResult(allClubCardDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateClubCard(CreateClubCardDtoUI createClubCardDtoUI)
        {
            if (createClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            var createClubCardBL = CreateClubCardMapperUI.Map<CreateClubCardDtoBL>(createClubCardDtoUI);
            var clubCardDtoBL = await clubCardCrudBL.CreateClubCard(createClubCardBL);
            var clubCardDtoUI = CreateClubCardMapperUI.Map<ClubCardDtoUI>(clubCardDtoBL);

            return new JsonResult(clubCardDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateClubCard(UpdateClubCardDtoUI updateClubCardDtoUI)
        {
            if (updateClubCardDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClubCardBL = UpdateClubCardMapperUI.Map<UpdateClubCardDtoBL>(updateClubCardDtoUI);
            var clubCardDtoBL = await clubCardCrudBL.UpdateClubCard(updateClubCardBL);
            var clubCardDtoUI = UpdateClubCardMapperUI.Map<ClubCardDtoUI>(clubCardDtoBL);

            return new JsonResult(clubCardDtoUI);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteClubCard(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException();

            await clubCardCrudBL.DeleteClubCard(id);

            return new JsonResult("Delete was success");
        }
    }
}
