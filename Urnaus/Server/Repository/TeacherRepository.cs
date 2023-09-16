using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Repository;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context) => _context = context;

    public Task<List<Teacher>> GetAllTeacherAsync()
    {
        return _context.Teacher.ToListAsync();
    }

    public async Task<Teacher> GetTeacherByIdAsync(int id)
    {
        return await _context.Teacher.FirstOrDefaultAsync(u => u.Id == id) ?? throw new BadHttpRequestException("Teacher not found");
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        _context.Teacher.Add(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        var firstOrDefaultAsync = await _context.Teacher.FirstOrDefaultAsync(u => u.Id == teacher.Id);

        if (firstOrDefaultAsync != null)
        {
            firstOrDefaultAsync.Name = teacher.Name;
            firstOrDefaultAsync.ImageUrl = teacher.ImageUrl;
            firstOrDefaultAsync.Type = teacher.Type;
            _context.Entry(firstOrDefaultAsync).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteTeacherAsync(int id)
    {
        var teacher = await _context.Teacher.FindAsync(id);
        if (teacher != null)
        {
            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}