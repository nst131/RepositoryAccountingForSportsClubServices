using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.TrainerUI.Dto
{
    public class ResponseGetTrainerDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 2, Required = Required.Always)]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 3, Required = Required.Always)]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "typeSex", Order = 4, Required = Required.Always)]
        public string TypeSex { get; set; }

        [JsonProperty(PropertyName = "serviceId", Order = 5, Required = Required.Always)]
        public int ServiceId { get; set; }

        [JsonProperty(PropertyName = "service", Order = 6, Required = Required.Always)]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "email", Order = 7, Required = Required.Always)]
        public string Email { get; set; }
    }
}
