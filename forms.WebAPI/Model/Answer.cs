namespace forms.WebAPI.Model
{
    public class Answer
    {
        
        public int id_Answer { get; set; }
        public int id_user { get; set; }
        public int id_Formulario { get; set; }
        public int id_PossibilityAnswer { get; set; }
        public int id_Question { get; set; }
        public string descriptionValueAnswer { get; set; }
        
        public virtual User User { get; set; }
        public virtual User_Formulario User_Formulario { get; set; }
        public virtual PossibilityAnswer PossibilityAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}