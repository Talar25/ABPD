using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly PrescriptionService _prescriptionService;

    public PrescriptionsController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrescription(int id)
    {
        var prescription = await _prescriptionService.GetPrescriptionAsync(id);
        if (prescription == null)
        {
            return NotFound();
        }
        return Ok(prescription);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDTO dto)
    {
        try
        {
            var prescription = await _prescriptionService.CreatePrescriptionAsync(dto);
            if (prescription == null) return BadRequest("Nie można utworzyć recepty");
            return Ok(prescription);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}