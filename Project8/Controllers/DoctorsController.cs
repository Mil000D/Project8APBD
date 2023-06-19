using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie8.DTO;
using Zadanie8.Mapper;
using Zadanie8.Models;

namespace Zadanie8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        public readonly MainDbContext _context;
        public readonly IMapDoctorToDTO _mapDoctorToDTO;
        public DoctorsController(MainDbContext context, IMapDoctorToDTO mapDoctorToDTO)
        {
            _context = context;
            _mapDoctorToDTO = mapDoctorToDTO;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorDTO1 doctorDTO)
        {
            var doctor = new Doctor
            {
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                EmailAddress = doctorDTO.EmailAddress
            };
            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return Ok("Succesful creation of doctor");
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _context.Doctors.AsNoTracking()
                                                .Include(d => d.Prescriptions)
                                                .ThenInclude(p => p.Patient)
                                                .ToListAsync();
            var doctorsDTO = _mapDoctorToDTO.ResponseDoctors(doctors);
            return Ok(doctorsDTO);
        }

        [HttpGet("{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            var doctor = await _context.Doctors.AsNoTracking()
                                               .Include(d => d.Prescriptions)
                                               .ThenInclude(p => p.Patient)
                                               .FirstOrDefaultAsync(d => d.IdDoctor == idDoctor);
            if (doctor == null)
            {
                return BadRequest($"There is no doctor with specified id: {idDoctor}");
            }
            var doctorDto = _mapDoctorToDTO.ResponseDoctor(doctor);
            return Ok(doctorDto);
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctor(int idDoctor, DoctorDTO1 doctorDTO)
        {
            var doctor = await _context.Doctors.FindAsync(idDoctor);
            if (doctor == null)
            {
                return BadRequest($"There is no doctor with specified id: {idDoctor}");
            }
            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.EmailAddress = doctorDTO.EmailAddress;

            await _context.SaveChangesAsync();

            return Ok("Succesful update of doctor");
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            try
            {
                var doctor = new Doctor
                {
                    IdDoctor = idDoctor
                };
                _context.Attach(doctor);
                _context.Doctors.Entry(doctor).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return BadRequest("Deletion of doctor unsuccesful");
            }
            return Ok("Succesful deletion of doctor");
        }
    }
}
