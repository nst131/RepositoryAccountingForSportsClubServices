using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClubCardUI.Dto
{
    public class ResponseGetClubCardDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price", Order = 2, Required = Required.Always)]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "durationInDays", Order = 3, Required = Required.Always)]
        public string DurationInDays { get; set; }

        [JsonProperty(PropertyName = "service", Order = 4, Required = Required.Always)]
        public string Service { get; set; }
    }
}
