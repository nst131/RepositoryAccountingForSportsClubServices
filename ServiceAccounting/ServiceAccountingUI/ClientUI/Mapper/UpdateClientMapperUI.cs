using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingUI.ClientUI.Dto;

namespace ServiceAccountingUI.ClientUI.Mapper
{
    public static class UpdateClientMapperUI
    {
        public static UpdateClientDtoBL Map<Result>(UpdateClientDtoUI client)
            where Result : UpdateClientDtoBL
        {
            return new UpdateClientDtoBL()
            {
                Id = client.Id,
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
