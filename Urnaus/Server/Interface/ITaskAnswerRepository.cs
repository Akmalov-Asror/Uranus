using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface ITaskAnswerRepository
{
    Task<List<TaskAnswer>> GetTaskAnswerList();
    Task<TaskAnswer> AddTaskAnswer(TaskAnswer taskAnswer);

}