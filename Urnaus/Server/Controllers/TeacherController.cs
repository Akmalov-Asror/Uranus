using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherController(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _teacherRepository.GetAllTeacherAsync();
        return Ok(teachers);
    }
}