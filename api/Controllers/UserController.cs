using api.Models;
using application.DTOs;
using application.Interfaces;
using domain.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IAuthenticate _authenticateService;
    private readonly IUserService _userService;

    public UserController(IAuthenticate authenticateService, IUserService userService)
    {
        _authenticateService = authenticateService; 
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserToken>> Login(LoginModel loginModel)
    {
        var exists = await _authenticateService.UserExistsAsync(loginModel.Username);
        if(!exists) return Unauthorized("Username or password is incorrect");
        
        var result = await _authenticateService.AuthenticateAsync(loginModel.Username, loginModel.Password);
        if(result == null) return Unauthorized("Username or password is incorrect");

        var user = await _authenticateService.GetUserByUsername(loginModel.Username);
        var token = _authenticateService.GenerateJwtToken(user!.Id, user.Username);

        return new UserToken()
        {
            Token = token,
        };
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserToken>> Register(UserDto userDto)
    {
        if(userDto == null) return BadRequest("User is null");
        if(await _authenticateService.UserExistsAsync(userDto.Username)) return BadRequest("Username already exists");
        
        var user = await _userService.Create(userDto);
        
        if(user == null) return BadRequest("Error while registering");
        
        var token = _authenticateService.GenerateJwtToken(user.Id, user.Username);
        return new UserToken()
        {
            Token = token,
        };
    }
}