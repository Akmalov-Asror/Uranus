using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Repository;

public class HomeworkRepository : IHomeworkRepository
{
    private readonly AppDbContext _context;

    public HomeworkRepository(AppDbContext context) => _context = context;

    public async Task<List<Homework>> GetAllHomeworkAsync()
    {
        var homework = await _context.Homework
            .Include(e => e.Task)
            .Select(e => new Homework()
            {
                Id = e.Id,
                Description = e.Description,
                ImageUrl = e.ImageUrl,
                Task = e.Task
            })
            .ToListAsync();
        return homework;
    }

    public async Task<Homework> GetHomeworkByIdAsync(int id)
    {
        var homeworkAsync = await _context.Homework
            .Include(e => e.Task)
            .FirstOrDefaultAsync(e => e.Id == id) ?? throw new BadHttpRequestException("Not Found");
        var homework = new Homework();
        homework.Id = id;
        homework.Description = homeworkAsync.Description;
        homework.ImageUrl = homeworkAsync.ImageUrl;
        homework.Task = homeworkAsync.Task;
        return homework;
    }

    public async Task AddHomeworkAsync(Homework homeworkDto)
    {
        var homework = new Homework();
        homework.ImageUrl = homeworkDto.ImageUrl;
        homework.Description = homeworkDto.Description;
        var findLesson = await _context.Course.FindAsync(homeworkDto.Task.Id);
        if (findLesson != null) homework.Task = homeworkDto.Task;
        _context.Homework.Add(homework);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHomeworkAsync(int id, Homework homeworkDto)
    {
        var homeworkFindAsync = await _context.Homework.FirstOrDefaultAsync(l => l.Id == id);
        homeworkFindAsync.Id = id;
        homeworkFindAsync.ImageUrl = homeworkDto.ImageUrl;
        homeworkFindAsync.Description = homeworkDto.Description;
        homeworkFindAsync.Task = homeworkDto.Task;

        _context.Entry(homeworkFindAsync).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHomeworkAsync(int id)
    {
        var homework = await _context.Homework.FindAsync(id);
        if (homework != null)
        {
            _context.Homework.Remove(homework);
            await _context.SaveChangesAsync();
        }
    }
}