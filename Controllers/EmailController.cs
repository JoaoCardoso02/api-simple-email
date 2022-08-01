using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace SimpleEmailApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmail(string body) {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("chester.hoppe36@ethereal.email"));
        email.To.Add(MailboxAddress.Parse("chester.hoppe36@ethereal.email"));
        email.Subject = "Test Email Subject";
        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("chester.hoppe36@ethereal.email", "hJNF9qemDBm8xqGqPp");

        smtp.Send(email);
        smtp.Disconnect(true);

        return Ok();
    }
}

