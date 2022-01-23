using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;

namespace ServiceAccountingUI.Models.ResponsibleUI.Mapper
{
    public static class CreateResponsibleMapperUI
    {
        public static AcceptCreateResponsibleDtoBL Map<Result>(AcceptCreateResponsibleDtoUI responsible)
            where Result : AcceptCreateResponsibleDtoBL
        {
            return new ()
            {
                Name = responsible.Name,
                Email = responsible.Email
            };
        }

        public static ResponseResponsibleDtoUI Map<Result>(ResponseResponsibleDtoBL responsible)
            where Result : ResponseResponsibleDtoUI
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name
            };
        }
    }
}
