namespace TravelPlanner.Core.Place
{
    public interface IPlaceRepository
    {
        Task<PlaceView> GetPlaceByIdAsync(Guid id);
        Task<List<PlaceView>> GetAllPlacesAsync();
        Task<Guid> CreatePlaceAsync(PlaceInput place);
        Task<bool> UpdatePlaceAsync(Guid id, PlaceInput place);
        Task<bool> DeletePlaceAsync(Guid id);
    }
}
