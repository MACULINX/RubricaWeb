namespace RubricaWeb.Models
{
    public class Rubrica
    {
        private ListPersona personeList;
        private ListContatti contattiList;
        private Contatto _personaAttuale;

        public Contatto PersonaAttuale { get => _personaAttuale; set => _personaAttuale = value; }

        public Rubrica(ListPersona lp, ListContatti lc) 
        {
            personeList = lp;
            contattiList = lc;
            _personaAttuale = null;
        }

        public Rubrica(ListPersona lp, ListContatti lc, Contatto personaAttuale)
        {
            personeList = lp;
            contattiList = lc;
            _personaAttuale = personaAttuale;
        }

        public Rubrica(Rubrica r)
        {
            personeList = r.personeList;
            contattiList = r.contattiList; 
        }

        public Rubrica()
        {
            personeList = new();
            contattiList = new();
        }

        public ListPersona PersoneFiltrate(string s)
        {
            ListPersona personeFiltrate = new();

            if (s == "")
                return personeList;
            
            foreach (var p in personeList)
                if (p.Cerca(s))
                    personeFiltrate.Add(p);

            return personeFiltrate;
        }
        public ListContatti ContattiFiltrati(int PK)
        {
            ListContatti contattiFiltrati = new();

            foreach (var c in contattiList)
                if (c.Numero == PK)
                    contattiFiltrati.Add(c);

            return contattiFiltrati;
        }

        public void AddPersona(string nome, string cognome)
        {   
            personeList.Add(new Persona(nome, cognome, personeList.Last()));
        }
        public void RemPersona(Persona p)
        {
            personeList.Remove(p);
        }
        public ListPersona getPersoneList() { return personeList; }
        public ListContatti getContattiList() {  return contattiList; }
        
    }

    public class Contatto 
    {
        private int _PK;
        private Persona _p;
        private ListContatti _lc;

        public Contatto() { }

        public Contatto(int PK, ListPersona lp, ListContatti lc) 
        {

            //Imposto la Primary Key
            _PK = PK;

            //Trovo la persona
            foreach (Persona p in lp)
                if (p.Numero == _PK)
                    _p = p;

            //Trovo tutti i contatti collegati
            _lc = new ListContatti();
            foreach (Contatti c in lc)
                if (c.Numero == _PK)
                    _lc.Add(c);
        }

        public Persona PersonaSingola{ get => _p; set => _p = value; }
        public ListContatti ContattiFiltrati { get => _lc; set => _lc = value; }
        public int PK { get => _PK; set => _PK = value; }
    }
}
