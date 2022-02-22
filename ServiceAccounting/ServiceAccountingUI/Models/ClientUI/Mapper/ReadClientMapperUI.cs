using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingUI.Models.ClientUI.Dto;

namespace ServiceAccountingUI.Models.ClientUI.Mapper
{
    public static class ReadClientMapperUI
    {
        public static ResponseGetClientDtoUI Map<Result>(ResponseGetClientDtoBL client)
            where Result : ResponseGetClientDtoUI
        {
            return new()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSex = client.TypeSex,
                Email = client.Email
            };
        }

        public static ICollection<ResponseGetClientDtoUI> Map<Result>(ICollection<ResponseGetClientDtoBL> clients)
            where Result : ICollection<ResponseGetClientDtoUI>
        {
            return clients.Select(client => Map<ResponseGetClientDtoUI>(client)).ToList();
        }
    }
}
