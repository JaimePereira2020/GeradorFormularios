using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace forms.WebAPI.Model
{

    public class UserFormulario
    {
        [Key]
       public int UserFormularioID { get; set; } 
       public int UserID {get; set;}
       public int FormularioID {get; set;}

       public virtual User User { get; set; }
     
       public virtual Formulario Formulario { get; set; }
    }
  
}