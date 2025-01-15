using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.DTOs;

public class VehicleDto
{
    public string Plate { get; set; }
    [Required]
    public string Model { get; set; }
    public string PersonId { get; set; }
    [NotMapped]
    public PersonDto Person { get; set; }
}