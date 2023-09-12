using EdgeDB;
using TravelPlanner.Core.Place;
public class PlaceRepository : IPlaceRepository
{
    private readonly EdgeDBClient _context;

    public PlaceRepository(EdgeDBClient context)
    {
        _context = context;
    }
    public async Task<PlaceView> GetPlaceByIdAsync(Guid id)
    {
        var query = @"SELECT PlaceToVisit {*} FILTER .id = <uuid>$id;";
        var result = await _context.QuerySingleAsync<PlaceView?>(query, new Dictionary<string, object?>
        {
            {"id", id}
        });
        return result;
    }
    public async Task<List<PlaceView>> GetAllPlacesAsync()
    {
        var query = @"SELECT PlaceToVisit {*}";
        var result = (await _context.QueryAsync<PlaceView?>(query)).ToList();
        return result;
    }
    public async Task<Guid> CreatePlaceAsync(PlaceInput place)
    {
        var query = @"
                WITH
                    place := (
                        INSERT PlaceToVisit {
                            name := <str>$name,
                            image_path := <str>$image_path,
                            description := <str>$description,
                            price := <float32>$price,
                            time_to_spend := <duration>$time_to_spend,
                            last_update := <datetime>$last_update,
                        }
                    )
                SELECT place.id;
            ";

        var result = await _context.QuerySingleAsync<Guid>(query, new Dictionary<string, object?>
        {
            {"name", place.Name},
            {"image_path", place.ImagePath},
            {"description", place.Description},
            {"price", place.Price},
            {"time_to_spend", place.TimeToSpend},
            {"last_update", place.LastUpdate}
        });

        return result;
    }
    public async Task<bool> UpdatePlaceAsync(Guid id, PlaceInput place)
    {
        try
        {
            var query = @"
                UPDATE PlaceToVisit
                FILTER .id = <uuid>$id
                SET {
                    name := <str>$name,
                    image_path := <str>$image_path,
                    description := <str>$description,
                    price := <float32>$price,
                    time_to_spend := <duration>$time_to_spend,
                    last_update := <datetime>$last_update,
                }
            ";

            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"name", place.Name},
                {"image_path", place.ImagePath},
                {"description", place.Description},
                {"price", place.Price},
                {"time_to_spend", place.TimeToSpend},
                {"last_update", place.LastUpdate}
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> DeletePlaceAsync(Guid id)
    {
        try
        {
            var query = @"DELETE PlaceToVisit 
                          FILTER .id = <uuid>$id;";
            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"id", id }
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
