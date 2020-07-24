
using System.Collections.Generic;
namespace forms.WebAPI.Model
{
    public class PossibilityAnswer
    {
        public int PossibilityAnswerID { get; set; }
        public string descriptionValuePossibilityAnswer { get; set; }
        public int questionID { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }

}