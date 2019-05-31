using System;
using System.Threading.Tasks;
using Aps.Domain;
using Aps.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        public ApsContext _context { get; }
        public DisciplineController(ApsContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Disciplines.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _context.Disciplines.FirstOrDefaultAsync(teacher => teacher.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Discipline>> Post(Discipline item)
        {
            _context.Disciplines.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Discipline>> Put(int id ,Discipline item)
        {
            var discipline = await _context.Disciplines.FirstOrDefaultAsync(t => t.Id == id);

            if(discipline != null) Console.WriteLine("DEU CERTO");

            

            _context.Disciplines.Update(discipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Discipline>> Delete(int id)
        {
            try
            {
                var discipline = await _context.Disciplines.FirstOrDefaultAsync(t => t.Id == id);

                if(discipline == null){

                    return NotFound();

                } else {

                    _context.Remove(discipline);
                    return Ok("Deletato com sucesso!!!!");
                    
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }
    }
}