using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.PlaceUI.Dto
{
    public class AcceptGetPlaceDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}
