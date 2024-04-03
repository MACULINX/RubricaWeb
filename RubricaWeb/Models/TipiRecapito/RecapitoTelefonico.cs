namespace RubricaWeb.Models.TipiRecapito;


class RecapitoTelefonico : Recapito
{
    public RecapitoTelefonico(string row) : base(row)
    {
        Tipo = "Telefono";
    }

    public RecapitoTelefonico() { }
}
