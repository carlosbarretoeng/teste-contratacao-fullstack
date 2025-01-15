using application.DTOs;

namespace application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDto> GetById(int? id);
    
    Task<UserDto> Create(UserDto person);
    Task<UserDto> Update(UserDto person);
    Task<UserDto?> Delete(int? id);
}