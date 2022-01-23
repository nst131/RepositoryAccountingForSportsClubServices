using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ServiceUI.Dto
{
    public class ResponseGetServiceDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price", Order = 2, Required = Required.Always)]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "durationInMinutes", Order = 3, Required = Required.Always)]
        public string DurationInMinutes { get; set; }

        [JsonProperty(PropertyName = "placeName", Order = 4, Required = Required.Always)]
        public string PlaceName { get; set; }
    }
}