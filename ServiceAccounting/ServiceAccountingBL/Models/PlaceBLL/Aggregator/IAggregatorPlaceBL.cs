using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.PlaceBLL.Crud;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.PlaceBLL.Aggregator
{
    public interface IAggregatorPlaceBL
    {
        IPlaceCrudBL PlaceCrudBL { get; }
        IPlaceFetchersBL PlaceFetchersBL { get; }
        ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL> CreatePlace { get; }
        IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL> UpdatePlace { get; }
        IRemover<Place> RemovePlace { get; }
        IGetter<ResponseGetPlaceDtoBL> GetPlace { get; }
    }
}