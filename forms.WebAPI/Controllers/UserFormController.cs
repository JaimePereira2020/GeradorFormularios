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
    }
}