using application.DTOs;
using application.Interfaces;
using AutoMapper;
using domain.Entities;
using domain.Interfaces;

namespace application.Services;

public class VehicleService(
    IPersonRepository personRepository,
    IVehicleRepository vehicleRepository, 
    IMapper mapper
) : IVehicleService
{
    public async Task<IEnumerable<VehicleDto>> GetAll()
    {
        var vehiclesEntity = await vehicleRepository.GetVehiclesAsync();
        foreach (var vehicle in vehiclesEntity)
        {
            vehicle.Person = personRepository.GetPersonByTaxNumberAsync(vehicle.PersonId).Result;
        }
        return mapper.Map<IEnumerable<VehicleDto>>(vehiclesEntity);
    }

    public async Task<VehicleDto> GetByPlate(string? plate)
    {
        var vehicleEntity = await vehicleRepository.GetVehicleByPlateAsync(plate);
        return mapper.Map<VehicleDto>(vehicleEntity);
    }

    public async Task<VehicleDto> Create(VehicleDto vehicle)
    {
        var vehicleEntity = mapper.Map<Vehicle>(vehicle);
        await vehicleRepository.CreateAsync(vehicleEntity);
        return vehicle;
    }

    public async Task<VehicleDto> Update(VehicleDto vehicle)
    {
        var vehicleEntity = mapper.Map<Vehicle>(vehicle);
        await vehicleRepository.UpdateAsync(vehicleEntity);
        return vehicle;
    }

    public async Task<VehicleDto?> Delete(string? plate)
    {
        var vehicleEntity = vehicleRepository.GetVehicleByPlateAsync(plate).Result;
        if (vehicleEntity != null) await vehicleRepository.DeleteAsync(vehicleEntity);
        else return null;
        return mapper.Map<VehicleDto>(vehicleEntity);
    }
}