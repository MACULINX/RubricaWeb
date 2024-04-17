namespace RubricaWeb.Models;
public static class VariabiliGlobali
{
    public static Db _Rubrica { get; set; }
    public static Contatto _PersonaAttiva { get; set; }
    public static bool _Aggiungi {  get; set; }

    // Inizializzazione delle variabili globali
    static VariabiliGlobali()
    {
        _Rubrica = new Db();
        _Aggiungi = false;
    }

    public static void AggiungiPersona(Persona p)
    {
        _Rubrica.Persone.Add(p);
        _Rubrica.SaveChanges();

        _Aggiungi = false;
    }
}