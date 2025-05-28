using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var doctors = await _doctorService.GetDoctors();
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var doctor = await _doctorService.GetDoctorAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Doctor doctor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var newDoctor = new Doctor
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };

        var addedDoctor = await _doctorService.AddDoctorAsync(newDoctor);
        return CreatedAtAction(nameof(Get), new { id = addedDoctor.IdDoctor }, addedDoctor);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Doctor doctor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updateDoctor = await _doctorService.UpdateDoctorAsync(id, doctor);

        if (updateDoctor == null)
        {
            return NotFound();
        }

        return Ok(updateDoctor);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _doctorService.DeleteDoctorAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return Ok();
    }
}