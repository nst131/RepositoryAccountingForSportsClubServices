﻿using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class ResponseClientMapperBL : IMapper<Client, ClientDtoBL>
    {
        public ClientDtoBL Map(Client client)
        {
            return new ()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
            };
        }
    }
}