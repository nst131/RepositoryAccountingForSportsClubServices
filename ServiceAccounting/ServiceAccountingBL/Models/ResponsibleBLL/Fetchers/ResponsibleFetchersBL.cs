using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Fetchers
{
    public class ResponsibleFetchersBL : IResponsibleFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ResponsibleFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetResponsibleDtoBL>> GetResponsibleAll()
        {
            if (!await context.Set<Responsible>().AnyAsync())
                return new List<ResponseGetResponsibleDtoBL>();

            var allResponsibles = await context.Set<Responsible>().ToListAsync();

            return ReadResponsibleMapperBL.Map<ICollection<ResponseGetResponsibleDtoBL>>(allResponsibles);

        }
    }
}
