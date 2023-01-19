using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Toggle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dificultades;
    public GameObject TablasPuntuaciones;
    public GameObject Explicacion;

    public Toggle toggle_dificultades;
    public Toggle toggle_tablaspuntuaciones;

    public void Toggle_dificultades()
    {
        if (toggle_dificultades.isOn == true)
        {
            Dificultades.SetActive(true);
            toggle_tablaspuntuaciones.isOn = false;
            Explicacion.GetComponent<Text>().text = "Seleccione la dificultad de los minijuegos";
        }
        else if (toggle_dificultades.isOn == false)
        {
            Dificultades.SetActive(false);
        }
        if (toggle_dificultades.isOn == false && toggle_tablaspuntuaciones.isOn == false)
        {
            Explicacion.GetComponent<Text>().text = "Selecciona el tipo de datos que desea visualizar";
        }
    }
    public void Toggle_TablasPuntuaciones()
    {
        if (toggle_tablaspuntuaciones.isOn == true)
        {
            TablasPuntuaciones.SetActive(true);
            toggle_dificultades.isOn = false;
            Explicacion.GetComponent<Text>().text = "Partidas jugadas y las últimas puntuaciones";
        }
        else if (toggle_tablaspuntuaciones.isOn == false)
        {
            TablasPuntuaciones.SetActive(false);
        }
    }
}
