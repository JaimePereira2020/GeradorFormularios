namespace forms.WebAPI.Model
{
    public class Answer
    {
        
        public int AnswerID { get; set; }
        public string descriptionValueAnswer { get; set; }
        public virtual User User { get; set; }
        public virtual Formulario Formulario { get; set; }
        public virtual PossibilityAnswer PossibilityAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}