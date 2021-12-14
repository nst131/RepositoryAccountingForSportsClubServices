using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingUI.ResponsibleUI.Dto;

namespace ServiceAccountingUI.ResponsibleUI.Mapper
{
    public static class CreateResponsibleMapperUI
    {
        public static CreateResponsibleDtoBL Map<Result>(CreateResponsibleDtoUI responsible)
            where Result : CreateResponsibleDtoBL
        {
            return new CreateResponsibleDtoBL()
            {
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ResponsibleDtoUI Map<Result>(ResponsibleDtoBL responsible)
            where Result : ResponsibleDtoUI
        {
            return new ResponsibleDtoUI()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName
            };
        }
    }
}
