namespace forms.WebAPI.Model
{
    public class PossibilityAnswer
    {
        public int PossibilityAnswerID { get; set; }
        public string descriptionValuePossibilityAnswer { get; set; }
        public virtual Matrix Matrix { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
       
    }
}