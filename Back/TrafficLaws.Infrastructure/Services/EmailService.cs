using Domain.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using TrafficLaws.Application.Interfaces;
using TrafficLaws.Application.Interfaces.Repository;

namespace TrafficLaws.Infrastructure.Services;

public class EmailService : IEmailService
{
    private UserManager<User> _userManager;
    private IUserRepository _userRepository;
    private readonly string _smtpServer = "smtp.yandex.com";
    private readonly int _smtpPort = 465;
    private readonly string _smtpUsername = "bu.nag@yandex.ru";
    private readonly string _smtpPassword = "dzjgvkgrjzhwksgc";

    public EmailService(UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }

    public async Task SendEmailAsync(string email, string subject, string messageBody)
    {
        using var smtpClient = new SmtpClient();
        await smtpClient.ConnectAsync(_smtpServer, _smtpPort, true);
        await smtpClient.AuthenticateAsync(_smtpUsername, _smtpPassword);
        await smtpClient.SendAsync(GenerateMessage(email, subject, messageBody));
        await smtpClient.DisconnectAsync(true);
    }

    public async Task ConfirmEmail(Guid id, string code, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetById(id, cancellationToken);

        await _userManager.ConfirmEmailAsync(user!, code);
    }

    private MimeMessage GenerateMessage(string email, string subject, string messageBody)
    {
        return new MimeMessage
        {
            From = { new MailboxAddress("Traffic Laws", _smtpUsername) },
            To = { new MailboxAddress("", email) },
            Subject = subject,
            Body = new BodyBuilder { HtmlBody = messageBody }.ToMessageBody()
        };
    }
}
