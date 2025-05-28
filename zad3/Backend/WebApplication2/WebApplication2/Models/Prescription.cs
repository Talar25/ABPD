using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace WebApplication2.Models;

public class Prescription
{
    [Key] public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [ForeignKey(nameof(Patient))] public int IdPatient { get; set; }
    [ForeignKey(nameof(Doctor))] public int IdDoctor { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}