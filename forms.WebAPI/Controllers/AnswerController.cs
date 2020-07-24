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
    public class AnswerController : ControllerBase
    {
        
         private readonly DataContext _context;

        public AnswerController(DataContext context)
        {
            _context = context;
        }

      
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Answer.ToListAsync();
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
            //return _context.Eventos.FirstOrDefault(x => x.EventoId == id);
            try
            {
                 var results = await _context.Answer.FirstOrDefaultAsync(x => x.AnswerID == id);
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            bool AnswerIDAlreadyExists = _context.Answer.Any(x => x.AnswerID == answer.AnswerID);
            
            if (ModelState.IsValid && AnswerIDAlreadyExists != true)
            {
                _context.Answer.Add(answer);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(Get), new { id = answer.AnswerID }, answer);
            }
           
            else
            {
            return BadRequest("UserFormID already exists");

            }
            
        }
        
        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            //bool UserExists(long id) =>_context.User.Any(e => e.UserID == id);
            
            if (id != answer.AnswerID)
                {
                    return BadRequest("The Answer ID does not exist");
                }

            _context.Entry(answer).State = EntityState.Modified;

            try
                {
                    await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                    if (! AnswerExists(id))
                    {
                        return NotFound("User not found");
                    }
                    else
                    {
                        throw;
                    }
                }

            return NoContent();
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
         public async Task<ActionResult<Answer>> DeleteAnswer(int id)
        {
            var answer = await _context.Answer.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            try
            {
                _context.Answer.Remove(answer);
                await _context.SaveChangesAsync();
                return (answer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! AnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        
        private bool AnswerExists(int id) => _context.Answer.Any(e => e.AnswerID == id);    
    }
}
