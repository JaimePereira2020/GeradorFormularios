using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class Form
    {
        public int FormID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string version { get; set; }
        public string theme { get; set; }
         public int CreatorID { get; set; }
<<<<<<< HEAD:forms.WebAPI/Model/Form.cs
        //public virtual ICollection<Matrix> Matrix { get; set; }

=======
        public virtual ICollection<Matrix> Matrix { get; set; }
       
>>>>>>> 2437c73cc236d0f775dc1ffe3f7e718db927c5f6:forms.WebAPI/Model/Formulario.cs
    }
}