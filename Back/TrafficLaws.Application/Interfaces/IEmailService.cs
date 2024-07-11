namespace TrafficLaws.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string messageBody);

    Task ConfirmEmail(Guid id, string code, CancellationToken cancellationToken);
}