using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingUI.Models.ClientUI.Dto;

namespace ServiceAccountingUI.Models.ClientUI.Mapper
{
    public static class UpdateClientMapperUI
    {
        public static AcceptUpdateClientDtoBL Map<Result>(AcceptUpdateClientDtoUI client)
            where Result: AcceptUpdateClientDtoBL
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

        public static ResponseClientDtoUI Map<Result>(ResponseClientDtoBL client)
            where Result: ResponseClientDtoUI
        {
            return new()
            {
                Id = client.Id,
                Name = client.Name
            };
        }
    }
}
