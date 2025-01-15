using application.DTOs;
using application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await personService.GetAll();
        return Ok(people);
    }
    
    [HttpGet("{taxNumber}")]
    public async Task<IActionResult> GetByTaxNumber(string? taxNumber)
    {
        var person = await personService.GetByTaxNumber(taxNumber);
        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PersonDto personDto)
    {
        await personService.Create(personDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(PersonDto personDto)
    {
        await personService.Update(personDto);
        return Ok();
    }

    [HttpDelete("{taxNumber}")]
    public async Task<IActionResult> Delete(string? taxNumber)
    {
        await personService.Delete(taxNumber);
        return Ok();
    }
}