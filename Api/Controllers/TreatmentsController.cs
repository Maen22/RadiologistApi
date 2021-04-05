using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Models.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly PatientDbContext _context;

        public TreatmentsController(PatientDbContext context)
        {
            _context = context;
        }

        // GET: api/Treatments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatments()
        {
            return await _context.Treatments.ToListAsync();
        }

        [HttpGet("patient/{id}")]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatmentsByPatientId(int id)
        {
            var treatments = await _context.Treatments.Where(treatment => treatment.PatientId == id
                ).Include(p => p.TreatmentType)
                .ToListAsync();

            var result = new List<TreatmentViewModel>();
            foreach (var treatment in treatments)
            {

                result.Add(new TreatmentViewModel()
                {
                    TreatmentId = treatment.TreatmentId,
                    UserId = treatment.UserId,
                    TreatmentCost = treatment.TreatmentCost,
                    CreatedAt = treatment.CreatedAt,
                    TreatmentImageUrl = treatment.TreatmentImageUrl,
                    TreatmentImageName = treatment.TreatmentImageName,
                    PatientId = treatment.PatientId,
                    TreatmentName = treatment.TreatmentType.Name,
                    TreatmentTypeId = treatment.TreatmentTypeId
                });
            }


            return Ok(result);
        }

        // GET: api/Treatments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Treatment>> GetTreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);

            if (treatment == null)
            {
                return NotFound();
            }

            return treatment;
        }

        // PUT: api/Treatments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<TreatmentViewModel>> PutTreatment(int id, Treatment treatment)
        {
            if (id != treatment.TreatmentId)
            {
                System.Console.WriteLine("Hello from Error");
                return BadRequest();
            }

            _context.Entry(treatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var treatmentType = await _context.TreatmentTypes.FindAsync(treatment.TreatmentTypeId);
            var t = await _context.Treatments.FindAsync(id);


            var result = new TreatmentViewModel()
            {
                TreatmentId = t.TreatmentId,
                UserId = t.UserId,
                TreatmentCost = t.TreatmentCost,
                CreatedAt = t.CreatedAt,
                TreatmentImageUrl = t.TreatmentImageUrl,
                TreatmentImageName = t.TreatmentImageName,
                PatientId = t.PatientId,
                TreatmentName = treatmentType.Name,
                TreatmentTypeId = t.TreatmentTypeId
            };

            return result;
        }

        // POST: api/Treatments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            treatment.CreatedAt = DateTime.Now;
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();

            var treatmentType = await _context.TreatmentTypes.FindAsync(treatment.TreatmentTypeId);


            var result = new TreatmentViewModel()
            {
                TreatmentId = treatment.TreatmentId,
                UserId = treatment.UserId,
                TreatmentCost = treatment.TreatmentCost,
                CreatedAt = treatment.CreatedAt,
                TreatmentImageUrl = treatment.TreatmentImageUrl,
                TreatmentImageName = treatment.TreatmentImageName,
                PatientId = treatment.PatientId,
                TreatmentName = treatmentType.Name,
                TreatmentTypeId = treatment.TreatmentTypeId
            };

            return CreatedAtAction("GetTreatment", new { id = treatment.TreatmentId }, result);
        }

        // DELETE: api/Treatments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatments.Any(e => e.TreatmentId == id);
        }
    }
}