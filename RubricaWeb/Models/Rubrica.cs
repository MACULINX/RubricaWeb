namespace RubricaWeb.Models
{
    public class Rubrica
    {
        private ListPersona personeList;
        private ListContatti contattiList;

        public Rubrica(ListPersona lp, ListContatti lc) 
        {
            personeList = lp;
            contattiList = lc;
        }

        public ListPersona getPersoneList() {  return personeList; }
        public ListContatti getContattiList() {  return contattiList; }
    }
}
