using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingUI.ClientUI.Dto;

namespace ServiceAccountingUI.ClientUI.Mapper
{
    public static class CreateClientMapperUI
    {
        public static CreateClientDtoBL Map<Result>(CreateClientDtoUI client)
            where Result : CreateClientDtoBL
        {
            return new CreateClientDtoBL()
            {
                Name = client.Name,
                SerName = client.SerName,
                Telephone = client.Telephone,
                TypeSexId = client.TypeSexId
            };
        }

        public static ClientDtoUI Map<Result>(ClientDtoBL client)
            where Result : ClientDtoUI
        {
            return new ClientDtoUI()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName
            };
        }
    }
}
