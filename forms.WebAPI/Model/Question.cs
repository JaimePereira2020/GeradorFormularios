namespace forms.WebAPI.Model
{
    public class Question
    {
        public int questionID { get; set; }
        public string descriptionValueQuetion {get; set;}
        public string type {get; set;}
        public string icon {get; set;}
        public string label {get; set;}
        public string help {get; set;}
        public string placeHolder {get; set;}
        public string className {get; set;}
        public string subType {get; set;}
        public string regex {get; set;}
        public string erroText {get; set;}
        public string condiction {get; set;}
        public bool flagDependency {get; set;}
        public string quetionDependency {get; set;}
        public string answerDependency {get; set;}
        public string positionQuetion {get; set;}
         public virtual Formulario Formulario { get; set; }
        public virtual Matrix Matrix { get; set; }
    }
}