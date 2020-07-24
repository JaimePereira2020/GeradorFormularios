namespace forms.WebAPI.Model
{
    public class Matrix
    {
        public int MatrixID { get; set; }  
        public string descriptionMatrix { get; set; }  
        public string possibilityAnswerMatrix { get; set; }  
        public int positionMatrix { get; set; }  
         public int FormularioID { get; set; }
        public  virtual Form Form { get; set; }  
    }
}