using application.DTOs;

namespace application.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> GetAll();
    Task<PersonDto> GetByTaxNumber(string? taxNumber);
    
    Task<PersonDto> Create(PersonDto person);
    Task<PersonDto> Update(PersonDto person);
    Task<PersonDto?> Delete(string? taxNumber);
}