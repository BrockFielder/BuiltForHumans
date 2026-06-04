using BulitForHumans.Models;
using BulitForHumans.Services;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.RateLimiting;

namespace BulitForHumans.Controllers;

[Route("contact")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService) => _contactService = contactService;

    [HttpGet("")]
    public IActionResult Index() => View(new ContactMessage());

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    // [EnableRateLimiting("contact")]
    public async Task<IActionResult> Submit(ContactMessage message)
    {
        if (!ModelState.IsValid)
            return View(nameof(Index), message);

        await _contactService.SubmitContactFormAsync(message);

        TempData["ContactSuccess"] = "Thanks — your message has been sent.";
        return RedirectToAction(nameof(Index));
    }
}