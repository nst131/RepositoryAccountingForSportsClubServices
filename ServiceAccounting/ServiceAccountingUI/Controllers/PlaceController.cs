using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.PlaceBLL.Aggregator;
using ServiceAccountingBL.Models.PlaceBLL.Crud;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.PlaceUI.Dto;
using ServiceAccountingUI.Models.PlaceUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceCrudBL placeCrudBL;
        private readonly IPlaceFetchersBL placeFetchers;

        public PlaceController(IAggregatorPlaceBL aggregatorPlaceBL)
        {
            this.placeCrudBL = aggregatorPlaceBL.PlaceCrudBL;
            this.placeFetchers = aggregatorPlaceBL.PlaceFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetPlaceDtoUI>>> GetAll()
        {
            var allPlacesDtoBL = await placeFetchers.GetPlaceAll();

            if (allPlacesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allPlaceDtoUI = ReadPlaceMapperUI.Map<ICollection<ResponseGetPlaceDtoUI>>(allPlacesDtoBL);
            return new JsonResult(allPlaceDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetPlaceDtoUI>> Get([FromRoute] AcceptGetPlaceDtoUI acceptGetPlaceDtoUI)
        {
            if (acceptGetPlaceDtoUI is null)
                throw new ElementNullReferenceException();

            var placeDtoBL = await placeCrudBL.GetPlace(acceptGetPlaceDtoUI.Id);

            if (placeDtoBL is null)
                throw new ElementByIdNotFoundException();

            var placeDtoUI = ReadPlaceMapperUI.Map<ResponseGetPlaceDtoUI>(placeDtoBL);
            return new JsonResult(placeDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponsePlaceDtoUI>> Create([FromBody] AcceptCreatePlaceDtoUI createPlaceDtoUI)
        {
            if (createPlaceDtoUI is null)
                throw new ElementNullReferenceException();

            var createPlaceBL = CreatePlaceMapperUI.Map<AcceptCreatePlaceDtoBL>(createPlaceDtoUI);
            var placeDtoBL = await placeCrudBL.CreatePlace(createPlaceBL);
            var placeDtoUI = CreatePlaceMapperUI.Map<ResponsePlaceDtoUI>(placeDtoBL);

            return new JsonResult(placeDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseGetPlaceDtoUI>> Update([FromBody] AcceptUpdatePlaceDtoUI updatePlaceDtoUI)
        {
            if (updatePlaceDtoUI is null)
                throw new ElementNullReferenceException();

            var updatePlaceBL = UpdatePlaceMapperUI.Map<AcceptUpdatePlaceDtoBL>(updatePlaceDtoUI);
            var placeDtoBL = await placeCrudBL.UpdatePlace(updatePlaceBL);
            var placeDtoUI = UpdatePlaceMapperUI.Map<ResponsePlaceDtoUI>(placeDtoBL);

            return new JsonResult(placeDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeletePlaceDtoUI deletePlaceDtoUI)
        {
            if (deletePlaceDtoUI is null)
                throw new ElementNullReferenceException();

            await placeCrudBL.DeletePlace(deletePlaceDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
