using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ClientUI.Dto
{
    public class AcceptDeleteClientDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
