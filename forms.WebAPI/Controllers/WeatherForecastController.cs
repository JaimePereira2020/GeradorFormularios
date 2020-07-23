using System;
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

        public ActionResult<IEnumerable<Form>> Get()
        {
            return new Form[] {
                new Form (){
                    FormID=1,
                    name = "Form1",
                    description = "Description Form1",
                    status="Publicado",
                    version="1.0",
                
                },
                new Form (){
                    FormID=2,
                    name = "Form2",
                    description = "Description Form2",
                    status="Rascunho",
                    version="1.0",
                  
                }

             };
        }
        //GET by ID
        [HttpGet("{id}")]

       
        public ActionResult<Form> Get(int id)
       
        { 
             return new Form[] {
                new Form (){
                    FormID=1,
                    name = "Form1",
                    description = "Description Form1",
                    status="Publicado",
                    version="1.0"
                
                },
                new Form (){
                    FormID=2,
                    name = "Form2",
                    description = "Description Form2",
                    status="Rascunho",
                    version="1.0"
                   
                }

             }.FirstOrDefault(x => x.FormID == id);
        }

    }
}
