using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lr_Selector_Dificultad : MonoBehaviour
{


    public static int NumPuntos;
    [SerializeField]
    public static int Dificultad;
    public Transform[] JuegoF = new Transform[9];
    public Transform[] JuegoM = new Transform[16];
    public Transform[] JuegoD = new Transform[25];
    
    public float SinTiempo = 0f;
    public lr_Trazado l_trazado;
    public lr_LineController l_controller;
    public Text TimerText;
    bool activado;

    public GameObject IAFacil;
    public GameObject IAMedio;
    public GameObject IADificil;

    public GameObject UsuarioFacil;
    public GameObject UsuarioMedio;
    public GameObject UsuarioDificil;

    private void Start()
    {
        CrearLineas();
    }
    public void CrearLineas()
    {
        switch(Dificultad)
        {

            case 1:
        
                SinTiempo = 30f;
                lr_Trazado.TotalTime = SinTiempo;
                NumPuntos = 5;
                break;


            case 2:

                SinTiempo = 40f;
                lr_Trazado.TotalTime = SinTiempo;
                NumPuntos = 8;
                break;


            case 3:

                SinTiempo = 40f;
                lr_Trazado.TotalTime = SinTiempo;
                NumPuntos = 11;
                break;


            default:
            Debug.Log("NumPuntos no selecionada");
            break;
        }

        l_controller.Difs();
    }

}




