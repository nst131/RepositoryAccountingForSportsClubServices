using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.TrainerUI.Dto
{
    public class AcceptDeleteTrainerDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
