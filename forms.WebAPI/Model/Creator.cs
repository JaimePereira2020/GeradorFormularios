using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class Creator
    {
        public int CreatorID { get; set; }
        public string name { get; set; }
        public string institution { get; set; }
        public virtual List<Formulario> Formulario { get; set; } 
    }
}