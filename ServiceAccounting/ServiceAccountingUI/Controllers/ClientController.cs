using System;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using System.Threading.Tasks;
using ServiceAccountingUI.Models.ClientUI.Dto;
using ServiceAccountingUI.Models.ClientUI.Mapper;
using System.Collections.Generic;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientCrudBL clientCrudBL;
        private readonly IClientFetchersBL clientFetchers;

        public ClientController(IAggregatorClientBL aggregatorClientBL)
        {
            this.clientCrudBL = aggregatorClientBL.ClientCrudBL;
            this.clientFetchers = aggregatorClientBL.ClientFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetClientDtoUI>>> GetAll()
        {
            var allClientsDtoBL = await clientFetchers.GetClientAll();

            if (allClientsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClientDtoUI = ReadClientMapperUI.Map<ICollection<ResponseGetClientDtoUI>>(allClientsDtoBL);
            return new JsonResult(allClientDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetClientDtoUI>> Get([FromRoute] AcceptGetClientDtoUI acceptGetClientDtoUI)
        {
            if (acceptGetClientDtoUI is null)
                throw new ElementNullReferenceException();

            var clientDtoBL = await clientCrudBL.GetClient(Convert.ToInt32(acceptGetClientDtoUI.Id));

            if (clientDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clientDtoUI = ReadClientMapperUI.Map<ResponseGetClientDtoUI>(clientDtoBL);
            return new JsonResult(clientDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseClientDtoUI>> Create([FromBody] AcceptCreateClientDtoUI createClientDtoUI)
        {
            if (createClientDtoUI is null)
                throw new ElementNullReferenceException();

            var createClientBL = CreateClientMapperUI.Map<AcceptCreateClientDtoBL>(createClientDtoUI);
            var clientDtoBL =  await clientCrudBL.CreateClient(createClientBL);
            var clientDtoUI = CreateClientMapperUI.Map<ResponseClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseClientDtoUI>> Update([FromBody] AcceptUpdateClientDtoUI updateClientDtoUI)
        {
            if (updateClientDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClientBL = UpdateClientMapperUI.Map<AcceptUpdateClientDtoBL>(updateClientDtoUI);
            var clientDtoBL = await clientCrudBL.UpdateClient(updateClientBL);
            var clientDtoUI = UpdateClientMapperUI.Map<ResponseClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteClientDtoUI deleteClientDtoUI)
        {
            if (deleteClientDtoUI is null)
                throw new ElementNullReferenceException();

            await clientCrudBL.DeleteClient(deleteClientDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
