using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ResponsibleUI.Dto
{
    public class AcceptDeleteResponsibleDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
