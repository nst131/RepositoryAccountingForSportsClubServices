using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Fetchers
{
    public class PlaceFetchersBL : IPlaceFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public PlaceFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetPlaceDtoBL>> GetPlaceAll(CancellationToken token = default)
        {
            if (!await context.Set<Place>().AnyAsync(token))
                return new List<ResponseGetPlaceDtoBL>();

            var allPlaces = await context.Set<Place>()
                .ToListAsync(token);

            return ReadPlaceMapperBL.Map<ICollection<ResponseGetPlaceDtoBL>>(allPlaces);
        }
    }
}
