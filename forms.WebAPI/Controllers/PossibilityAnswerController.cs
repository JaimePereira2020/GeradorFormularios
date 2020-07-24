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
    public class PossibilityAnswerController : ControllerBase
    {
    
         private readonly DataContext _context;

        public PossibilityAnswerController(DataContext context)
        {
            _context = context;
        }
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.PossibilityAnswer.ToListAsync();
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
                 var results = await _context.PossibilityAnswer.FirstOrDefaultAsync(x => x.PossibilityAnswerID == id);
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }   
        [HttpPost]
        public async Task<IActionResult> Post(PossibilityAnswer pAnswer)
        {
            bool IDAlreadyExists = _context.PossibilityAnswer.Any(x => x.PossibilityAnswerID == pAnswer.PossibilityAnswerID);
           try{
            _context.PossibilityAnswer.Add(pAnswer);
                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = pAnswer.PossibilityAnswerID }, pAnswer);
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
        public async Task<IActionResult> PutPAnswer(long id, PossibilityAnswer pAnswer)
        {
            if (id != pAnswer.PossibilityAnswerID)
            {
                return BadRequest();
            }

            _context.Entry(pAnswer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pAnswerExists(id))
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
        public async Task<ActionResult<PossibilityAnswer>> DeletePAnswer(int id)
        {
            var pAnswer = await _context.PossibilityAnswer.FindAsync(id);
            if (pAnswer == null)
            {
                return NotFound();
            }

            try
            {
                _context.PossibilityAnswer.Remove(pAnswer);
                await _context.SaveChangesAsync();

                return pAnswer;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pAnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool pAnswerExists(long id) =>
         _context.PossibilityAnswer.Any(e => e.PossibilityAnswerID == id); 
        
    }
}