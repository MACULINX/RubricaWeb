namespace RubricaWeb.Models
{
    public class Rubrica
    {
        public Contatto? PersonaAttuale { get; set; }
        public ListPersona PersoneList { get; set; }
        public ListRecapito ContattiList { get; set; }

        public Rubrica(ListPersona lp, ListRecapito lc)
        {
            PersoneList = lp;
            ContattiList = lc;
            PersonaAttuale = null;
        }

        public Rubrica(ListPersona lp, ListRecapito lc, Contatto personaAttuale)
        {
            PersoneList = lp;
            ContattiList = lc;
            PersonaAttuale = personaAttuale;
        }

        public Rubrica(Rubrica r)
        {
            PersoneList = r.PersoneList;
            ContattiList = r.ContattiList;
        }

        public Rubrica()
        {
            PersoneList = new();
            ContattiList = new();
        }

        public ListPersona PersoneFiltrate(string s)
        {
            ListPersona personeFiltrate = new();

            if (s == "")
                return PersoneList;

            foreach (var p in PersoneList)
                if (p.Cerca(s))
                    personeFiltrate.Add(p);

            return personeFiltrate;
        }
        public ListRecapito ContattiFiltrati(int PK)
        {
            ListRecapito contattiFiltrati = new();

            foreach (var c in ContattiList)
                if (c.PersonaId == PK)
                    contattiFiltrati.Add(c);

            return contattiFiltrati;
        }

        public void AddPersona(string nome, string cognome)
        {
            PersoneList.Add(new Persona(nome, cognome));
        }

        public void RemPersona(Persona p)
        {
            PersoneList.Remove(p);
        }
    }
}
