using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDoctorService
{
    Task<ICollection<Doctor>> GetDoctors();
    Task<Doctor?> GetDoctorAsync(int id);
    Task<Doctor> AddDoctorAsync(Doctor doctor);
    Task<Doctor?> UpdateDoctorAsync(int id, Doctor doctor);
    Task<bool> DeleteDoctorAsync(int id);
}

public class DoctorService(AppDbContext data) : IDoctorService
{
    public Task<ICollection<Doctor>> GetDoctors()
    {
        return Task.FromResult<ICollection<Doctor>>(data.Doctors.ToList());
    }

    public async Task<Doctor?> GetDoctorAsync(int id)
    {
        return await data.Doctors.FindAsync(id);
    }

    public async Task<Doctor> AddDoctorAsync(Doctor doctor)
    {
        data.Doctors.Add(doctor);
        await data.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> UpdateDoctorAsync(int id, Doctor doctor)
    {
        var choosenDoctor = await data.Doctors.FindAsync(id);
        if (choosenDoctor == null) return null;

        choosenDoctor.FirstName = doctor.FirstName;
        choosenDoctor.LastName = doctor.LastName;
        choosenDoctor.Email = doctor.Email;
        data.Doctors.Update(choosenDoctor);
        await data.SaveChangesAsync();

        return choosenDoctor;
    }

    public async Task<bool> DeleteDoctorAsync(int id)
    {
        var choosenDoctor = await data.Doctors.FindAsync(id);
        if (choosenDoctor == null) return false;
        data.Doctors.Remove(choosenDoctor);
        await data.SaveChangesAsync();
        return true;
    }
}