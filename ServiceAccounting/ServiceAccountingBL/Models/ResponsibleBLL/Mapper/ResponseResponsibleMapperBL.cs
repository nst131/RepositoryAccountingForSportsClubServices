using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class ResponseResponsibleMapperBL : IMapper<Responsible, ResponseResponsibleDtoBL>
    {
        public ResponseResponsibleDtoBL Map(Responsible responsible)
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
            };
        }
    }
}
