using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using forms.WebAPI.Data;
using forms.WebAPI.Model;

namespace forms.WebAPI.Controllers
{  
    
    [Route("api/[controller]")]
    [ApiController]
    public class PossibilityAnswerController : ControllerBase
    {
     [HttpGet]

        public ActionResult<IEnumerable<PossibilityAnswer>> Get()
        {
            return new PossibilityAnswer[] {
                new PossibilityAnswer (){
                    PossibilityAnswerID=1,
                    descriptionValuePossibilityAnswer = "Answer1"
            
                }
             };
        }
    }
}