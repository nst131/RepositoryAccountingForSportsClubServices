using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingUI.Models.ClientUI.Dto;

namespace ServiceAccountingUI.Models.ClientUI.Mapper
{
    public static class UpdateClientMapperUI
    {
        public static UpdateClientDtoBL Map<Result>(AcceptUpdateClientDtoUI client)
            where Result: UpdateClientDtoBL
        {
            return new()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSexId = client.TypeSexId
            };
        }

        public static ResponseClientDtoUI Map<Result>(ClientDtoBL client)
            where Result: ResponseGetClientDtoUI
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
