using application.DTOs;
using application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController(IVehicleService vehicleService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await vehicleService.GetAll();
        return Ok(vehicles);
    }
    
    [HttpGet("{plate}")]
    public async Task<IActionResult> GetByPlate(string? plate)
    {
        var vehicle = await vehicleService.GetByPlate(plate);
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehicleDto vehicleDto)
    {
        await vehicleService.Create(vehicleDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(VehicleDto vehicleDto)
    {
        await vehicleService.Update(vehicleDto);
        return Ok();
    }

    [HttpDelete("{plate}")]
    public async Task<IActionResult> Delete(string? plate)
    {
        await vehicleService.Delete(plate);
        return Ok();
    }
}