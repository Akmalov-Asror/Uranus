using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;

namespace Urnaus.Server.Repository;

public class TaskAnswerRepository : ITaskAnswerRepository
{
    private readonly AppDbContext _context;

    public TaskAnswerRepository(AppDbContext context) => _context = context;

    public async Task<List<TaskAnswer>> GetTaskAnswerList()
    {
        return await _context.TaskAnswers.ToListAsync();
    }

    public async Task<TaskAnswer> AddTaskAnswer(TaskAnswer taskAnswer)
    {
        var task = new TaskAnswer()
        {
            Answer = taskAnswer.Answer,
            fileUrl = taskAnswer.fileUrl,
            Task = taskAnswer.Task
        };
        _context.TaskAnswers.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
}