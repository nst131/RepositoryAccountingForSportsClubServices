using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ClientCardUI.Dto
{
    public class AcceptGetClientCardDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
