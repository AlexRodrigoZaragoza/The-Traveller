using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VueltaAMenu : MonoBehaviour
{
    public Text Comentario;
    public Text Datos;
    // Start is called before the first frame update
    void Start()
    {
        if(lr_Trazado.victoria == 0)
        {
            Comentario.text = "¡Enhorabuena!";
            Datos.text = "Has tardado: " + lr_LineController.tiempo.ToString("0") + " segundos"; 
        }

        if (lr_Trazado.victoria == 1)
        {
            Comentario.text = "¡Nivel no superado, suerte a la proxima!";
            Datos.text = "La fugura no era correcta";
        }

        if (lr_Trazado.victoria == 2)
        {
            Comentario.text = "¡Nivel no superado, suerte a la proxima!";
            Datos.text = "Te has quedado sin tiempo";
        }
    }

    // Update is called once per frame
    public void Vuelta()
    {
        SceneManager.LoadScene("LevelDif");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
