using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SombrasTangram : MonoBehaviour
{
    int numeroPiezasCorrectas = 0;
    public RectTransform[] sombras = new RectTransform[7]; //ARRAY QUE OBTIENE LA POSICIÓN Y ROTACIÓN DE LAS SOMBRAS
    public RectTransform[] piezas = new RectTransform[7]; //ARRAY QUE OBTIENE LA POSICIÓN Y ROTACIÓN DE LAS SOMBRAS

    private Vector3[] posicionesCorrectas = new Vector3[7]; //ARRAY QUE GUARDA LA POSICIÓN DE LAS SOMBRAS
    private Vector3[] rotacionesCorrectas = new Vector3[7]; //ARRAY QUE GUARDA LA ROTACIÓN DE LAS SOMBRAS
    private Vector3[] rotacionesPiezas = new Vector3[7]; //ARRAY QUE GUARDA LA ÚLTIMA ROTACIÓN DE LAS PIEZAS DEL USUARIO
    private Vector3[] posicionesPiezas = new Vector3[7]; //ARRAY QUE GUARDA LA ÚLTIMA POSICIÓN DE LAS PIEZAS DEL USUARIO

    private float margenError = 15; //FLOAT PARA TENER UN MARGEN DE ERROR EN LA ROTACIÓN Y LA POSICIÓN DE LAS PIEZAS

    //--------------------VARIABLES PARA QUE EL JUGADOR PUEDA RECIBIR FEEDBACK--------------------//
    public static float tiempo;
    public static float tiempoTotal; 
    public static bool sinTiempo;
    public Text piezasCorrectas;

    public static bool piezaCompletada;
    //private int numeroPiezasCorrectas;
        // Start is called before the first frame update
    void Start()
    {
        //--------------------AJUSTES DEL TIEMPO TOTAL DEPENDIENDO DE LA DIFICULTAD--------------------//
        sinTiempo = false;
        piezaCompletada = false;
        feedbackmanager.juego_feedback = "tangram";
        if (Dificultades.facil == true)
        {
            tiempo = 180;
        }
        if (Dificultades.normal == true)
        {
            tiempo = 270;
        }
        if (Dificultades.dificil == true)
        {
            tiempo = 360;
        }
        tiempoTotal = tiempo;
        StartCoroutine("Tiempo");
       
    }
    private void Update()
    {

        //--------------------VARIABLES PARA DAR FEEDBACK VISUAL DE LAS PIEZAS CORRECTAS--------------------//
        if (Dificultades.facil == true)
        {
            piezasCorrectas.text = numeroPiezasCorrectas + "/3";
        }
        if (Dificultades.normal == true)
        {
            piezasCorrectas.text = numeroPiezasCorrectas + "/5";
        }
        if (Dificultades.dificil == true)
        {
            piezasCorrectas.text = numeroPiezasCorrectas + "/7";
        }
    }
    public void Corregir()
    {
        //--------------------OBTENCIÓN DE LOS VALORES DE POSICIÓN Y ROTACIÓN DE LAS PIEZAS Y SOMBRAS--------------------//
        for (int i = 0; i < piezas.Length; i++)
        {
            

            posicionesPiezas[i] = piezas[i].localPosition;
            rotacionesPiezas[i] = piezas[i].localEulerAngles;
            posicionesCorrectas[i] = sombras[i].localPosition;
            rotacionesCorrectas[i] = sombras[i].localEulerAngles;

        }

        numeroPiezasCorrectas = 0; //REINICIO DE LA VARIABLE DE PIEZAS CORRECTAS

        //--------------------CORRECCIÓN ROTACIONES CUADRADO Y TRAPECIO--------------------//
        float[] rotacionCuadrado = new float[3];

        rotacionCuadrado[0] = 180f;
        rotacionCuadrado[1] = -90f;
        rotacionCuadrado[2] = 180f;
      

      

        for (int i = 0; i < rotacionCuadrado.Length; i++)
        {

            if (Vector3.Distance(rotacionesCorrectas[5], piezas[5].GetComponent<RectTransform>().localEulerAngles) > margenError)
            {
                rotacionesCorrectas[5] = new Vector3(0, 0, rotacionesCorrectas[5].z + rotacionCuadrado[i]);
            }

        }
        if (Vector3.Distance(rotacionesCorrectas[6], piezas[6].GetComponent<RectTransform>().localEulerAngles) > margenError)
        {
            rotacionesCorrectas[6] = new Vector3(0, 0, rotacionesCorrectas[6].z + 180f);
        }

        //--------------------COMPROBACIÓN DE LAS PIEZAS--------------------//

        for (int i = 0; i < piezas.Length; i++)
        {

            //--------------------COMPROBACIÓN TRIÁNGULOS PEQUEÑOS--------------------//
            if ((Vector3.Distance(posicionesCorrectas[2], posicionesPiezas[i]) <= margenError || Vector3.Distance(posicionesCorrectas[3], posicionesPiezas[i]) <= margenError) && (Vector3.Distance(rotacionesCorrectas[2], rotacionesPiezas[i]) <= margenError || Vector3.Distance(rotacionesCorrectas[3], rotacionesPiezas[i]) <= margenError) && (i == 2 || i == 3))
            {
                numeroPiezasCorrectas++;
            }

            //--------------------COMPROBACIÓN TRIÁNGULOS GRANDES--------------------//
            if ((Vector3.Distance(posicionesCorrectas[0], posicionesPiezas[i]) <= margenError || Vector3.Distance(posicionesCorrectas[1], posicionesPiezas[i]) <= margenError) && (Vector3.Distance(rotacionesCorrectas[0], rotacionesPiezas[i]) <= margenError || Vector3.Distance(rotacionesCorrectas[1], rotacionesPiezas[i]) <= margenError) && (i == 0 || i == 1))
            {
                numeroPiezasCorrectas++;
            }


            //--------------------COMPROBACIÓN RESTO DE PIEZAS--------------------//
            if (Vector3.Distance(posicionesCorrectas[i], posicionesPiezas[i]) <= margenError && Vector3.Distance(rotacionesCorrectas[i], rotacionesPiezas[i]) <= margenError && ( i > 3))
            {
                numeroPiezasCorrectas++;
            }


        }
        //--------------------COMPROBACIÓN PIEZA COMPLETADA--------------------//
        if (numeroPiezasCorrectas == 3 && Dificultades.facil == true)
        {
            piezaCompletada = true;
            StopCoroutine("Tiempo");
        }
        if (numeroPiezasCorrectas == 5 && Dificultades.normal == true)
        {
            piezaCompletada = true;
            StopCoroutine("Tiempo");
        }
        if (numeroPiezasCorrectas >= 7 && Dificultades.dificil == true)
        {
            piezaCompletada = true;
            StopCoroutine("Tiempo");
        }
    }
    
    IEnumerator Tiempo()
    {
        Corregir(); //LLAMADA A FUNCIÓN PARA QUE COMPRUEBE AUTOMÁTICAMENTE LA FIGURA

                    //--------------------COMPROBACIÓN FINAL PARTIDA--------------------//
        if (tiempo <= 0)
        {
            sinTiempo = true;
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
            CargarFeedback();
        }
        if (piezaCompletada == true)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
            CargarFeedback();
        }
        yield return new WaitForSeconds(1f);
       
        if (piezaCompletada == false)
        {
            tiempo = tiempo - 1;
            StartCoroutine("Tiempo");
        }
    }

    //--------------------CARGA DE FEEDBACK--------------------//
    void CargarFeedback()
    {
        float puntuacionFinal = tiempo / tiempoTotal;
        feedbackmanager.tiempo = puntuacionFinal;
        SceneManager.LoadScene("Feedback_Escena");
    }
}
