namespace RubricaWeb.Models;
public static class VariabiliGlobali
{
    public static SQLRubrica _Rubrica { get; set; }
    public static ListRecapito _ListaContatti { get; set; }
    public static ListPersona _ListaPersona { get; set; }
    public static bool upload;

    // Inizializzazione delle variabili globali
    static VariabiliGlobali()
    {
        _Rubrica = new SQLRubrica();
        _ListaContatti = new ListRecapito();
        _ListaPersona = new ListPersona();
        upload = false;
    }
}