namespace Urnaus.Server.Interface;

public interface ITaskRepository
{
    Task<List<Urnaus.Shared.Task>> GetAllTaskAsync();
    Task<Urnaus.Shared.Task> GetTaskByIdAsync(int id);
    Task AddTaskAsync(Urnaus.Shared.Task taskDto);
    Task UpdateTaskAsync(int id, Urnaus.Shared.Task taskDto);
    Task DeleteTaskAsync(int id);
}