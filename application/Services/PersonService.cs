using application.DTOs;
using application.Interfaces;
using AutoMapper;
using domain.Entities;
using domain.Interfaces;

namespace application.Services;

public class PersonService(IPersonRepository personRepository, IMapper mapper) : IPersonService
{
    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        var peopleEntity = await personRepository.GetPeopleAsync();
        return mapper.Map<IEnumerable<PersonDto>>(peopleEntity);
    }

    public async Task<PersonDto> GetByTaxNumber(string? taxNumber)
    {
        var personEntity = await personRepository.GetPersonByTaxNumberAsync(taxNumber);
        return mapper.Map<PersonDto>(personEntity);
    }

    public async Task<PersonDto> Create(PersonDto person)
    {
        var personEntity = mapper.Map<Person>(person);
        await personRepository.CreateAsync(personEntity);
        return person;
    }

    public async Task<PersonDto> Update(PersonDto person)
    {
        var personEntity = mapper.Map<Person>(person);
        await personRepository.UpdateAsync(personEntity);
        return person;
    }

    public async Task<PersonDto?> Delete(string? taxNumber)
    {
        var personEntity = personRepository.GetPersonByTaxNumberAsync(taxNumber).Result;
        if (personEntity != null) await personRepository.DeleteAsync(personEntity);
        else return null;
        return mapper.Map<PersonDto>(personEntity);
    }
}