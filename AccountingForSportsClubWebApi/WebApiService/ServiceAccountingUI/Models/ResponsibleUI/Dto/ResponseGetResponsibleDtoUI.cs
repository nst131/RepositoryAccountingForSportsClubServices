using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ResponsibleUI.Dto
{
    public class ResponseGetResponsibleDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 2, Required = Required.Always)]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 3, Required = Required.Always)]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "email", Order = 4, Required = Required.Always)]
        public string Email { get; set; }
    }
}
