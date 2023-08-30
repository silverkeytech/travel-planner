namespace TravelPlanner.Core.Place
{
    internal interface IPlaceRepository
    {
        Task<Place> GetPlaceByIdAsync(Guid id);
        Task<List<Place>> GetAllPlacesAsync();
        Task<Guid> CreatePlaceAsync(Place place);
        Task<bool> UpdatePlaceAsync(Guid id, Place place);
        Task<bool> DeletePlaceAsync(Guid id);
    }
}
