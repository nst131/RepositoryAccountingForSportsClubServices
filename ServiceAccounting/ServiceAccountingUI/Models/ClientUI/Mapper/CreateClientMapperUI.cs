using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingUI.Models.ClientUI.Dto;

namespace ServiceAccountingUI.Models.ClientUI.Mapper
{
    public static class CreateClientMapperUI
    {
        public static CreateClientDtoBL Map<Result>(AcceptCreateClientDtoUI client)
            where Result : CreateClientDtoBL
        {
            return new()
            {
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSexId = client.TypeSexId
            };
        }

        public static ResponseClientDtoUI Map<Result>(ClientDtoBL client)
            where Result : ResponseClientDtoUI
        {
            return new()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName
            };
        }
    }
}
