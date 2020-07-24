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
    public class UserFormController : ControllerBase
    {
        
         private readonly DataContext _context;

        public UserFormController(DataContext context)
        {
            _context = context;
        }

      
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.UserForm.ToListAsync();
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
                 var results = await _context.UserForm.FirstOrDefaultAsync(x => x.UserFormID == id);
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
        public async Task<ActionResult<User>> PostUserForm(UserForm userForm)
        {
            bool UserFormIDAlreadyExists = _context.UserForm.Any(x => x.UserFormID == userForm.UserFormID);
            
            if (ModelState.IsValid && UserFormIDAlreadyExists != true)
            {
                _context.UserForm.Add(userForm);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(Get), new { id = userForm.UserFormID }, userForm);
            }
           
            else
            {
            return BadRequest("UserFormID already exists");

            }
            
        }
        
        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserForm(int id, UserForm userForm)
        {
            //bool UserExists(long id) =>_context.User.Any(e => e.UserID == id);
            
            if (id != userForm.UserFormID)
                {
                    return BadRequest("The userForm ID does not exist");
                }

            _context.Entry(userForm).State = EntityState.Modified;

            try
                {
                    await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                    if (! UserFormExists(id))
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
         public async Task<ActionResult<UserForm>> DeleteUserForm(int id)
        {
            var userForm = await _context.UserForm.FindAsync(id);
            if (userForm == null)
            {
                return NotFound();
            }

            try
            {
                _context.UserForm.Remove(userForm);
                await _context.SaveChangesAsync();
                return (userForm);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        
        private bool UserFormExists(int id) => _context.UserForm.Any(e => e.UserFormID == id);    
    }
}
