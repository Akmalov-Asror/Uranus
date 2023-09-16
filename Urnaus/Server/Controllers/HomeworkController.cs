using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworkController : ControllerBase
{
    private readonly IHomeworkRepository _homeworkRepository;

    public HomeworkController(IHomeworkRepository homeworkRepository) => _homeworkRepository = homeworkRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllHomework() => Ok(await _homeworkRepository.GetAllHomeworkAsync());
}