using BulitForHumans.Services;

namespace BulitForHumans.Controllers;
using Microsoft.AspNetCore.Mvc;
using BulitForHumans.Models;

[Route("projects")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService; 
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return View(projects);
    }

    [HttpGet("{id:int}")]
    public async Task <IActionResult> GetProjectAsync(int id)
    {
        Project project = await _projectService.GetProjectAsync(id);
        
        if (project == null){return NotFound();}
        
        return View(project);
    }
    
}