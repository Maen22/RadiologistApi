using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Models.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientDbContext _context;

        public PatientsController(PatientDbContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientViewModel>>> GetPatients()
        {
            var patients = await _context.Patients.Include(p => p.Treatments)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            var result = new List<PatientViewModel>();
            foreach (var patient in patients)
            {
                var totalCost = patient.Treatments.Sum(t => t.TreatmentCost);
                result.Add(new PatientViewModel()
                {
                    PatientId = patient.PatientId,
                    UserId = patient.UserId,
                    Age = patient.Age,
                    Gender = patient.Gender,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    PhoneNumber = patient.PhoneNumber,
                    TotalTreatmentCost = totalCost,
                    CreatedAt = patient.CreatedAt
                });
            }

            return Ok(result);
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Patient>> PutPatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            var result = await _context.Patients.FindAsync(id);

            return result;
        }

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            patient.CreatedAt = DateTime.Now;
            Console.WriteLine(patient.CreatedAt);
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}