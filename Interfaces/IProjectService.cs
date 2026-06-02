using BulitForHumans.Models;

namespace BulitForHumans.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetProjectAsync(int projectId); // Changed to Project? since FirstOrDefaultAsync can return null
    Task<List<Project>> GetFeaturedProjectsAsync();
    Task<List<Project>> GetProjectsByTagAsync(int tagId);
    //Task<List<Project>> SearchProjectsAsync(string term);
    Task<List<Tag>> GetAllTagsAsync();
    Task<Tag?> GetTagByIdAsync(int id);
}