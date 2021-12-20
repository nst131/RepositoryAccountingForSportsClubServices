using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ClientCardBL.Aggregator;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.ClientCardBL.Fetchers;
using ServiceAccountingUI.Models.ClientCardUI.Dto;
using ServiceAccountingUI.Models.ClientCardUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientCardController : ControllerBase
    {
        private readonly IClientCardCrudBL clientCardCrudBL;
        private readonly IClientCardFetchersBL clientCardFetchers;

        public ClientCardController(IAggregatorClientCardBL aggregatorClientCardBL)
        {
            this.clientCardCrudBL = aggregatorClientCardBL.ClientCardCrudBL;
            this.clientCardFetchers = aggregatorClientCardBL.ClientCardFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetClientCardDtoUI>>> GetAll()
        {
            var allClientCardsDtoBL = await clientCardFetchers.GetClientCardAll();

            if (allClientCardsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClientCardDtoUI = ReadClientCardMapperUI.Map<ICollection<ResponseGetClientCardDtoUI>>(allClientCardsDtoBL);
            return new JsonResult(allClientCardDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetClientCardDtoUI>> Get([FromRoute] AcceptGetClientCardDtoUI acceptGetClientCardDtoUI)
        {
            if (acceptGetClientCardDtoUI is null)
                throw new ElementNullReferenceException();

            var clientCardDtoBL = await clientCardCrudBL.GetClientCard(acceptGetClientCardDtoUI.Id);

            if (clientCardDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clientCardDtoUI = ReadClientCardMapperUI.Map<ResponseGetClientCardDtoUI>(clientCardDtoBL);
            return new JsonResult(clientCardDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseClientCardDtoUI>> Create([FromBody] AcceptCreateClientCardDtoUI createClientCardDtoUI)
        {
            if (createClientCardDtoUI is null)
                throw new ElementNullReferenceException();

            var createClientCardBL = CreateClientCardMapperUI.Map<AcceptCreateClientCardDtoBL>(createClientCardDtoUI);
            var clientCardDtoBL = await clientCardCrudBL.CreateClientCard(createClientCardBL);
            var clientCardDtoUI = CreateClientCardMapperUI.Map<ResponseClientCardDtoUI>(clientCardDtoBL);

            return new JsonResult(clientCardDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseClientCardDtoUI>> Update([FromBody] AcceptUpdateClientCardDtoUI updateClientCardDtoUI)
        {
            if (updateClientCardDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClientCardBL = UpdateClientCardMapperUI.Map<AcceptUpdateClientCardDtoBL>(updateClientCardDtoUI);
            var clientCardDtoBL = await clientCardCrudBL.UpdateClientCard(updateClientCardBL);
            var clientCardDtoUI = UpdateClientCardMapperUI.Map<ResponseGetClientCardDtoUI>(clientCardDtoBL);

            return new JsonResult(clientCardDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteClientCardDtoUI deleteClientCardDtoUI)
        {
            if (deleteClientCardDtoUI is null)
                throw new ElementNullReferenceException();

            await clientCardCrudBL.DeleteClientCard(deleteClientCardDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
