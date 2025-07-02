using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.SubscriptionUI.Dto
{
    public class AcceptGetSubscriptionDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}