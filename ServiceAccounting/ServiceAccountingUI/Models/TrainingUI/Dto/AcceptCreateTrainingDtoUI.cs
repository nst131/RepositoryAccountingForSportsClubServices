using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ServiceAccountingUI.CustomAttributes;

namespace ServiceAccountingUI.Models.TrainingUI.Dto
{
    [CheckClientsOnAccordingClubCard(nameof(ClientsId), nameof(ServicesId))]
    [CheckServiceByTrainer(nameof(TrainerId),nameof(ServicesId))]
    public class AcceptCreateTrainingDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "startTraining", Order = 1, Required = Required.AllowNull)]
        public DateTime? StartTraining { get; set; }

        [JsonProperty(PropertyName = "trainerId", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int TrainerId { get; set; }

        [JsonProperty(PropertyName = "servicesId", Order = 3, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ServicesId { get; set; }

        [JsonProperty(PropertyName = "clientsId", Order = 4, Required = Required.Always)]
        public ICollection<int> ClientsId { get; set; }
    }
}
