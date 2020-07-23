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
    public class UserController : ControllerBase
    {
        
         private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.User.ToListAsync();
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
                 var results = await _context.User.FirstOrDefaultAsync(x => x.UserID == id);
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
        public async Task<ActionResult<User>> PostUser(User user)
        {
            bool UserIDAlreadyExists = _context.User.Any(x => x.UserID == user.UserID);
            
            if (ModelState.IsValid && UserIDAlreadyExists != true)
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
            }
           
            else
            {
            return BadRequest("UserID already exists");

            }
            
        }
        
        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            bool UserExists(long id) =>_context.User.Any(e => e.UserID == id);
            
            if (id != user.UserID)
            {
                return BadRequest("The user ID does not exist");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! UserExists(id))
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
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        
    }
}