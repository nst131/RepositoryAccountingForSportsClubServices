using Newtonsoft.Json;
using RedisLibrary;

namespace ServiceAccountingUI.Models.SubscriptionUI.Dto
{
    public class ResponseGetSubscriptionDtoUI : IRedisResponse
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "amountWorkouts", Order = 2, Required = Required.Always)]
        public string AmountWorkouts { get; set; }

        [JsonProperty(PropertyName = "price", Order = 3, Required = Required.Always)]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 4, Required = Required.Always)]
        public string ServiceName { get; set; }
    }
}