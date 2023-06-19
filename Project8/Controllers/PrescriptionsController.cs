using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie8.Mapper;
using Zadanie8.Models;

namespace Zadanie8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        public readonly MainDbContext _context;
        public readonly IMapPrescriptionToDTO _mapPrescriptionToDTO;
        public PrescriptionsController(MainDbContext context, IMapPrescriptionToDTO mapPrescriptionToDTO) 
        {
            _context = context;
            _mapPrescriptionToDTO = mapPrescriptionToDTO;
        }
        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            var prescription = await _context.Prescriptions.AsNoTracking()
                                             .Include(p => p.Patient)
                                             .Include(p => p.Doctor)
                                             .Include(p => p.PrescriptionMedicaments)
                                             .ThenInclude(pm => pm.Medicament)
                                             .FirstOrDefaultAsync(p => p.IdPrescription == idPrescription);
            if(prescription == null)
            {
                return BadRequest($"There is no prescription with specified id: {idPrescription}");
            }
            var prescriptionDTO = _mapPrescriptionToDTO.ResponsePrescription(prescription);
            return Ok(prescriptionDTO);
        }
    }
}
