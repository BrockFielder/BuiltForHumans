using Microsoft.EntityFrameworkCore;
using BulitForHumans.Data;     // AppDbContext
using BulitForHumans.Models; 

namespace BulitForHumans.Services;


public class ProjectService : IProjectService
{
    private readonly AppDbContext _db;
    public ProjectService(AppDbContext db) => _db = db;
    
    public async Task<List<Project>> GetAllProjectsAsync() =>
        await _db.Projects
            .Include(p => p.Images)
            .OrderByDescending(p => p.StartDate)
            .ToListAsync();

    public async Task<Project> GetProjectAsync(int projectId) =>
        await _db.Projects
            .Include(p => p.Images)
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == projectId);
    
    public async Task<List<Project>> GetFeaturedProjectsAsync() =>
        await _db.Projects
            .Include(p => p.Images)
            .Where(p => p.IsFeatured)
            .ToListAsync();

    public async Task<List<Project>> GetProjectsByTagAsync(int tagId) =>
        await _db.Projects
            .Include(p => p.Images)
            .Where(p => p.Tags.Any(t => t.Id == tagId))
            .ToListAsync();
    
    public async Task<List<Tag>> GetAllTagsAsync() =>
        await _db.Tags.OrderBy(t => t.Name).ToListAsync();

    public async Task<Tag?> GetTagByIdAsync(int id) =>
        await _db.Tags.FindAsync(id);
}