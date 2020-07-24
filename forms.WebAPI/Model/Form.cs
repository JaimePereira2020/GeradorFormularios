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
        public virtual ICollection<Matrix> Matrix { get; set; }
       
    }
}