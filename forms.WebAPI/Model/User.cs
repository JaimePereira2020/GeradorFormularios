using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class User
    {
        public int UserID {get; set;}
        public string name {get; set;}
        public string institution {get; set;}

        public virtual List<User_Formulario> User_Formulario { get; set; } 
        
    }
}