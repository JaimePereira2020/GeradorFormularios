using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class User_Formulario
    {
       public int UserID { get; set; } 
       public virtual User User { get; set; }

       public int FormularioID { get; set; } 
       public virtual User_Formulario User_Formularios { get; set; } //ver bem isto
    }
}