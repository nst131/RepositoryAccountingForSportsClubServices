﻿using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.TrainerUI.Dto
{
    public class ResponseTrainerDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }
    }
}
