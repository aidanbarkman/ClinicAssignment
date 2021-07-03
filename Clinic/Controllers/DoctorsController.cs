using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return _context.Doctors.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            var doctors = _context.Doctors.Find(id);

            if (doctors == null)
            {
                return NotFound();
            }

            return new Doctor
            {
                Id = doctors.Id,
                Name = doctors.Name
            };
        }

        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(
                new Doctor
                {
                    Id = doctor.Id,
                    Name = doctor.Name
                }
                ).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Doctor> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(
                new Doctor
                {
                    Id = doctor.Id,
                    Name = doctor.Name
                }
                );
            _context.SaveChanges();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}