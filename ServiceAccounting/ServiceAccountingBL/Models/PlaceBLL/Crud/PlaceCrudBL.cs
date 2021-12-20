using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Aggregator;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Crud
{
    public class PlaceCrudBL : IPlaceCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL> createPlace;
        private readonly IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL> updatePlace;
        private readonly IRemover<Place> removePlace;

        public PlaceCrudBL(IServiceAccountingContext context, IAggregatorPlaceBL aggregator)
        {
            this.context = context;
            this.createPlace = aggregator.CreatePlace;
            this.updatePlace = aggregator.UpdatePlace;
            this.removePlace = aggregator.RemovePlace;
        }

        public async Task<ResponsePlaceDtoBL> CreatePlace(AcceptCreatePlaceDtoBL createPlaceDtoBL)
        {
            return await createPlace.Create(createPlaceDtoBL);
        }

        public async Task<ResponsePlaceDtoBL> UpdatePlace(AcceptUpdatePlaceDtoBL updatePlaceDtoBL)
        {
            return await updatePlace.Update(updatePlaceDtoBL);
        }

        public async Task DeletePlace(int id)
        {
            await removePlace.Remove(id);
        }

        public async Task<ResponseGetPlaceDtoBL> GetPlace(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Place)} is less 0");

            var place = await context.Set<Place>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (place is null)
                throw new ElementByIdNotFoundException($"{nameof(Place)} by Id not Found");

            return ReadPlaceMapperBL.Map<ResponseGetPlaceDtoBL>(place);
        }
    }
}
