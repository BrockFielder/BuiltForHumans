using BulitForHumans.Models;

namespace BuiltForHumans.Services;

public interface IPersonService
{
    // GetAllPersons() - for the team/about page
    Task<IEnumerable<Person>> GetAllPersonsAsync();

    // GetCurrentMembers() - filtered by your Status field
    Task<IEnumerable<Person>> GetCurrentMembersAsync();

    // GetLegacyMembers() - filtered by your Status field
    Task<IEnumerable<Person>> GetLegacyMembersAsync();

    // GetPersonByID()
    Task<Person?> GetPersonByIdAsync(int id);
}