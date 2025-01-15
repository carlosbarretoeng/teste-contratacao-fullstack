using domain.Entities;

namespace domain.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetPeopleAsync();
    Task<Person?> GetPersonByTaxNumberAsync(string? taxNumber);
    
    Task<Person> CreateAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<Person> DeleteAsync(Person person);
}