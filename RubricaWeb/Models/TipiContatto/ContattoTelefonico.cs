namespace RubricaWeb.Models.TipiContatto;

class ContattoTelefonico : Contatti
{
    public ContattoTelefonico(string row) : base()
    {
        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _tipo = "Telefono";

            _valore = fields[2];
        }
    }
}
