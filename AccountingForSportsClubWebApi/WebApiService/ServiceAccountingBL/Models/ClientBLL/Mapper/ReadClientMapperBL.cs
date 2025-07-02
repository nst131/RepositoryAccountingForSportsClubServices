using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public static class ReadClientMapperBL
    {
        public static ResponseGetClientDtoBL Map<Result>(Client client)
            where Result : ResponseGetClientDtoBL
        {
            return new ()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSex = client.TypeSex.Name,
                Email = client.Email
            };
        }

        public static ICollection<ResponseGetClientDtoBL> Map<Result>(ICollection<Client> allClients)
            where Result : ICollection<ResponseGetClientDtoBL>
        {
            return allClients.Select(client => Map<ResponseGetClientDtoBL>(client)).ToList();
        }
    }
}
