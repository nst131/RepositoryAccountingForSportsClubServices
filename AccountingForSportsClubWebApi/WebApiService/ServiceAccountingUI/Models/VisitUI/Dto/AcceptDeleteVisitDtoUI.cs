using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.VisitUI.Dto
{
    public class AcceptDeleteVisitDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}