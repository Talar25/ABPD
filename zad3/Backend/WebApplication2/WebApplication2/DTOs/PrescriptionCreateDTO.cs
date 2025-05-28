namespace WebApplication2.DTOs;

public class PrescriptionCreateDTO
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientGetDTO Patient { get; set; }
    public int DoctorId { get; set; }
    public List<int> MedicamentIds { get; set; }
    public List<int> Doses { get; set; }
    public List<string> Details { get; set; }
}
