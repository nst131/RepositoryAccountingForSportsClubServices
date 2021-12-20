﻿using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class ResponseClubCardMapperBL : IMapper<ClubCard, ResponseClubCardDtoBL>
    {
        public ResponseClubCardDtoBL Map(ClubCard clubCard)
        {
            return new ()
            {
                Id = clubCard.Id,
                Name = clubCard.Name
            };
        }
    }
}