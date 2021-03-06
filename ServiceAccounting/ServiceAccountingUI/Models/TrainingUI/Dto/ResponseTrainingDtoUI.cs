using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceAccountingBL.BaseModels;

namespace ServiceAccountingUI.Models.TrainingUI.Dto
{
    public class ResponseTrainingDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "startTraining", Order = 2, Required = Required.Always)]
        public DateTime StartTraining { get; set; }

        [JsonProperty(PropertyName = "clientsHasExpired", Order = 2, Required = Required.Always)]
        public ICollection<ClientsHasExpiredDto> ClientsHasExpired { get; set; }
    }
}