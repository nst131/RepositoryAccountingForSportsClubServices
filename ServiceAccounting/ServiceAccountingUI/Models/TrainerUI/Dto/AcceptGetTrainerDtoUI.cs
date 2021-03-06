using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.TrainerUI.Dto
{
    public class AcceptGetTrainerDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
