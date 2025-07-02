using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ClientUI.Dto
{
    public class AcceptGetClientDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
