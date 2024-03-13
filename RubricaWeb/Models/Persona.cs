namespace RubricaWeb.Models;

public class ListPersona : List<Persona> { }

public class Persona
{
    //Attributi
    private int _numero;
    private string _nome;
    private string _cognome;


    //Costruttori

    //Costruzione di un contatto tramite il file CSV
    public Persona(string row)
    {
        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _nome = fields[1];
            _cognome = fields[2];
        }
    }

    //Costruzione di un contatto tramite il file CSV
    public Persona(string nome, string cognome, Persona ultimaPersona)
    {
        _numero = ultimaPersona.Numero + 1;
        _nome = nome;
        _cognome = cognome;

    }

    //Costruzione di un contatto vuoto
    public Persona() { }

    //Properties
    public int Numero { get => _numero; set => _numero = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Cognome { get => _cognome; set => _cognome = value; }


    public bool Cerca(string s)
    {
        s = s.ToLower();

        return Nome.ToLower().Contains(s) || Cognome.ToLower().Contains(s);
    }

    public override string ToString()
    {
        return $"{Numero};{Nome};{Cognome}";
    }

}