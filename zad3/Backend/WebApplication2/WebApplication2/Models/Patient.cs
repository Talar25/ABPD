using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication2.Models;

[Table(nameof(Patient))]
public class Patient
{
    [Key] public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; }
    [MaxLength(100)] public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}