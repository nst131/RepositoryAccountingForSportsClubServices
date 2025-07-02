using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Aggregator;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.PlaceBLL.Crud
{
    public class PlaceCrudBL : IPlaceCrudBL
    {
        private readonly ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL> createPlace;
        private readonly IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL> updatePlace;
        private readonly IRemover<Place> removePlace;
        private readonly IGetter<ResponseGetPlaceDtoBL> getPlace;

        public PlaceCrudBL(IAggregatorPlaceBL aggregator)
        {
            this.createPlace = aggregator.CreatePlace;
            this.updatePlace = aggregator.UpdatePlace;
            this.removePlace = aggregator.RemovePlace;
            this.getPlace = aggregator.GetPlace;
        }

        public async Task<ResponsePlaceDtoBL> CreatePlace(AcceptCreatePlaceDtoBL createPlaceDtoBL, CancellationToken token = default)
            => await createPlace.Create(createPlaceDtoBL, token);

        public async Task<ResponsePlaceDtoBL> UpdatePlace(AcceptUpdatePlaceDtoBL updatePlaceDtoBL, CancellationToken token = default)
            => await updatePlace.Update(updatePlaceDtoBL, token);

        public async Task DeletePlace(int id, CancellationToken token = default)
            => await removePlace.Remove(id, token);

        public async Task<ResponseGetPlaceDtoBL> GetPlace(int id, CancellationToken token = default)
            => await getPlace.Get(id, token);
    }
}
