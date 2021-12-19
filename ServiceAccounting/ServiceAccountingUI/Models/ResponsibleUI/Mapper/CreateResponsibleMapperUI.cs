using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;

namespace ServiceAccountingUI.Models.ResponsibleUI.Mapper
{
    public static class CreateResponsibleMapperUI
    {
        public static CreateResponsibleDtoBL Map<Result>(AcceptCreateResponsibleDtoUI responsible)
            where Result : CreateResponsibleDtoBL
        {
            return new ()
            {
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ResponseResponsibleDtoUI Map<Result>(ResponsibleDtoBL responsible)
            where Result : ResponseResponsibleDtoUI
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName
            };
        }
    }
}
