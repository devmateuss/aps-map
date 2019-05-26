using System.Threading.Tasks;
using Aps.Domain;
using Aps.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IApsRepository _repository { get; }
        public StudentController(IApsRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllStudentsAsync();
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
                var result = await _repository.GetAllStudentsAsyncById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student item)
        {
            try
            {
                _repository.Add(item);
                if(await _repository.SaveChangesAsync())
                {
                    return Created($"/api/student/{item.Id}", item);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id ,Student item)
        {
            try
            {
                var student = await _repository.GetAllStudentsAsyncById(id);
                if(student == null) return NotFound();

                _repository.Updade(item);
                if(await _repository.SaveChangesAsync())
                {
                    return Created($"/api/student/{item.Id}", item);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            try
            {
                var student = await _repository.GetAllStudentsAsyncById(id);
                if(student == null) return NotFound();
                
                _repository.Delete(student);
                if(await _repository.SaveChangesAsync())
                {
                    return Ok("Deletato com sucesso!!!!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }
    }
}