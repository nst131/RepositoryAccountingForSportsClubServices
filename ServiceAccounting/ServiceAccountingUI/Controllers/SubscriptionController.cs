using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedisLibrary;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.SubscriptionBLL.Aggregator;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Request;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionCrudBL subscriptionCrudBL;
        private readonly IRedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL> redisGetElement;
        private readonly IModifierElementsInRedis<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL> redisAddOrUpdateElement;

        public SubscriptionController(IAggregatorSubscriptionBL aggregatorSubscriptionBL,
            IRedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL> redisGetElement,
            IModifierElementsInRedis<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL> redisAddOrUpdateElement)
        {
            this.subscriptionCrudBL = aggregatorSubscriptionBL.SubscriptionCrudBL;
            this.redisGetElement = redisGetElement;
            this.redisAddOrUpdateElement = redisAddOrUpdateElement;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetSubscriptionDtoUI>>> GetAll(
            CancellationToken token)
        {
            var response = await redisGetElement.TryGetElementsAsync(
                SubscriptionRequest.GetAll, token);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetSubscriptionDtoUI>> Get([FromRoute] AcceptGetSubscriptionDtoUI acceptGetSubscriptionDtoUI,
            CancellationToken token)
        {
            if (acceptGetSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var response = await SubscriptionRequest.Get(acceptGetSubscriptionDtoUI,
                subscriptionCrudBL, token);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseGetSubscriptionDtoUI>> Create([FromBody] AcceptCreateSubscriptionDtoUI createSubscriptionDtoUI,
            CancellationToken token)
        {
            if (createSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var response = await this.redisAddOrUpdateElement.TryChangeRedisComponentsAsync(createSubscriptionDtoUI,
                SubscriptionRequest.Add, token);

            return new JsonResult(response);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<ResponseGetSubscriptionDtoUI>> Update([FromBody] AcceptUpdateSubscriptionDtoUI updateSubscriptionDtoUI,
            CancellationToken token)
        {
            if (updateSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var response = await this.redisAddOrUpdateElement.TryChangeRedisComponentsAsync(updateSubscriptionDtoUI,
                SubscriptionRequest.Update, token);

            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteSubscriptionDtoUI deleteSubscriptionDtoUI,
            CancellationToken token)
        {
            if (deleteSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            await this.redisAddOrUpdateElement.TryChangeRedisComponentsAsync(deleteSubscriptionDtoUI,
                SubscriptionRequest.Delete, token);

            return new JsonResult("Delete was success");
        }
    }
}
