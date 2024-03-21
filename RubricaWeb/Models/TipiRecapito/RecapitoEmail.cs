namespace RubricaWeb.Models.TipiRecapito;

class RecapitoEmail : Recapito
{
    public RecapitoEmail(string row) : base(row)
    {
        Tipo = "EMail";
    }

    public RecapitoEmail(){}
}

