using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [NotMapped]
    public string Password { get; set; }
}