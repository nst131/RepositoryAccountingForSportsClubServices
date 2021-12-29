using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.Subscription.Aggregator;
using ServiceAccountingBL.Models.Subscription.Crud;
using ServiceAccountingBL.Models.Subscription.Dto;
using ServiceAccountingBL.Models.Subscription.Fetchers;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Mapper;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionCrudBL subscriptionCrudBL;
        private readonly ISubscriptionFetchersBL subscriptionFetchers;

        public SubscriptionController(IAggregatorSubscriptionBL aggregatorSubscriptionBL)
        {
            this.subscriptionCrudBL = aggregatorSubscriptionBL.SubscriptionCrudBL;
            this.subscriptionFetchers = aggregatorSubscriptionBL.SubscriptionFetchersBL;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetSubscriptionDtoUI>>> GetAll()
        {
            var allSubscriptionsDtoBL = await subscriptionFetchers.GetSubscriptionAll();

            if (allSubscriptionsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allSubscriptionDtoUI = ReadSubscriptionMapperUI.Map<ICollection<ResponseGetSubscriptionDtoUI>>(allSubscriptionsDtoBL);
            return new JsonResult(allSubscriptionDtoUI);
        }

        [HttpPost]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetSubscriptionDtoUI>> Get([FromRoute] AcceptGetSubscriptionDtoUI acceptGetSubscriptionDtoUI)
        {
            if (acceptGetSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var subscriptionDtoBL = await subscriptionCrudBL.GetSubscription(Convert.ToInt32(acceptGetSubscriptionDtoUI.Id));

            if (subscriptionDtoBL is null)
                throw new ElementByIdNotFoundException();

            var subscriptionDtoUI = ReadSubscriptionMapperUI.Map<ResponseGetSubscriptionDtoUI>(subscriptionDtoBL);
            return new JsonResult(subscriptionDtoUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseSubscriptionDtoUI>> Create([FromBody] AcceptCreateSubscriptionDtoUI createSubscriptionDtoUI)
        {
            if (createSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var createSubscriptionBL = CreateSubscriptionMapperUI.Map<AcceptCreateSubscriptionDtoBL>(createSubscriptionDtoUI);
            var subscriptionDtoBL = await subscriptionCrudBL.CreateSubscription(createSubscriptionBL);
            var subscriptionDtoUI = CreateSubscriptionMapperUI.Map<ResponseSubscriptionDtoUI>(subscriptionDtoBL);

            return new JsonResult(subscriptionDtoUI);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ResponseSubscriptionDtoUI>> Update([FromBody] AcceptUpdateSubscriptionDtoUI updateSubscriptionDtoUI)
        {
            if (updateSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var updateSubscriptionBL = UpdateSubscriptionMapperUI.Map<AcceptUpdateSubscriptionDtoBL>(updateSubscriptionDtoUI);
            var subscriptionDtoBL = await subscriptionCrudBL.UpdateSubscription(updateSubscriptionBL);
            var subscriptionDtoUI = UpdateSubscriptionMapperUI.Map<ResponseSubscriptionDtoUI>(subscriptionDtoBL);

            return new JsonResult(subscriptionDtoUI);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteSubscriptionDtoUI deleteSubscriptionDtoUI)
        {
            if (deleteSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            await subscriptionCrudBL.DeleteSubscription(deleteSubscriptionDtoUI.Id);

            return new JsonResult("Delete was success");
        }
    }
}
