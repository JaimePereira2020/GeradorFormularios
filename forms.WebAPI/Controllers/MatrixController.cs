using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using forms.WebAPI.Data;
using forms.WebAPI.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace forms.WebAPI.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
         private readonly DataContext _context;

        public MatrixController(DataContext context)
        {
            _context = context;
        }
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Matrix.ToListAsync();
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }
        //GET by ID
        [HttpGet("{id}")]

       
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var results = await _context.Matrix.FirstOrDefaultAsync(x => x.MatrixID == id);
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }  

        [HttpPost]
        public async Task<IActionResult> Post(Matrix matrix)
        {
             bool IDAlreadyExists = _context.Matrix.Any(x => x.MatrixID == matrix.MatrixID);
           try{
            _context.Matrix.Add(matrix);
                await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = matrix.MatrixID }, matrix);
            }
           catch(System.Exception){
               if (IDAlreadyExists==true)
               {
                   return BadRequest("ID already exists");
               }
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
           }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatrix(long id, Matrix matrix)
        {
            if (id != matrix.MatrixID)
            {
                return BadRequest();
            }

            _context.Entry(matrix).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatrixExists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Matrix>> DeleteMatrix(int id)
        {
            var matrix = await _context.Matrix.FindAsync(id);
            if (matrix == null)
            {
                return NotFound();
            }

            try
            {
                _context.Matrix.Remove(matrix);
                await _context.SaveChangesAsync();

                return matrix;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatrixExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool MatrixExists(long id) =>
         _context.Matrix.Any(e => e.MatrixID == id);
    }
}