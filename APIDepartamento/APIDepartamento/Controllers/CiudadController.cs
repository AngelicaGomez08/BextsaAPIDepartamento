using APIDepartamento.Data;
using APIDepartamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDepartamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CiudadController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudades()
        {
            return await _context.Ciudad
                .Include(c => c.Departamento)
                .ThenInclude(d => d.Pais)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudad>> GetCiudad(int id)
        {
            var ciudad = await _context.Ciudad
                .Include(c => c.Departamento)
                .ThenInclude(d => d.Pais)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (ciudad == null)
                return NotFound();

            return ciudad;
        }

        [HttpPost]
        public async Task<ActionResult<Ciudad>> PostCiudad(Ciudad ciudad)
        {
            _context.Ciudad.Add(ciudad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCiudad", new { id = ciudad.Id }, ciudad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudad(int id, Ciudad ciudad)
        {
            if (id != ciudad.Id)
                return BadRequest();

            _context.Entry(ciudad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudad(int id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
                return NotFound();

            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
