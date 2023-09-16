using System.ComponentModel.DataAnnotations;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using Urnaus.Client.Dto_s;
using Urnaus.Server.Interface;

namespace Urnaus.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailSenderController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public EmailSenderController(IUsersRepository usersRepository) => _usersRepository = usersRepository;

    [HttpPost]
    public async Task<IActionResult> SendMail(EmailSendDto emailDto)
    {

        var async = await _usersRepository.GetUserById(emailDto.Email);

        if (async == null)
        {
            return BadRequest("User Not Registered");
        }

        Random random = new Random();
        int otp = random.Next(10000000, 99999999);

        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("akmalovasror0@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailDto.Email));
        email.Subject = "Your verification code";
        email.Body = new TextPart(TextFormat.Html) { Text = "Ben Qodirali emasman " + otp };

        var smpt = new SmtpClient();
        await smpt.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await smpt.AuthenticateAsync("akmalovasror0@gmail.com", "afknqzwhukhgejpz");
        await smpt.SendAsync(email);
        await smpt.DisconnectAsync(true);

        async.Password = otp.ToString();

        await _usersRepository.UpdateUserAsync(async);

        return Ok();

    }
}