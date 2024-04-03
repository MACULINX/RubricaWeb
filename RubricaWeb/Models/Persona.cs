namespace RubricaWeb.Models;

public class ListPersona : List<Persona>
{
    public ListPersona() { }
    public ListPersona(string file)
    {
        using (var sr = new StreamReader(file))
        {
            sr.ReadLine();
            while (!sr.EndOfStream)
                this.Add(new Persona(sr.ReadLine()));
        }
    }
}

public class Persona
{
    public ListRecapito Recapiti { get; set; }

    public int PersonaId { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }

    public Persona(string? row)
    {
        if (row == null)
            return;

        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            Nome = fields[1];
            Cognome = fields[2];
        }
    }
    public Persona(string nome, string cognome)
    {
        Nome = nome;
        Cognome = cognome;
    }

    public Persona()
    {
        Nome = "Nessuno";
        Cognome = "Nessuno";
    }

    public bool Cerca(string s)
    {
        s = s.ToLower();

        return Nome.ToLower().Contains(s) || Cognome.ToLower().Contains(s);
    }

    public override string ToString()
    {
        return $"{PersonaId};{Nome};{Cognome}";
    }

}