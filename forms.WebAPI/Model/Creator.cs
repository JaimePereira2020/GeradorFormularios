using System.Collections.Generic;

namespace forms.WebAPI.Model
{
    public class Creator
    {
        public int CreatorID { get; set; }
        public string name { get; set; }
        public string institution { get; set; }

<<<<<<< HEAD
        public virtual ICollection<Form> Form { get; set; } 

=======
        public virtual List<Form> Form { get; set; } 
>>>>>>> 2437c73cc236d0f775dc1ffe3f7e718db927c5f6
    }
}