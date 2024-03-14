using RubricaWeb.Models.TipiContatto;
namespace RubricaWeb.Models;

public enum TipoContatti { nessuno , Email , Telefono , Web}

public class ListContatti : List<Contatti> { }

public class Contatti
{
    //Attributi
    protected int _numero;
    protected string _tipo;
    protected string _valore;


    //Costruttori

    //Costruzione di un contatto tramite il file CSV
    public Contatti(string row)
    {
        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _tipo = fields[1];
            _valore = fields[2];
        }
    }
    //Costruzione di un contatto vuoto
    public Contatti() { }

    public static Contatti GeneraContatto(string row) 
    {
        string type = row.Split(';')[1].ToLower();
        TipoContatti checker = 0;
        Enum.TryParse(type, out checker);

        switch (checker) 
        {
            case (TipoContatti)1:
                return new ContattoEmail(row);
            case (TipoContatti)2:
                return new ContattoTelefonico(row);
            case (TipoContatti)3:
                return new ContattoWeb(row);
            default:
                return new Contatti(row);
        }
    }

    public override string ToString()
    {
        return $"{Numero};{Tipo};{Valore}";
    }

    //Properties
    public int Numero { get => _numero;}
    public string Tipo { get => _tipo; set => _tipo = value; }
    public string Valore { get => _valore; set => _valore = value; }
}

