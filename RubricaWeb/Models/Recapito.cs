using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using RubricaWeb.Models.TipiRecapito;
namespace RubricaWeb.Models;


public enum TipoRecapito { nessuno , Email , Telefono , Web}


public class ListRecapito : List<Recapito> 
{   
    public ListRecapito() { }
    public ListRecapito(string file)
    {
        using(var sr = new StreamReader(file))
        {
            sr.ReadLine();
            while(!sr.EndOfStream)
                this.Add(Recapito.GeneraContatto(sr.ReadLine()));
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

public class Recapito
{
    //Properties
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public string Valore { get; set; }

    public Recapito(string? row)
    {
        if(row == null)
            return;

        string[] fields = row.Split(';');

        if (fields.Length == 3)
        {
            Numero = int.TryParse(fields[0], out int n) ? n : 0;
            Tipo = fields[1];
            Valore = fields[2];
        }
    }
    public Recapito() 
    {
        Numero = 0;
        Tipo = "nessuno";
        Valore = "nessuno";
    }

    public static Recapito GeneraContatto(string? row) 
    {
        if(row == null)
            return new Recapito();

        Enum.TryParse(row.Split(';')[1].ToLower(), out TipoRecapito checker);

        switch (checker) 
        {
            case TipoRecapito.Email:
                return new RecapitoEmail(row);
            case TipoRecapito.Telefono:
                return new RecapitoTelefonico(row);
            case TipoRecapito.Web:
                return new RecapitoWeb(row);
            default:
                return new Recapito(row);
        }
    }

    public override string ToString()
    {
        return $"{Numero};{Tipo};{Valore}";
    }


}

