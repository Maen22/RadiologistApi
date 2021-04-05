using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentTypesController : ControllerBase
    {
        private readonly PatientDbContext _context;

        public TreatmentTypesController(PatientDbContext context)
        {
            _context = context;
        }

        // GET: api/TreatmentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentType>>> GetTreatmentTypes()
        {
            return await _context.TreatmentTypes.ToListAsync();
        }

        // GET: api/TreatmentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentType>> GetTreatmentType(int id)
        {
            var treatmentType = await _context.TreatmentTypes.FindAsync(id);

            if (treatmentType == null)
            {
                return NotFound();
            }

            return treatmentType;
        }

        // PUT: api/TreatmentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatmentType(int id, TreatmentType treatmentType)
        {
            if (id != treatmentType.TreatmentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(treatmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentTypeExists(id))
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

        // POST: api/TreatmentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TreatmentType>> PostTreatmentType(TreatmentType treatmentType)
        {
            _context.TreatmentTypes.Add(treatmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreatmentType", new { id = treatmentType.TreatmentTypeId }, treatmentType);
        }

        // DELETE: api/TreatmentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatmentType(int id)
        {
            var treatmentType = await _context.TreatmentTypes.FindAsync(id);
            if (treatmentType == null)
            {
                return NotFound();
            }

            _context.TreatmentTypes.Remove(treatmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreatmentTypeExists(int id)
        {
            return _context.TreatmentTypes.Any(e => e.TreatmentTypeId == id);
        }
    }
}
