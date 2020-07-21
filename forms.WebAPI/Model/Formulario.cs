namespace forms.WebAPI.Model
{
    public class Formulario
    {
        public int FormularioID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string version { get; set; }
        public string theme { get; set; }
        public int CreatorID { get; set; }
    }
}