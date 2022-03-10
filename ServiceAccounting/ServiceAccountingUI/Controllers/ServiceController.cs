using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ServiceBLL.Aggregator;
using ServiceAccountingBL.Models.ServiceBLL.Crud;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.ServiceUI.Dto;
using ServiceAccountingUI.Models.ServiceUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceCrudBL serviceCrudBL;
        private readonly IServiceFetchersBL serviceFetchers;

        public ServiceController(IAggregatorServiceBL aggregatorServiceBL)
        {
            this.serviceCrudBL = aggregatorServiceBL.ServiceCrudBL;
            this.serviceFetchers = aggregatorServiceBL.ServiceFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetServiceDtoUI>>> GetAll(CancellationToken token)
        {
            var allServicesDtoBL = await serviceFetchers.GetServiceAll(token);

            if (allServicesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allServiceDtoUI = ReadServiceMapperUI.Map<ICollection<ResponseGetServiceDtoUI>>(allServicesDtoBL);
            return new JsonResult(allServiceDtoUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetServiceDtoUI>> Get([FromRoute] AcceptGetServiceDtoUI acceptGetServiceDtoUI, CancellationToken token)
        {
            if (acceptGetServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var serviceDtoBL = await serviceCrudBL.GetService(acceptGetServiceDtoUI.Id, token);

            if (serviceDtoBL is null)
                throw new ElementByIdNotFoundException();

            var serviceDtoUI = ReadServiceMapperUI.Map<ResponseGetServiceDtoUI>(serviceDtoBL);
            return new JsonResult(serviceDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseServiceDtoUI>> Create([FromBody] AcceptCreateServiceDtoUI createServiceDtoUI, CancellationToken token)
        {
            if (createServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var createServiceBL = CreateServiceMapperUI.Map<AcceptCreateServiceDtoBL>(createServiceDtoUI);
            var serviceDtoBL = await serviceCrudBL.CreateService(createServiceBL, token);
            var serviceDtoUI = CreateServiceMapperUI.Map<ResponseServiceDtoUI>(serviceDtoBL);

            return new JsonResult(serviceDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseServiceDtoUI>> Update([FromBody] AcceptUpdateServiceDtoUI updateServiceDtoUI, CancellationToken token)
        {
            if (updateServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var updateServiceBL = UpdateServiceMapperUI.Map<AcceptUpdateServiceDtoBL>(updateServiceDtoUI);
            var serviceDtoBL = await serviceCrudBL.UpdateService(updateServiceBL, token);
            var serviceDtoUI = UpdateServiceMapperUI.Map<ResponseServiceDtoUI>(serviceDtoBL);

            return new JsonResult(serviceDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteServiceDtoUI deleteServiceDtoUI, CancellationToken token)
        {
            if (deleteServiceDtoUI is null)
                throw new ElementNullReferenceException();

            await serviceCrudBL.DeleteService(deleteServiceDtoUI.Id, token);

            return new JsonResult("Delete was success");
        }
    }
}
