using System.Collections;
using UnityEngine;

[System.Serializable]
public class Escenas
{
    public string Escena;
    public int numVecesUsado;

    public Escenas(string nombre, int numUsado)
    {
        this.Escena = nombre;
        this.numVecesUsado = numUsado;
    }

}
