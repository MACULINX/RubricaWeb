namespace RubricaWeb.Models;
public static class VariabiliGlobali
{
    public static Db _Rubrica { get; set; }
    public static Contatto _PersonaAttiva { get; set; }

    // Inizializzazione delle variabili globali
    static VariabiliGlobali()
    {
        _Rubrica = new Db();
    }
}