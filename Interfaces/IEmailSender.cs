using System.Threading.Tasks;

namespace BulitForHumans.Services;

public interface IEmailSender
{
    Task SendAsync(string to, string subject, string body);
}