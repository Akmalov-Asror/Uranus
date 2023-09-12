using System;
using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;
namespace Urnaus.Server.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context) => _context = context;

    public async Task<List<Course>> GetAll()
    {
        return await _context.Course.ToListAsync();
    }

    public async Task<Course> Get(int id)
    {
        return await _context.Course.FirstOrDefaultAsync(u => u.Id == id) ?? throw new BadHttpRequestException("Course not found");
    }

    public async Task Add(Course course)
    {
        _context.Course.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Course course)
    {
        _context.Entry(course).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var course = await _context.Course.FindAsync(id);
        if (course != null)
        {
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}