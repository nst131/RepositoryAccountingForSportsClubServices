using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ServiceBLL.Aggregator;
using ServiceAccountingBL.Models.ServiceBLL.Crud;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Fetchers;
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
        public async Task<ActionResult<ICollection<ResponseGetServiceDtoUI>>> GetAll()
        {
            var allServicesDtoBL = await serviceFetchers.GetServiceAll();

            if (allServicesDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allServiceDtoUI = ReadServiceMapperUI.Map<ICollection<ResponseGetServiceDtoUI>>(allServicesDtoBL);
            return new JsonResult(allServiceDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetServiceDtoUI>> Get([FromRoute] AcceptGetServiceDtoUI acceptGetServiceDtoUI)
        {
            if (acceptGetServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var serviceDtoBL = await serviceCrudBL.GetService(Convert.ToInt32(acceptGetServiceDtoUI.Id));

            if (serviceDtoBL is null)
                throw new ElementByIdNotFoundException();

            var serviceDtoUI = ReadServiceMapperUI.Map<ResponseGetServiceDtoUI>(serviceDtoBL);
            return new JsonResult(serviceDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseServiceDtoUI>> Create([FromBody] AcceptCreateServiceDtoUI createServiceDtoUI)
        {
            if (createServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var createServiceBL = CreateServiceMapperUI.Map<AcceptCreateServiceDtoBL>(createServiceDtoUI);
            var serviceDtoBL = await serviceCrudBL.CreateService(createServiceBL);
            var serviceDtoUI = CreateServiceMapperUI.Map<ResponseServiceDtoUI>(serviceDtoBL);

            return new JsonResult(serviceDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseServiceDtoUI>> Update([FromBody] AcceptUpdateServiceDtoUI updateServiceDtoUI)
        {
            if (updateServiceDtoUI is null)
                throw new ElementNullReferenceException();

            var updateServiceBL = UpdateServiceMapperUI.Map<AcceptUpdateServiceDtoBL>(updateServiceDtoUI);
            var serviceDtoBL = await serviceCrudBL.UpdateService(updateServiceBL);
            var serviceDtoUI = UpdateServiceMapperUI.Map<ResponseGetServiceDtoUI>(serviceDtoBL);

            return new JsonResult(serviceDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteServiceDtoUI deleteServiceDtoUI)
        {
            if (deleteServiceDtoUI is null)
                throw new ElementNullReferenceException();

            await serviceCrudBL.DeleteService(deleteServiceDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
