using domain.Entities;

namespace domain.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetVehiclesAsync();
    Task<Vehicle?> GetVehicleByPlateAsync(string? plate);

    Task<Vehicle> CreateAsync(Vehicle vehicle);
    Task<Vehicle> UpdateAsync(Vehicle vehicle);
    Task<Vehicle?> DeleteAsync(Vehicle vehicle);
}