using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace forms.WebAPI.Model
{

    public class UserForm
    {
        [Key]
       public int UserFormID { get; set; } 
       public int UserID {get; set;}
       public int FormID {get; set;}

       public virtual User User { get; set; }
     
       public virtual Form Form { get; set; }
    }
  
}