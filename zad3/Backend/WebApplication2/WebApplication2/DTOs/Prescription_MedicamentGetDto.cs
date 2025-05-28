using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class Prescription_MedicamentGetDto
{
    public int? Dose { get; set; }
    public string Details { get; set; }
    public MedicamentGetDTO Medicament { get; set; }
    public PrescriptionGetDTO Prescription { get; set; }
}