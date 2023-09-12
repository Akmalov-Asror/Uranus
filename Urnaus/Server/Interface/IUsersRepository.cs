using Urnaus.Server.Dto_s;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface IUsersRepository
{
    Task<User> Registration(LoginDto loginDto);
    Task<User> Login(CheckLogin checkLogin);
}