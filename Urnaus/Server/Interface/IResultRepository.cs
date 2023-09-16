using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface IResultRepository
{
    Task<List<Result>> GetAllResultAsync();
    Task<Result> GetResultByIdAsync(int id);
    Task AddResultAsync(Result result);
    Task DeleteResultAsync(int id);
    Task UpdateResultAsync(Result result);
    Task<List<Result>> GetUserResult(int userId);
}