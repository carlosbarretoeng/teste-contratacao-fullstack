using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using domain.Authentication;
using domain.Entities;
using infra.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace infra.data.Authentication;

public class AuthenticateService(ApplicationDbContext context, IConfiguration configuration) : IAuthenticate
{
    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        var user = await context.User
            .Where(x => x.Username.ToLower().Equals(username.ToLower()))
            .FirstOrDefaultAsync();
        switch (user)
        {
            case null:
            case { PasswordSalt: null, PasswordHash: null }:
                return false;
            case { PasswordSalt: not null, PasswordHash: not null }:
            {
                using var hmac = new HMACSHA3_256(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return !computedHash.Where((t, i) => t != user.PasswordHash[i]).Any();
            }
            default: return false;
        }
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        var user = await context.User
            .Where(x => x.Username.ToLower().Equals(username.ToLower()))
            .FirstOrDefaultAsync();
        return user != null;
    }

    public string GenerateJwtToken(int id, string username)
    {
        var claims = new Claim[]
        {
            new Claim("id", id.ToString()),
            new Claim("username", username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secretKey"]!));
        
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:issuer"],
            audience: configuration["JWT:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await context.User.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
    }
}