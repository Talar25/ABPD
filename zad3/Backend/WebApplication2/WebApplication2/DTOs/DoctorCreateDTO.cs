using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class DoctorCreateDTO
{
    [MaxLength(100)] public string FirstName { get; set; } 
    [MaxLength(100)] public string LastName { get; set; } 
    [MaxLength(100)] public string Email { get; set; }
}