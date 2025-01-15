using domain.Entities;
using domain.Interfaces;
using infra.data.Context;
using Microsoft.EntityFrameworkCore;

namespace infra.data.Repositories;

public class VehicleRepository(ApplicationDbContext context) : IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
    {
        return await context.Vehicle.ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleByPlateAsync(string? plate)
    {
        return await context.Vehicle.FindAsync(keyValues: plate);
    }

    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        context.Add(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        context.Update(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> DeleteAsync(Vehicle vehicle)
    {
        context.Remove(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }
}