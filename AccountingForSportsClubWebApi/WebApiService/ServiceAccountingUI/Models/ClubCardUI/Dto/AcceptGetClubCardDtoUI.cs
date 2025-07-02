using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ClubCardUI.Dto
{
    public class AcceptGetClubCardDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
