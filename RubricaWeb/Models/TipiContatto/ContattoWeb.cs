namespace RubricaWeb.Models.TipiContatto;


class ContattoWeb : Contatti
{
    public ContattoWeb(string row)
    {
        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _tipo = "Web";

            _valore = fields[2];
        }
    }
    public ContattoWeb(){}
}
