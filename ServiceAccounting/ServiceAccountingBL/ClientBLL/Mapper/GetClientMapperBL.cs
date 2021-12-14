using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingDA.Models;
using System.Collections.Generic;

namespace ServiceAccountingBL.ClientBLL.Mapper
{
    public static class GetClientMapperBL
    {
        public static GetClientDtoBL Map<Result>(Client client)
            where Result : GetClientDtoBL
        {
            return new GetClientDtoBL()
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
            var allClientsDto = new List<GetClientDtoBL>();

            foreach (var client in allClients)
            {
                allClientsDto.Add(Map<GetClientDtoBL>(client));
            }

            return allClientsDto;
        }
    }
}
