using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingUI.ClientUI.Dto;
using System.Collections.Generic;

namespace ServiceAccountingUI.ClientUI.Mapper
{
    public static class GetClientMapperUI
    {
        public static GetClientDtoUI Map<Result>(GetClientDtoBL client)
                where Result : GetClientDtoUI
        {
            return new GetClientDtoUI()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSex = client.TypeSex
            };
        }

        public static ICollection<GetClientDtoUI> Map<Result>(ICollection<GetClientDtoBL> clients)
                where Result : ICollection<GetClientDtoUI>
        {
            var clientsDtoUI = new List<GetClientDtoUI>();

            foreach (var client in clients)
            {
                clientsDtoUI.Add(Map<GetClientDtoUI>(client));
            }

            return clientsDtoUI;
        }
    }
}
