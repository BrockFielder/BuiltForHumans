using BulitForHumans.Models;

namespace BuiltForHumans.Services;

public interface IContactService
{
    // SubmitContactForm() — saves the message to DB and triggers an email notification
    Task<bool> SubmitContactFormAsync(ContactMessage message);
}