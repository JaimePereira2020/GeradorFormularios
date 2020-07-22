using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class UserFormulario
    {
       public int UserFormularioID { get; set; } 
       public virtual User User { get; set; }
      // public virtual ICollection<User> User { get; set; }
        //public virtual Formulario Formulario { get; set; }
    }
}