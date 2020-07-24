namespace forms.WebAPI.Model
{
    public class Matrix
    {
        public int MatrixID { get; set; }  
        public string descriptionMatrix { get; set; }  
        public string possibilityAnswerMatrix { get; set; }  
        public int positionMatrix { get; set; }  
<<<<<<< HEAD
         public int FormularioID { get; set; }
=======
>>>>>>> 2437c73cc236d0f775dc1ffe3f7e718db927c5f6
        public  virtual Form Form { get; set; }  
    }
}