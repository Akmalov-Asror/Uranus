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
}