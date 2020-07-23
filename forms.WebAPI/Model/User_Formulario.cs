using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace forms.WebAPI.Model
{

    public class UserFormulario
    {
       public int UserFormularioID { get; set; } 
       public int UserID {get; set;}

       public virtual User User { get; set; }
     
       public virtual Form Form { get; set; }
    }
  
}