using BuiltForHumans.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulitForHumans.Controllers;

[Route("team")]
public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) => _personService = personService;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var members = await _personService.GetAllPersonsAsync();
        return View(members);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detail(int id)
    {
        var person = await _personService.GetPersonByIdAsync(id);
        if (person is null) return NotFound();
        return View(person);
    }
}