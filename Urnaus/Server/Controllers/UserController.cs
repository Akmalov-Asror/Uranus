using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Dto_s;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUsersRepository _usersRepository;
    public UserController(IUsersRepository usersRepository, AppDbContext context)
    {
        _usersRepository = usersRepository;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register(LoginDto loginDto)
    {
        var checkUser = await _context.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (checkUser == null)
        {
            return Ok(await _usersRepository.Registration(loginDto));
        }
        return Ok();
        
    }
    [HttpGet("getCourse")]
    public async Task<IActionResult> GetUsersCourse(string email)
    {
        var courses = await _usersRepository.GetUserCourses(email);
        return Ok(courses);
    }
}