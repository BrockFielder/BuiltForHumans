using BulitForHumans.Data;
using BulitForHumans.Models;
using BuiltForHumans.Services;  
using Microsoft.EntityFrameworkCore;

namespace BulitForHumans.Services;

public class PersonService : IPersonService   
{
    private readonly AppDbContext _db;
    public PersonService(AppDbContext db) => _db = db;
    
    public async Task<IEnumerable<Person>> GetAllPersonsAsync() =>
        await _db.Persons
            .OrderByDescending(p => p.StartDate)
            .ToListAsync(); 
    
    public async Task<IEnumerable<Person>> GetCurrentMembersAsync()=>
        await _db.Persons
            .Where(p => p.ActiveEmployee == true)
            .OrderByDescending(p => p.StartDate)
            .ToListAsync();
    
    public async Task<IEnumerable<Person>> GetLegacyMembersAsync()=>
        await _db.Persons
            .Where(p => p.ActiveEmployee == false)
            .OrderByDescending(p => p.StartDate)
            .ToListAsync();

    public async Task<Person?> GetPersonByIdAsync(int id)=>
        await _db.Persons
            .Where(p => p.Id == id)
            .OrderByDescending(p => p.StartDate)
            .FirstOrDefaultAsync();
}