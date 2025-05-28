using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IPrescriptionService
{
    Task<PrescriptionGetDTO?> GetPrescriptionAsync(int id);
}

public class PrescriptionService : IPrescriptionService
{
    private readonly AppDbContext _dbContext;

    public PrescriptionService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PrescriptionGetDTO?> GetPrescriptionAsync(int id)
    {
        var prescription = await _dbContext.Prescriptions
            .Include(p => p.Doctor)
            .Include(p => p.Patient)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPrescription == id);

        if (prescription == null)
            return null;

        var result = new PrescriptionGetDTO
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Doctor = new DoctorGetDTO()
            {
                IdDoctor = prescription.Doctor.IdDoctor,
                FirstName = prescription.Doctor.FirstName,
                LastName = prescription.Doctor.LastName,
                Email = prescription.Doctor.Email
            },
            Patient = new PatientGetDTO()
            {
                IdPatient = prescription.Patient.IdPatient,
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                BirthDate = prescription.Patient.DateOfBirth
            },
            PrescriptionMedicaments = prescription.PrescriptionMedicaments
                .Select(pm => new Prescription_MedicamentGetDto()
                {
                    Dose = pm.Dose,
                    Details = pm.Details,
                    Medicament = new MedicamentGetDTO()
                    {
                        IdMedicament = pm.Medicament.idMedicament,
                        Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description,
                        Type = pm.Medicament.Type
                    }
                }).ToList()
        };

        return result;
    }
    
    public async Task<Prescription?> CreatePrescriptionAsync(PrescriptionCreateDTO dto)
{
    if (dto.DueDate < dto.Date)
        throw new ArgumentException("DueDate musi być późniejsza lub równa Date");
    
    var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == dto.Patient.IdPatient);
    if (patient == null)
    {
        patient = new Patient
        {
            FirstName = dto.Patient.FirstName,
            LastName = dto.Patient.LastName,
            DateOfBirth = dto.Patient.BirthDate
        };
        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync();
    }
    
    if (dto.MedicamentIds.Count > 10)
        throw new ArgumentException("Recepta może obejmować maksymalnie 10 leków.");

    var medicaments = await _dbContext.Medicaments
        .Where(m => dto.MedicamentIds.Contains(m.idMedicament))
        .ToListAsync();

    if (medicaments.Count != dto.MedicamentIds.Count)
        throw new ArgumentException("Jeden lub więcej leków nie istnieje.");
    
    var prescription = new Prescription
    {
        Date = dto.Date,
        DueDate = dto.DueDate,
        Patient = patient,
        IdDoctor = dto.DoctorId,
        PrescriptionMedicaments = new List<Prescription_Medicament>()
    };
    
    for (int i = 0; i < dto.MedicamentIds.Count; i++)
    {
        var medId = dto.MedicamentIds[i];
        var dose = dto.Doses[i];
        var details = dto.Details[i];

        var medicament = medicaments.First(m => m.idMedicament == medId);

        prescription.PrescriptionMedicaments.Add(new Prescription_Medicament
        {
            Dose = dose,
            Details = details,
            IdMedicament = medicament.idMedicament
        });
    }

    _dbContext.Prescriptions.Add(prescription);
    await _dbContext.SaveChangesAsync();

    return prescription;
}


}