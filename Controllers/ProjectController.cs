namespace BulitForHumans.Controllers;
using Microsoft.AspNetCore.Mvc;
using BulitForHumans.Models;

[Route("projects")]
public class ProjectController : Controller
{
    //private readonly IProjectService _projectService; Not implemented
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
    {
        Project project = _projectService.GetProjectByIdAsync(id);
        
        if (project == null){return NotFound();}
        
        return View(project);
    }
    
}