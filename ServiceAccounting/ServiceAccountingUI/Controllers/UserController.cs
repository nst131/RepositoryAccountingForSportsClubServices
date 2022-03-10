using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using RabbitMQLibrary;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingBL.Models.CommonBL;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.ClientUI.Dto;
using ServiceAccountingUI.Models.ClientUI.Mapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientCrudBL clientCrudBL;
        private readonly ICommonFetchers commonFetchers;
        private readonly IClientFetchersBL clientFetchers;
        private readonly IEventBus eventBus;

        public UserController(IAggregatorClientBL aggregatorClientBL, IEventBus eventBus, ICommonFetchers commonFetchers)
        {
            this.eventBus = eventBus;
            this.commonFetchers = commonFetchers;
            this.clientCrudBL = aggregatorClientBL.ClientCrudBL;
            this.clientFetchers = aggregatorClientBL.ClientFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetClientDtoUI>>> GetAll(CancellationToken token)
        {
            var allClientsDtoBL = await clientFetchers.GetClientAll(token);

            if (allClientsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClientDtoUI = ReadClientMapperUI.Map<ICollection<ResponseGetClientDtoUI>>(allClientsDtoBL);
            return new JsonResult(allClientDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetClientDtoUI>> Get([FromRoute] AcceptGetClientDtoUI acceptGetClientDtoUI, CancellationToken token)
        {
            if (acceptGetClientDtoUI is null)
                throw new ElementNullReferenceException();

            var clientDtoBL = await clientCrudBL.GetClient(acceptGetClientDtoUI.Id, token);

            if (clientDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clientDtoUI = ReadClientMapperUI.Map<ResponseGetClientDtoUI>(clientDtoBL);
            return new JsonResult(clientDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ResponseClientDtoUI>> Create([FromBody] AcceptCreateClientDtoUI createClientDtoUI, CancellationToken token)
        {
            if (createClientDtoUI is null)
                throw new ElementNullReferenceException();

            var createClientBL = CreateClientMapperUI.Map<AcceptCreateClientDtoBL>(createClientDtoUI);
            var clientDtoBL = await clientCrudBL.CreateClient(createClientBL, token);
            var clientDtoUI = CreateClientMapperUI.Map<ResponseClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ResponseClientDtoUI>> Update([FromBody] AcceptUpdateClientDtoUI updateClientDtoUI, CancellationToken token)
        {
            if (updateClientDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClientBL = UpdateClientMapperUI.Map<AcceptUpdateClientDtoBL>(updateClientDtoUI);
            var clientDtoBL = await clientCrudBL.UpdateClient(updateClientBL, token);
            var clientDtoUI = UpdateClientMapperUI.Map<ResponseClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteClientDtoUI deleteClientDtoUI, CancellationToken token)
        {
            if (deleteClientDtoUI is null)
                throw new ElementNullReferenceException();

            var email = await this.commonFetchers.GetEmailById<Client>(deleteClientDtoUI.Id, token);

            var deleteonMain = this.clientCrudBL.DeleteClient(deleteClientDtoUI.Id, token);
            var deleteOnAuth = this.eventBus.Publish(new DeleteUserModel() { Email = email });

            await Task.WhenAll(deleteonMain, deleteOnAuth);

            return new JsonResult("Delete From Main");
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<int?> GetIdByEmail([FromBody] AcceptGetUserIdByEmail acceptGetIdByEmail, CancellationToken token)
        {
            var id = await this.commonFetchers.GetIdByEmail<Client>(acceptGetIdByEmail.Email, token);

            return id is (int)ErrorCode.None ? null : id;
        }
    }
}
