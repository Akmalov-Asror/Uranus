using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Dto_s;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public LoginController(IUsersRepository usersRepository) => _usersRepository = usersRepository;

    [HttpPost]
    public async Task<IActionResult> Login(CheckLogin checkLogin) => Ok(await _usersRepository.Login(checkLogin));
}