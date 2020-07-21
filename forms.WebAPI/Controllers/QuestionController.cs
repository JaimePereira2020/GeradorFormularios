using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using forms.WebAPI.Data;
using forms.WebAPI.Model;

namespace forms.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        //GET ALL
        [HttpGet]

        public ActionResult<IEnumerable<Question>> Get()
        {
            return new Question[] {
                new Question (){
                    questionID=1,
                    descriptionValueQuetion = "Quetion1",
                    type = "Description Quetion1",
                    icon="icon Quetion1",
                    label="Lb Quetion1",
                    help= "help Quetion1",
                    placeHolder= "placeholder Quetion1",
                    className= "class Quetion1",
                    subType= " sub Quetion1",
                    regex= "regex Quetion1",
                    erroText= " error Quetion1",
                    condiction= "cond Quetion1",
                    flagDependency= true,
                    quetionDependency= "dep Quetion1",
                    answerDependency= "ansDep Quetion1",
                    positionQuetion= "position Quetion1"
                }
             };
        }
    }
}