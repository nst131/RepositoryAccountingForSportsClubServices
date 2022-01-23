using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClubCardUI.Dto
{
    public class ResponseClubCardDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }
    }
}
