using EdgeDB;
using TravelPlanner.Core.Program;

public class ProgramRepository : IProgramRepository
{
    private readonly EdgeDBClient _context;

    public ProgramRepository(EdgeDBClient context)
    {
        _context = context;
    }
    public async Task<ProgramView> GetProgramByIdAsync(Guid id)
    {
        var query = @"SELECT Program {*} FILTER .id = <uuid>$id;";
        var result = await _context.QuerySingleAsync<ProgramView?>(query, new Dictionary<string, object?>
        {
            {"id", id}
        });
        return result;
    }
    public async Task<List<ProgramView>> GetAllProgramsAsync()
    {
        var query = @"SELECT Program {*}";
        var result = (await _context.QueryAsync<ProgramView?>(query)).ToList();
        return result;
    }
    public async Task<Guid> CreateProgramAsync(ProgramInput program)
    {
        var query = @"
                WITH
                    program := (
                        INSERT Program {
                            name := <str>$name,
                            image_path := <str>$image_path,
                            description := <str>$description,
                            programs_Highlights := <array<str>>$programs_Highlights,
                            last_update := <datetime>$last_update,
                        }
                    )
                SELECT program.id;
            ";

        var result = await _context.QuerySingleAsync<Guid>(query, new Dictionary<string, object?>
        {
            {"name", program.Name},
            {"image_path", program.ImagePath},
            {"description", program.Description},
            {"programs_Highlights", program.ProgramHighlights},
            {"last_update", program.LastUpdate}
        });

        return result;
    }
    public async Task<bool> UpdateProgramAsync(Guid id, ProgramInput program)
    {
        try
        {
            var query = @"
                UPDATE Program
                FILTER .id = <uuid>$id
                SET {
                    name := <str>$name,
                    image_path := <str>$image_path,
                    description := <str>$description,
                    programs_Highlights := <array<str>>$programs_Highlights,
                    last_update := <datetime>$last_update,
                }
            ";

            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"id", id},
                {"name", program.Name},
                {"image_path", program.ImagePath},
                {"description", program.Description},
                {"programs_Highlights", program.ProgramHighlights},
                {"last_update", program.LastUpdate}
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> DeleteProgramAsync(Guid id)
    {
        try
        {
            var query = @"DELETE Program 
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
    public async Task CreateActivityAsync(List<ActivityDetailsInput> activities, Guid programId)
    {
        var query = @"
            UPDATE Program
            FILTER .id = <uuid>$id
            SET {
                activities += (
                    FOR activity in array_unpack(<array<ActivityDetailsInput>>$activities)
                    UNION (
                        INSERT ActivityDetails {
                            name := activity.name,
                            details := activity.details,
                            time_to_spend := activity.time_to_spend,
                            price := activity.price,
                        }
                    )
                )
            }
        ";
                
        await _context.ExecuteAsync(query, new Dictionary<string, object?>
        {
            {"id", programId},
            {"rooms", activities},
        });
    }
    public async Task UpdateActivityAsync(Guid activityId, ActivityDetailsInput activity)
    {
        var query = @"
            UPDATE ActivityDetails
            FILTER .id = <uuid>$id
            SET {
                name := activity.name,
                details := activity.details,
                time_to_spend := activity.time_to_spend,
                price := activity.price,
            }
        ";

        await _context.ExecuteAsync(query, new Dictionary<string, object?>
        {
            {"id", activityId},
            {"name", activity.Name},
            {"details", activity.Details},
            {"time_to_spend", activity.TimeToSpend},
            {"price", activity.Price},
        });
    }
    public async Task<bool> DeleteActivityAsync(Guid activityId)
    {
        try
        {
            var query = @"DELETE ActivityDetails
                          FILTER .id = <uuid>$id;";
            await _context.ExecuteAsync(query, new Dictionary<string, object?>
            {
                {"id", activityId}
            });

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
