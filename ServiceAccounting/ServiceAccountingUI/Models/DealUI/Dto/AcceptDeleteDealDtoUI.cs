﻿using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.DealUI.Dto
{
    public class AcceptDeleteDealDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }
    }
}