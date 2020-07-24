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
    public class FormController : ControllerBase
    {
         private readonly DataContext _context;

        public FormController(DataContext context)
        {
            _context = context;
        }
        
        //GET ALL
        [HttpGet]
         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Form.ToListAsync();
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
                 var results = await _context.Form.FirstOrDefaultAsync(x => x.FormID == id);
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Form form)
        {
           bool UserIDAlreadyExists = _context.Form.Any(x => x.FormID == form.FormID);
           try{
            _context.Form.Add(form);
                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = form.FormID }, form);
           }
           catch(System.Exception){
               if (UserIDAlreadyExists==true)
               {
                   return BadRequest("ID already exists");
               }
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
           }
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(long id, Form form)
        {
            if (id != form.FormID)
            {
                return BadRequest();
            }

            _context.Entry(form).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
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
        public async Task<ActionResult<Form>> DeleteForm(int id)
        {
            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            try
            {
                _context.Form.Remove(form);
                await _context.SaveChangesAsync();

                return form;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool FormExists(long id) =>
         _context.Form.Any(e => e.FormID == id);



    }
}
