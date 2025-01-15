using domain.Entities;
using domain.Interfaces;
using infra.data.Context;
using Microsoft.EntityFrameworkCore;

namespace infra.data.Repositories;

public class PersonRepository(ApplicationDbContext context) : IPersonRepository
{
    public async Task<IEnumerable<Person>> GetPeopleAsync()
    {
        return await context.Person.ToListAsync();
    }

    public async Task<Person?> GetPersonByTaxNumberAsync(string? taxNumber)
    {
        return await context.Person.FindAsync(keyValues: taxNumber);
    }

    public async Task<Person> CreateAsync(Person person)
    {
        context.Add(person);
        await context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
        context.Update(person);
        await context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> DeleteAsync(Person person)
    {
        context.Remove(person);
        await context.SaveChangesAsync();
        return person;
    }
}