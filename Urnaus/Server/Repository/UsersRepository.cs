using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Dto_s;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context) => _context = context;

    public async Task<User> Registration(LoginDto loginDto)
    {
        var user = new User();
        user.Email = loginDto.Email;
        user.FullName = loginDto.FullName;
        user.Password = loginDto.Password;
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Login(CheckLogin checkLogin)
    {
        var userFind =
            await _context.User.FirstOrDefaultAsync(u =>
                u.Email == checkLogin.Email && u.Password == checkLogin.Password);
        return userFind;
    }

    public async Task<User> GetUserById(string email)
    {
        var getUser = await _context.User.FirstOrDefaultAsync(e => e.Email == email);
        return getUser;
    }

    public async Task UpdateUserAsync(User user)
    {
        var newItems = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
        newItems.Password = user.Password;

        _context.Entry(newItems).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }
    public async Task<List<Course>> GetUserCourses(string email)
    {
        var user = await _context.User
            .Include(e => e.Courses)
            .FirstOrDefaultAsync(e => e.Email == email) ?? throw new BadHttpRequestException("User Not found");

        List<Course> courseDtos = user.Courses.Select(course => new Course()
        {
            Id = course.Id,
            ImageUrl = course.ImageUrl,
            Title = course.Title,
            Description = course.Description,
            Price = course.Price
        }).ToList();

        return courseDtos;
    }
}