using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public static class ReadClientMapperBL
    {
        public static GetClientDtoBL Map<Result>(Client client)
            where Result : GetClientDtoBL
        {
            return new ()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSex = client.TypeSex.Name
            };
        }

        public static ICollection<GetClientDtoBL> Map<Result>(ICollection<Client> allClients)
            where Result : ICollection<GetClientDtoBL>
        {
            return allClients.Select(client => Map<GetClientDtoBL>(client)).ToList();
        }
    }
}
