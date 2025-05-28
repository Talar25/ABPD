using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table(nameof(Prescription_Medicament))]
public class Prescription_Medicament
{
    [ForeignKey(nameof(Medicament))] public int IdMedicament { get; set; }
    [ForeignKey(nameof(Prescription))] public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)] public string Details { get; set; }
    
    public virtual Medicament Medicament { get; set; } = null!;
    public virtual Prescription Prescription { get; set; } = null!;
}