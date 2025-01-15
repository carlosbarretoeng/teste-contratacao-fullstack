using application.DTOs;

namespace application.Interfaces;

public interface IVehicleService
{
    Task<IEnumerable<VehicleDto>> GetAll();
    Task<VehicleDto> GetByPlate(string? plate);
    
    Task<VehicleDto> Create(VehicleDto vehicle);
    Task<VehicleDto> Update(VehicleDto vehicle);
    Task<VehicleDto?> Delete(string? plate);
}