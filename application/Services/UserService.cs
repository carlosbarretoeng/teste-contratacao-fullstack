using System.Security.Cryptography;
using System.Text;
using application.DTOs;
using application.Interfaces;
using AutoMapper;
using domain.Entities;
using domain.Interfaces;

namespace application.Services;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        var peopleEntity = await userRepository.GetUsersAsync();
        return mapper.Map<IEnumerable<UserDto>>(peopleEntity);
    }

    public async Task<UserDto> GetById(int? id)
    {
        var userEntity = await userRepository.GetUserById(id);
        return mapper.Map<UserDto>(userEntity);
    }

    public async Task<UserDto> Create(UserDto user)
    {
        var userEntity = mapper.Map<User>(user);

        using var hmac = new HMACSHA256();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
        byte[] passwordSalt = hmac.Key;
        
        userEntity.ChangePassword(passwordHash, passwordSalt);
        
        var newUser = await userRepository.CreateAsync(userEntity);
        return mapper.Map<UserDto>(newUser);
    }

    public async Task<UserDto> Update(UserDto user)
    {
        var userEntity = mapper.Map<User>(user);
        await userRepository.UpdateAsync(userEntity);
        return user;
    }

    public async Task<UserDto?> Delete(int? id)
    {
        var userEntity = userRepository.GetUserById(id).Result;
        if (userEntity != null) await userRepository.DeleteAsync(userEntity);
        else return null;
        return mapper.Map<UserDto>(userEntity);
    }
}