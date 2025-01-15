using domain.Entities;
using domain.Interfaces;
using infra.data.Context;
using Microsoft.EntityFrameworkCore;

namespace infra.data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.User.ToListAsync();
    }

    public async Task<User?> GetUserById(int? id)
    {
        return await context.User.FindAsync(keyValues: id);
    }

    public async Task<User> CreateAsync(User user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteAsync(User user)
    {
        context.Remove(user);
        await context.SaveChangesAsync();
        return user;
    }
}