using BulitForHumans.Models;

namespace BuiltForHumans.Services;

public interface ITagService
{
    // GetAllTags() - Gets all the tags
    Task<IEnumerable<Tag>> GetAllTagsAsync();

    // GetTagById() - searches for a tag by Id
    Task<Tag?> GetTagByIdAsync(int id);
}