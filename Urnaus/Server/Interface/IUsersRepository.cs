using Urnaus.Server.Dto_s;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface IUsersRepository
{
    Task<User> Registration(LoginDto loginDto);
    Task<User> Login(CheckLogin checkLogin);
    Task<User> GetUserById(string email);
    Task UpdateUserAsync(User user);
    Task<List<Course>> GetUserCourses(string email);

}