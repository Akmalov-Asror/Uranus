using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface IHomeworkRepository
{
    Task<List<Homework>> GetAllHomeworkAsync();
    Task<Homework> GetHomeworkByIdAsync(int id);
    Task AddHomeworkAsync(Homework homeworkDto);
    Task UpdateHomeworkAsync(int id, Homework homeworkDto);
    Task DeleteHomeworkAsync(int id);
}