using domain.Entities;

namespace domain.Authentication;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string username, string password);
    Task<bool> UserExistsAsync(string username);
    public string GenerateJwtToken(int id, string username);
    public Task<User?> GetUserByUsername(string username);
}