using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using RubricaWeb.Models.TipiContatto;
namespace RubricaWeb.Models;


public enum TipoContatti { nessuno , Email , Telefono , Web}


public class ListContatti : List<Contatti> 
{   
    public ListContatti() { }
    public ListContatti(string file)
    {
        using(var sr = new StreamReader(file))
        {
            sr.ReadLine();
            while(!sr.EndOfStream)
                this.Add(Contatti.GeneraContatto(sr.ReadLine()));
        }
    }

    public override string ToString()
    {
        string retVal = "";
        foreach (var item in this.ToArray())
            if(item != null)
                retVal += $"{item.Tipo}: {item.Valore}\n";
        
        return retVal;
    }
}

public class Contatti
{
    //Attributi
    protected int _numero;
    protected string _tipo;
    protected string _valore;

    public Contatti(string? row)
    {
        if(row == null)
            return;

        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            _numero = 0;
            int.TryParse(fields[0], out _numero);

            _tipo = fields[1];
            _valore = fields[2];
        }
    }
    public Contatti() 
    {
        _numero = 0;
        _tipo = "nessuno";
        _valore = "nessuno";
    }

    public static Contatti GeneraContatto(string? row) 
    {
        if(row == null)
            return new Contatti();

        string type = row.Split(';')[1].ToLower();

        Enum.TryParse(type, out TipoContatti checker);

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
    public string Tipo { get => _tipo; }
    public string Valore { get => _valore;}
}

