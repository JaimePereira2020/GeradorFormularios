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
    public class QuestionController : ControllerBase
    {
        
         private readonly DataContext _context;

        public QuestionController(DataContext context)
        {
            _context = context;
        }
        
        //GET ALL
        [HttpGet]

         public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Question.ToListAsync();
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
                 var results = await _context.Question.FirstOrDefaultAsync(x => x.questionID == id);
                 return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Question question)
        {
             bool IDAlreadyExists = _context.Question.Any(x => x.questionID == question.questionID);
           try{
            _context.Question.Add(question);
                await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = question.questionID }, question);
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
        public async Task<IActionResult> PutQuestion(long id, Question question)
        {
            if (id != question.questionID)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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


        private bool QuestionExists(long id) =>
         _context.Question.Any(e => e.questionID == id);

    }
}