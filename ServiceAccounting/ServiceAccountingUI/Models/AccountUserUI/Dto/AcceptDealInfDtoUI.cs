using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class AcceptDealInfDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
