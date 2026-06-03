using BulitForHumans.Data;
using BulitForHumans.Models;

namespace BulitForHumans.Services;

public class ContactService : IContactService
{
    private readonly AppDbContext _db;
    private readonly IEmailSender _emailSender;
    private readonly IConfiguration _config;
    private readonly ILogger<ContactService> _logger;

    public ContactService(
        AppDbContext db,
        IEmailSender emailSender,
        IConfiguration config,
        ILogger<ContactService> logger)
    {
        _db = db;
        _emailSender = emailSender;
        _config = config;
        _logger = logger;
    }

    public async Task SubmitContactFormAsync(ContactMessage message)
    {
        var firmMailbox = _config["Contact:FirmMailbox"] ?? "hello@builtforhumans.com";

        var subject = $"New enquiry from {message.senderName}";
        var body = $"From: {message.senderName} <{message.email}>\n\n{message.text}";

        // Primary action: forward to the firm.
        await _emailSender.SendAsync(firmMailbox, subject, body);

        // Optional backup log — don't fail the request if it throws.
        try
        {
            _db.ContactMessages.Add(message);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to persist contact message backup.");
        }
    }
}