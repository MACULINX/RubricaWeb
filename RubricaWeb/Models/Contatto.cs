namespace RubricaWeb.Models
{


    public class Contatto
    {
        public Persona PersonaSingola { get; set; }
        public ListRecapito ContattiFiltrati { get; set; }
        public int PK { get; set; }

        public Contatto() { }

        public Contatto(int PK, ListPersona lp, ListRecapito lc)
        {

            //Imposto la Primary Key
            this.PK = PK;

            //Trovo la persona
            foreach (Persona p in lp)
                if (p.Numero == this.PK)
                    PersonaSingola = p;

            //Trovo tutti i contatti collegati
            ContattiFiltrati = new ListRecapito();
            foreach (Recapito c in lc)
                if (c.Numero == this.PK)
                    ContattiFiltrati.Add(c);
        }
    }
}
