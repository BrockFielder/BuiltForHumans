using SendGrid;
using SendGrid.Helpers.Mail;

namespace BulitForHumans.Services;

public class SendGridEmailSender : IEmailSender
{
    private readonly IConfiguration _config;
    private readonly ILogger<SendGridEmailSender> _logger;

    public SendGridEmailSender(IConfiguration config, ILogger<SendGridEmailSender> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        var apiKey = _config["SendGrid:ApiKey"]
                     ?? throw new InvalidOperationException("SendGrid:ApiKey is not configured.");
        var fromEmail = _config["SendGrid:FromEmail"] ?? "no-reply@builtforhumans.com";
        var fromName = _config["SendGrid:FromName"] ?? "Built For Humans Website";

        var client = new SendGridClient(apiKey);
        var msg = MailHelper.CreateSingleEmail(
            new EmailAddress(fromEmail, fromName),
            new EmailAddress(to),
            subject,
            plainTextContent: body,
            htmlContent: null);

        var response = await client.SendEmailAsync(msg);

        if ((int)response.StatusCode >= 400)
        {
            var responseBody = await response.Body.ReadAsStringAsync();
            _logger.LogError("SendGrid returned {Status}: {Body}", response.StatusCode, responseBody);
            throw new InvalidOperationException($"Email send failed: {response.StatusCode}");
        }
    }
}