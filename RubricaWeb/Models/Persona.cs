namespace RubricaWeb.Models;

public class ListPersona : List<Persona> 
{
    public ListPersona() {}
    public ListPersona(string file)
    {
        using(var sr = new StreamReader(file))
        {
            sr.ReadLine();
            while(!sr.EndOfStream)
                this.Add(new Persona(sr.ReadLine()));
        }
    }
}

public class Persona
{
    private int _numero;
    private string _nome;
    private string _cognome;

    public Persona(string? row)
    {
        if(row == null)
           return;

        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _nome = fields[1];
            _cognome = fields[2];
        }  
    }
    public Persona(string nome, string cognome, Persona ultimaPersona)
    {
        _numero = ultimaPersona.Numero + 1;
        _nome = nome;
        _cognome = cognome;
    }

    public Persona() 
    {
        _nome = "Nessuno";
        _cognome = "Nessuno";
    }

    public int Numero { get => _numero; }
    public string Nome { get => _nome;  }
    public string Cognome { get => _cognome;}


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