namespace RubricaWeb.Models.TipiRecapito;


class RecapitoWeb : Recapito
{
    public RecapitoWeb(string row) : base(row)
    {
        Tipo = "Web";
    }

    public RecapitoWeb() { }
}
