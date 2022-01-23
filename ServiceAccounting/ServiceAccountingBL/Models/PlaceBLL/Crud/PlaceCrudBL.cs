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

        public async Task<ResponsePlaceDtoBL> CreatePlace(AcceptCreatePlaceDtoBL createPlaceDtoBL)
            => await createPlace.Create(createPlaceDtoBL);

        public async Task<ResponsePlaceDtoBL> UpdatePlace(AcceptUpdatePlaceDtoBL updatePlaceDtoBL)
            => await updatePlace.Update(updatePlaceDtoBL);

        public async Task DeletePlace(int id)
            => await removePlace.Remove(id);

        public async Task<ResponseGetPlaceDtoBL> GetPlace(int id)
            => await getPlace.Get(id);
    }
}
