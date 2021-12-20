using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.VisitBLL.Dto;

namespace ServiceAccountingBL.Models.VisitBLL.Fetchers
{
    public interface IVisitFetchersBL
    {
        Task<ICollection<ResponseGetVisitDtoBL>> GetVisitAll();
    }
}