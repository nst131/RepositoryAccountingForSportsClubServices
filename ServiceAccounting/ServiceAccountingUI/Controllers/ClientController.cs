using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingUI.ClientUI.Dto;
using ServiceAccountingUI.ClientUI.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientCrudBL clientCrudBL;

        public ClientController(IAggregatorClientBL aggregatorClientBL)
        {
            this.clientCrudBL = aggregatorClientBL.ClientCrudBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            var clientDtoBL = await clientCrudBL.GetClient(clientId);

            if (clientDtoBL is null)
                throw new ElementByIdNotFoundException();

            var clientDtoUI = GetGlientMapperUI.Map<GetClientDtoUI>(clientDtoBL);
            return new JsonResult(clientDtoUI);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllClients()
        {
            var allClientsDtoBL = await clientCrudBL.GetClientAll();

            if (allClientsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allClientDtoUI = GetGlientMapperUI.Map<ICollection<GetClientDtoUI>>(allClientsDtoBL);
            return new JsonResult(allClientDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateClient(CreateClientDtoUI createClientDtoUI)
        {
            if (createClientDtoUI is null)
                throw new ElementNullReferenceException();

            var createClientBL = CreateClientMapperUI.Map<CreateClientDtoBL>(createClientDtoUI);
            var clientDtoBL =  await clientCrudBL.CreateClient(createClientBL);
            var clientDtoUI = CreateClientMapperUI.Map<ClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateClient(UpdateClientDtoUI updateClientDtoUI)
        {
            if (updateClientDtoUI is null)
                throw new ElementNullReferenceException();

            var updateClientBL = UpdateClientMapperUI.Map<UpdateClientDtoBL>(updateClientDtoUI);
            var clientDtoBL = await clientCrudBL.UpdateClient(updateClientBL);
            var clientDtoUI = UpdateClientMapperUI.Map<ClientDtoUI>(clientDtoBL);

            return new JsonResult(clientDtoUI);
        }
    }
}
