using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DificultadKata : MonoBehaviour
{
    public static DificultadKata instance;
    public int filas, columnas;

    #region DontDestroyOnLoad
    private void Awake()
    {
        if (DificultadKata.instance == null)
        {
            DificultadKata.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public void Facil()
    {
        filas = 3;
        columnas = 5;
    }
    public void Medio()
    {
        filas = 4;
        columnas = 5;
    }
    public void Dificil()
    {
        filas = 5;
        columnas = 6;
    }
    public void Jugar(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
