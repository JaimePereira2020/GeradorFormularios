/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using forms.WebAPI.Data;
using forms.WebAPI.Model;

namespace forms.WebAPI.Controllers
{
   
    [Route("api/[controller]")]
     [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly DataContext _context;

        // public ValuesController(DataContext context)
        // {
        //     _context = context;
        // }

        //GET ALL
        [HttpGet]

        public ActionResult<IEnumerable<Formulario>> Get()
        {
            return new Formulario[] {
                new Formulario (){
                    FormularioID=1,
                    name = "Form1",
                    description = "Description Form1",
                    status="Publicado",
                    version="1.0",
                    CreatorID= 1
                },
                new Formulario (){
                    FormularioID=2,
                    name = "Form2",
                    description = "Description Form2",
                    status="Rascunho",
                    version="1.0",
                    CreatorID= 2
                }

             };
        }
        //GET by ID
        [HttpGet("{id}")]

       
        public ActionResult<Formulario> Get(int id)
       
        { 
             return new Formulario[] {
                new Formulario (){
                    FormularioID=1,
                    name = "Form1",
                    description = "Description Form1",
                    status="Publicado",
                    version="1.0",
                    CreatorID= 1
                },
                new Formulario (){
                    FormularioID=2,
                    name = "Form2",
                    description = "Description Form2",
                    status="Rascunho",
                    version="1.0",
                    CreatorID= 2
                }

             }.FirstOrDefault(x => x.FormularioID == id);
        }

    }
}
 */