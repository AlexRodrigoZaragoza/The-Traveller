using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pista : MonoBehaviour
{
    private GameObject [] opacidad; //GAMEOBJECT PARA CAMBIAR LA OPACIDAD DE LAS SOMBRAS 

    // Start is called before the first frame update
    void Start()
    {
        opacidad = GameObject.FindGameObjectsWithTag("Sombra");
    }
    //--------------------FUNCIÓN QUE ENTRA AL PULSAR EL BOTÓN DE "PISTA"--------------------//
    public void Ayuda()
    {
        StartCoroutine(FinAyuda());
    }
    //--------------------COROUTINE PARA MOSTRAR Y OCULTAR LAS PIEZAS--------------------//
    public IEnumerator FinAyuda()
    {
        for (int i = 0; i < opacidad.Length; i++)
        {
            opacidad[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < opacidad.Length; i++)
        {
            opacidad[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
        }
    }
}
