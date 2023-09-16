using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskAnswerController : ControllerBase
{
    private readonly ITaskAnswerRepository _taskAnswerRepository;
    
    public TaskAnswerController(ITaskAnswerRepository taskAnswerRepository) => _taskAnswerRepository = taskAnswerRepository;


    [HttpPost]
    public async Task<IActionResult> AddTaskAnswer(TaskAnswer taskAnswer) =>  Ok(await _taskAnswerRepository.AddTaskAnswer(taskAnswer));
}