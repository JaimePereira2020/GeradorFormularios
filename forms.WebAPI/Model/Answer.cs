namespace forms.WebAPI.Model
{
    public class Answer
    {
        
        public int AnswerID { get; set; }
        public string descriptionValueAnswer { get; set; }
        public int UserFormID { get; set; }
        public int PossibilityAnswerID { get; set; }
        public virtual UserForm UserForms { get; set; }
        public virtual PossibilityAnswer PossibilityAnswers { get; set; }
    }
}