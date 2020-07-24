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
    public class CreatorController : ControllerBase
    {
        
         private readonly DataContext _context;

        public CreatorController(DataContext context)
        {
            _context = context;
        }

      
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Creator.ToListAsync();
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
                 var results = await _context.Creator.FirstOrDefaultAsync(x => x.CreatorID == id);
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
        public async Task<ActionResult<Creator>> PostCreator(Creator creator)
        {
            bool CreatorIDAlreadyExists = _context.Creator.Any(x => x.CreatorID == creator.CreatorID);
            
            if (ModelState.IsValid && CreatorIDAlreadyExists != true)
            {
                _context.Creator.Add(creator);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(Get), new { id = creator.CreatorID }, creator);
            }
           
            else
            {
            return BadRequest("CreatorID already exists");

            }
            
        }
        
        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreator(int id, Creator creator)
        {
            //bool UserExists(long id) =>_context.User.Any(e => e.UserID == id);
            
            if (id != creator.CreatorID)
                {
                    return BadRequest("The Creator ID does not exist");
                }

            _context.Entry(creator).State = EntityState.Modified;

            try
                {
                    await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                    if (! CreatorExists(id))
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
         public async Task<ActionResult<Creator>> DeleteCreator(int id)
        {
            var creator = await _context.Creator.FindAsync(id);
            if (creator == null)
            {
                return NotFound();
            }

            try
            {
                _context.Creator.Remove(creator);
                await _context.SaveChangesAsync();
                return (creator);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! CreatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        
        private bool CreatorExists(int id) => _context.Creator.Any(e => e.CreatorID == id);    
    }
}
