using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllTeacherAsync();
    Task<Teacher> GetTeacherByIdAsync(int id);
    Task AddTeacherAsync(Teacher teacher);
    Task UpdateTeacherAsync(Teacher teacher);
    Task DeleteTeacherAsync(int id);
}