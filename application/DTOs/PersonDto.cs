using System.ComponentModel.DataAnnotations;

namespace application.DTOs;

public class PersonDto
{
    public string TaxNumber { get; set; }
    [Required]
    public string Name { get; set; }
}