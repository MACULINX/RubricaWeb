namespace RubricaWeb.Models;

public static class VariabiliGlobali
{
    public static Contatto _PersonaAttiva { get; set; }
    public static bool _Aggiungi {  get; set; }
    public static bool _Rimuovi {  get; set; }

    // Inizializzazione delle variabili globali
    static VariabiliGlobali()
    {
        _Aggiungi = false;
        _Rimuovi = false;
    }
}