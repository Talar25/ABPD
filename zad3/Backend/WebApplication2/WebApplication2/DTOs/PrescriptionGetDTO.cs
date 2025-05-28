namespace WebApplication2.DTOs;

public class PrescriptionGetDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorGetDTO Doctor { get; set; }
    public PatientGetDTO Patient { get; set; }
    public List<Prescription_MedicamentGetDto> PrescriptionMedicaments { get; set; }
}