namespace SimpleEmailApp.Services;

public interface IEmailService
{
    public void SendEmail(EmailDto request);
}

