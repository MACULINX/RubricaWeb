namespace RubricaWeb.Models.TipiContatto;

class ContattoEmail : Contatti
{
    public ContattoEmail(string row) : base()
    {
        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _tipo = "EMail";

            _valore = fields[2];
        }
    }

    public ContattoEmail(){}
}

