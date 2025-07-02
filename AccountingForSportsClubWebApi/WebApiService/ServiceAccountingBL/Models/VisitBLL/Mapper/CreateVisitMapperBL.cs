using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public class CreateVisitMapperBL : IMapper<AcceptCreateVisitDtoBL, Visit>
    {
        public Visit Map(AcceptCreateVisitDtoBL dto)
        {
            return new()
            {
                Arrival = dto.Arrival,
                ServiceId = dto.ServiceId,
                ClientId = dto.ClientId
            };
        }
    }
}
