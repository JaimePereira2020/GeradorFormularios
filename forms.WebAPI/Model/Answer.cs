namespace forms.WebAPI.Model
{
    public class Answer
    {
        
        public int AnswerID { get; set; }
        public int UserID { get; set; }
        public int FormularioID { get; set; }
        public int PossibilityAnswerID { get; set; }
        public int QuestionID { get; set; }
        public string descriptionValueAnswer { get; set; }
        
        public virtual User User { get; set; }
        public virtual UserFormulario UserFormulario { get; set; }
        public virtual PossibilityAnswer PossibilityAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}