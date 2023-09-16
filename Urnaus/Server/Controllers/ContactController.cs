using Microsoft.AspNetCore.Mvc;
using Urnaus.Server.Interface;
using Urnaus.Shared;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    public ContactController(IContactRepository contactRepository) => _contactRepository = contactRepository;

    [HttpPost]
    public async Task<IActionResult> AddContact(Contact contact) => Ok(_contactRepository.AddContact(contact));
}