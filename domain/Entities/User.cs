using domain.Validations;

namespace domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public byte[]? PasswordHash { get; private set; }
    public byte[]? PasswordSalt { get; private set; }

    public User(int id, string username)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty("" + id), "Id cannot be null or empty.");
        DomainExceptionValidation.When(id < 0, "Id cannot be negative.");
        ValidateDomain(username);
        
        Id = id;
        Username = username;
    }
    
    public User(string username)
    {
        ValidateDomain(username);
        
        Username = username;
    }
    
    private static void ValidateDomain(string username)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(username), "Username cannot be empty.");
    }
    
    public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}