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
    public class UserController : ControllerBase {

        private readonly DataContext _context;

        public UserController (DataContext context) {
            _context = context;
        }

        //GET ALL
        [HttpGet]

        public async Task<IActionResult> Get () {
            try {
                var results = await _context.User.ToListAsync ();
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
                var results = await _context.User.FirstOrDefaultAsync (x => x.UserID == id);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }
    }
}