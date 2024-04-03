namespace RubricaWeb.Models
{
    public class Contatto
    {
        public Persona PersonaSingola { get; set; }
        public ListRecapito ContattiFiltrati { get; set; }

        public Contatto() 
        {
            ContattiFiltrati = new();
        }
    }
}
