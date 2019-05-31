using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TeacherController : ControllerBase
    {
        public ApsContext _context { get; }
        public TeacherController(ApsContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // IQueryable<Teacher> query = _context.Teachers
                //     .Include(T => T.GetDisciplines());

                var results = await _context.Teachers.ToListAsync();
                
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
                var results = await _context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> Post(Teacher item)
        {
            _context.Teachers.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> Put(int id ,Teacher item)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> Delete(int id)
        {
            try
            {
                var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

                if(teacher == null){

                    return NotFound();

                } else {

                    _context.Teachers.Remove(teacher);
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
