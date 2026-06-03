using BulitForHumans.Models;

namespace BulitForHumans.Services;

public interface IContactService
{
    Task SubmitContactFormAsync(ContactMessage message);
}