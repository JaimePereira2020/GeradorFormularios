using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forms.WebAPI.Data;
using forms.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forms.WebAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase {

        private readonly DataContext _context;

        public AnswerController (DataContext context) {
            _context = context;
        }

        //GET ALL
        [HttpGet]

        public async Task<IActionResult> Get () {
            try {
                var results = await _context.Answer.ToListAsync ();
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }
        //GET by ID
        [HttpGet ("{id}")]

        public async Task<IActionResult> Get (int id) {
            //return _context.Eventos.FirstOrDefault(x => x.EventoId == id);
            try {
                var results = await _context.Answer.FirstOrDefaultAsync (x => x.AnswerID == id);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }
    }
}