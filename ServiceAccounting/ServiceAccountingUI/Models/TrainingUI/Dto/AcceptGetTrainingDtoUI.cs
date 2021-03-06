using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.TrainingUI.Dto
{
    public class AcceptGetTrainingDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}