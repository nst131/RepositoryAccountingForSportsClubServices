using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ServiceUI.Dto
{
    public class AcceptGetServiceDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}