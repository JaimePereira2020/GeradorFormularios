using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class Creator
    {
        public int CreatorID { get; set; }
        public string CourseID { get; set; }
        public string StudentID { get; set; }
        public virtual List<Formulario> Formulario { get; set; } 
    }
}