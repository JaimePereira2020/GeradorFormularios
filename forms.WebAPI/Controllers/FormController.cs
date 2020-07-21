using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using forms.WebAPI.Data;
using forms.WebAPI.Model;
using System.Linq;

namespace forms.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
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
