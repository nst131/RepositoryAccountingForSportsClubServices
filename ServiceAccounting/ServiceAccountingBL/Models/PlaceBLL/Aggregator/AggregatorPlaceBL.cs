using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Crud;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Aggregator
{
    public class AggregatorPlaceBL : IAggregatorPlaceBL
    {
        private readonly Lazy<IPlaceCrudBL> placeCrudBL;
        private readonly Lazy<IPlaceFetchersBL> placeFetchersBL;
        private readonly Lazy<ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>> createPlace;
        private readonly Lazy<IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>> updatePlace;
        private readonly Lazy<IRemover<Place>> removePlace;
        private readonly Lazy<IGetter<ResponseGetPlaceDtoBL>> getPlace;

        public AggregatorPlaceBL(Lazy<IPlaceCrudBL> placeCrudBL,
            Lazy<IPlaceFetchersBL> placeFetchersBL,
            Lazy<ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>> createPlace,
            Lazy<IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>> updatePlace,
            Lazy<IRemover<Place>> removePlace,
            Lazy<IGetter<ResponseGetPlaceDtoBL>> getPlace)
        {
            this.placeCrudBL = placeCrudBL;
            this.placeFetchersBL = placeFetchersBL;
            this.createPlace = createPlace;
            this.updatePlace = updatePlace;
            this.removePlace = removePlace;
            this.getPlace = getPlace;
        }

        public IPlaceCrudBL PlaceCrudBL => placeCrudBL.Value;
        public IPlaceFetchersBL PlaceFetchersBL => placeFetchersBL.Value;
        public ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL> CreatePlace => createPlace.Value;
        public IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL> UpdatePlace => updatePlace.Value;
        public IRemover<Place> RemovePlace => removePlace.Value;
        public IGetter<ResponseGetPlaceDtoBL> GetPlace => getPlace.Value;
    }
}
