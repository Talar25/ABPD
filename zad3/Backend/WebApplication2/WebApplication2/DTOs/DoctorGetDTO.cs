using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class DoctorGetDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}