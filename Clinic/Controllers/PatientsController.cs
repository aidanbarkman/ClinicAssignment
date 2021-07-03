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
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public PatientsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _context.Patients.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return new Patient
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                HealthNumber = patient.HealthNumber,
                Address = patient.Address,
                PhoneNumber = patient.PhoneNumber
            };
        }

        [HttpPut("{id}")]
        public IActionResult PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(
                new Patient
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    DateOfBirth = patient.DateOfBirth,
                    HealthNumber = patient.HealthNumber,
                    Address = patient.Address,
                    PhoneNumber = patient.PhoneNumber
                }
                ).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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
        public void Post([FromBody] Patient value)
        {
            int id = _context.Patients.Max(p => p.Id) + 1;

            Patient newPatient = new Patient
            {
                Id = id,
                Name = value.Name,
                Address = value.Address,
                HealthNumber = value.HealthNumber,
                DateOfBirth = value.DateOfBirth,
                PhoneNumber = value.PhoneNumber
            };

            _context.Patients.Add(newPatient);
            _context.SaveChanges();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}