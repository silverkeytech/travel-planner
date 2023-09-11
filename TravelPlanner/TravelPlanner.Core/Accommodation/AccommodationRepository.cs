using EdgeDB;
using TravelPlanner.Core.Accommodation;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly EdgeDBClient _context;

    public AccommodationRepository(EdgeDBClient context)
    {
        _context = context;
    }

    public async Task<AccommodationView> GetAccommodationByIdAsync(Guid id)
    {
        var query = @"SELECT Accommodation {*} FILTER .id = <uuid>$id;";
        var result = await _context.QuerySingleAsync<AccommodationView?>(query, new Dictionary<string, object?>
        {
            {"id", id}
        });
        return result;
    }

    public async Task<List<AccommodationView>> GetAllAccommodationsAsync()
    {
        var query = @"SELECT Accommodation {*}";
        var result = (await _context.QueryAsync<AccommodationView?>(query)).ToList();
        return result;
    }

    //TODO
    //public async Task<List<AccommodationView>> GetAccommodationsByFilterAsync(AccommodationFilterCriteria criteria)
    //{
    //}
    public async Task<Guid> CreateAccommodationAsync(AccommodationInput accommodation)
    {
        var query = @"
                WITH
                    accommodation := (
                        INSERT Accommodation {
                            hotel_name := <str>$hotel_name,
                            accommodation_modes := <str>$accommodation_modes,
                            location := <str>$location,
                            latitude := <float32>$latitue,
                            longitude := <float32>$longitude,
                            short_description := <str>$short_description,
                            long_description := <str>$long_description,
                            profile_picture_path := <str>$profile_picture_path,
                            number_of_stars := <int16>$number_of_start,
                            accommodation_facilities := <array<AccommodationFacilities>>accommodation_facilities;
                            images_path =: <array<str>> images_path;
                            last_update := <datetime>$last_update,
                        }
                    )
                SELECT accommodation.id;
        ";

        var result = await _context.QuerySingleAsync<Guid>(query, new Dictionary<string, object?>
        {
            {"hotel_name", accommodation.HotelName},
            {"accommodation_modes", accommodation.AccommodationModes},
            {"location", accommodation.Location},
            {"latitude", accommodation.Latitude},
            {"longitude", accommodation.Longitude},
            {"short_description", accommodation.ShortDescription},
            {"long_description", accommodation.LongDescription},
            {"profile_picture_path", accommodation.ProfilePicturePath},
            {"number_of_stars", accommodation.NumberOfStars},
            {"accommodation_facilities", accommodation.AccommodationFacilities},
            {"images_path", accommodation.ImagesPath},
            {"last_update", accommodation.LastUpdate}
        });

        return result;
    }

    public async Task<bool> UpdateAccommodationAsync(Guid id, AccommodationInput accommodation)
    {
        try
        {
            var query = @"
                UPDATE Accommodation
                FILTER .id = <uuid>$id
                SET {
                    hotel_name := <str>$hotel_name,
                    accommodation_modes := <str>$accommodation_modes,
                    location := <str>$location,
                    latitude := <float32>$latitue,
                    longitude := <float32>$longitude,
                    short_description := <str>$short_description,
                    long_description := <str>$long_description,
                    profile_picture_path := <str>$profile_picture_path,
                    number_of_stars := <int16>$number_of_start,
                    accommodation_facilities := <array<AccommodationFacilities>>accommodation_facilities;
                    images_path := <array<str>>$images_path;
                    last_update := <datetime>$last_update,
                }
            ";

            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"id", id},
                {"hotel_name", accommodation.HotelName},
                {"accommodation_modes", accommodation.AccommodationModes},
                {"location", accommodation.Location},
                {"latitude", accommodation.Latitude},
                {"longitude", accommodation.Longitude},
                {"short_description", accommodation.ShortDescription},
                {"long_description", accommodation.LongDescription},
                {"profile_picture_path", accommodation.ProfilePicturePath},
                {"number_of_stars", accommodation.NumberOfStars},
                {"accommodation_facilities", accommodation.AccommodationFacilities},
                {"images_path", accommodation.ImagesPath},
                {"last_update", accommodation.LastUpdate}
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAccommodationAsync(Guid id)
    {
        try
        {
            var query = @"DELETE Accommodation
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

    public async Task CreateAccommodationReviewAsync(AccommodationReviewInput review, Guid accommodationId)
    {
        var query = @"
                UPDATE Accommodation
                FILTER .id = <uuid>$id
                SET {
                    reviews += (
                        Insert AccommodationReview {
                            guest_name := <str>$guest_name,
                            nationality := <str>$nationality,
                            rate := <float32>$rate,
                            comment := <str>$comment,
                            date := <datetime>$start_date,
                        }
                    )
                }
            ";
                
        await _context.ExecuteAsync(query, new Dictionary<string, object?>
        {
            {"id", accommodationId},
            {"guest_name", review.GuestName},
            {"nationality", review.Nationality},
            {"rate", review.Rate},
            {"comment", review.Comment},
            {"date", review.Date},
        });
    }
    public async Task CreateAccommodationRoomsAsync(List<RoomInput> rooms, Guid accommodationId)
    {
        var query = @"
            UPDATE Accommodation
            FILTER .id = <uuid>$id
            SET {
                rooms += (
                    FOR room in array_unpack(<array<RoomInput>>$rooms)
                    UNION (
                        INSERT Room {
                            room_type := room.room_type,
                            capacity := room.capacity,
                            price_per_night := room.price_per_night,
                            description := room.description,
                            available_rooms_count := room.available_rooms_count,
                        }
                    )
                )
            }
        ";
                
        await _context.ExecuteAsync(query, new Dictionary<string, object?>
        {
            {"id", accommodationId},
            {"rooms", rooms},
        });
    }

    public async Task UpdateAccommodationRoomAsync(Guid roomId, RoomInput room)
    {
        var query = @"
            UPDATE Room
            FILTER .id = <uuid>$idd
            SET {
                room_type := <RoomType>$room_type,
                capacity := <int16>$capacity,
                price_per_night := <float32>$price_per_night,
                description := <str>$description,
                available_rooms_count := <int16>$available_rooms_count,
            }
        ";

        await _context.ExecuteAsync(query, new Dictionary<string, object?>
        {
            {"id", roomId},
            {"room_type", room.RoomType},
            {"capacity", room.Capacity},
            {"price_per_night", room.PricePerNight},
            {"description", room.Description},
            {"available_rooms_count", room.AvailableRoomsCount},
        });
    }

    public async Task<bool> DeleteAccommodationRoomAsync(Guid roomId)
    {
        try
        {
            var query = @"DELETE Room
                          FILTER .id = <uuid>$id;";
            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"id", roomId}
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
