using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository) => _taskRepository = taskRepository;

    [HttpGet("one")]
    public async Task<IActionResult> GetTaskById(int taskId) => Ok(await _taskRepository.GetTaskByIdAsync(taskId));
}