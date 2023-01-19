using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifKatamino : MonoBehaviour
{
    public static bool Facil = false, Medio = false, Dificil = false; 

    public void Jugar()
    {
        if (Facil == true)
        {
            SceneManager.LoadScene("Katamino1");
        }
        else if (Medio == true)
        {
            SceneManager.LoadScene("Katamino2");
        }
        else if (Dificil == true)
        {
            SceneManager.LoadScene("Katamino3");
        }
    }

    private void OnDestroy()
    {
        Facil = false;
        Medio = false;
        Dificil = false;
    }
}
