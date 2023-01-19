using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenas : MonoBehaviour
{

    public lr_Selector_Dificultad Selec;
    // Start is called before the first frame update
    public void Facil()
    {
        lr_Selector_Dificultad.Dificultad = 1;

        SceneManager.LoadScene("Minijuego_Figuras");
    }

    public void Medio()
    {
        lr_Selector_Dificultad.Dificultad = 2;

        SceneManager.LoadScene("Minijuego_Figuras");
    }

    public void Dificil()
    {
        lr_Selector_Dificultad.Dificultad = 3;

        SceneManager.LoadScene("Minijuego_Figuras");
    }
}
