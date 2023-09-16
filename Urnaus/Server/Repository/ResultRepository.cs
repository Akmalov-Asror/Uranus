using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Repository;

public class ResultRepository : IResultRepository
{
    private readonly AppDbContext _context;
    public ResultRepository(AppDbContext context) => _context = context;

    public async Task<List<Result>> GetAllResultAsync()
    {
        return await _context.Result.ToListAsync();
    }

    public async Task<Result> GetResultByIdAsync(int id)
    {
        return await _context.Result.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddResultAsync(Result result)
    {
        var results = new Result()
        {
            Education = result.Education,
            Url = result.Url,
            User = result.User
        };
        _context.Result.Add(results);
        await _context.SaveChangesAsync();
    }

    public Task DeleteResultAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateResultAsync(Result result)
    {
        throw new NotImplementedException();
    }

    public Task<List<Result>> GetUserResult(int userId)
    {
        throw new NotImplementedException();
    }
}