﻿namespace RubricaWeb.Models;
public static class VariabiliGlobali
{
    public static Rubrica _Rubrica { get; set; }
    public static ListRecapito _ListaContatti { get; set; }
    public static ListPersona _ListaPersona { get; set; }

    // Inizializzazione delle variabili globali
    static VariabiliGlobali()
    {
        _Rubrica = new Rubrica();
        _ListaContatti = new ListRecapito();
        _ListaPersona = new ListPersona();
    }
}