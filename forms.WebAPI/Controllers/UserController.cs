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
    public class UserController : ControllerBase
    {
        //private readonly DataContext _context;

        // public ValuesController(DataContext context)
        // {
        //     _context = context;
        // }

        //GET ALL
        [HttpGet]

        public ActionResult<IEnumerable<User>> Get()
        {
            return new User[] {
                new User (){
                    UserID=1,
                    name="Jaime",
                    institution="Prochild"
                    
                },
                new User (){
                    UserID=2,
                    name="Daniel",
                    institution="CCG"
                }

             };
        }
        //GET by ID
        [HttpGet("{id}")]

       
        public ActionResult<User> Get(int id)
       
        { 
             return new User[] {
                new User (){
                    UserID=1,
                    name="Jaime",
                    institution="Prochild"
                },
                new User (){
                    UserID=2,
                    name="Daniel",
                    institution="CCG"
                }

             }.FirstOrDefault(x => x.UserID == id);
        }

    }
}