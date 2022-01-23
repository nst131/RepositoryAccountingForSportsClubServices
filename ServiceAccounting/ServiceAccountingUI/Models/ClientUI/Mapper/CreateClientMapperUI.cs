using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingUI.Models.ClientUI.Dto;

namespace ServiceAccountingUI.Models.ClientUI.Mapper
{
    public static class CreateClientMapperUI
    {
        public static AcceptCreateClientDtoBL Map<Result>(AcceptCreateClientDtoUI client)
            where Result : AcceptCreateClientDtoBL
        {
            return new()
            {
                Name = client.Name,
                Email = client.Email
            };
        }

        public static ResponseClientDtoUI Map<Result>(ResponseClientDtoBL client)
            where Result : ResponseClientDtoUI
        {
            return new()
            {
                Id = client.Id,
                Name = client.Name
            };
        }
    }
}
