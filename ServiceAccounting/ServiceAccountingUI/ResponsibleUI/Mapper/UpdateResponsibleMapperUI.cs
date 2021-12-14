using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingUI.ResponsibleUI.Dto;

namespace ServiceAccountingUI.ResponsibleUI.Mapper
{
    public static class UpdateResponsibleMapperUI
    {
        public static UpdateResponsibleDtoBL Map<Result>(UpdateResponsibleDtoUI responsible)
            where Result : UpdateResponsibleDtoBL
        {
            return new UpdateResponsibleDtoBL()
            {
                Id = responsible.Id,
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
