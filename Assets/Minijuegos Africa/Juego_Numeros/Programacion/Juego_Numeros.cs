using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Juego_Numeros : MonoBehaviour
{

    public float TiempoDeJuego_Facil = 60;
    public float TiempoDeJuego_Normal = 90;
    public float TiempoDeJuego_Dificil = 120;
    public GameObject Canvas_Botones, Canvas_Juego, Canvas_Final, FacilTexto, NormalTexto, DificilTexto, Acierto, Error, EscenaInicial;

    public Text PuntosText, puntosFinal;



    public static int Dif;

    public bool FacilSelection, NormalSelection, DificilSelection, Barrita;

    static bool Acertar, Fallar;

    public Menu_Pausa Pause;

    public static int puntos;

    public RectSpawn Spawn;

    public float SinTiempo;

    public static int Estrella1, Estrella3;
    //TIMER BARRA
    public Image Barra;
    float TiempoRestante;
    public BarraTiempo Tiempo;

    Audios Sonidos;
    feedbackmanager feedbackmanager;
    public static int counterFacil;

    public static bool avocadowashere = false;
    [SerializeField] Text TimerText;
    //public Text puntosText;
    //public Text PuntosFinal;
    // Start is called before the first frame update
    void Start()
    {
        avocadowashere = false;
        Dificultades();
        Ganar_Puntos.puntos = 0;
        SinTiempo = 0;
        Pause.Resume();
        PuntosText.color = Color.white;
        puntos = 0;
        Sonidos = FindObjectOfType<Audios>();

        feedbackmanager.juego_feedback = "tarean";

        if (Dif == 1)
        {
            Estrella1 = 8;                      //REVISAR ESTO
            Estrella3 = 20;  //??
        }
        else if (Dif == 2)
        {
            Estrella1 = 12;
            Estrella3 = 39; //??
        }
        else if (Dif == 3)
        {
            Estrella1 = 18;
            Estrella3 = 36; //??
        }

        

    }


    // Update is called once per frame

    #region Timer
    void Update()
    {
        SinTiempo -= 1 * Time.deltaTime;
        TimerText.text = SinTiempo.ToString("0 s");


        if (SinTiempo <= 0)
        {
            SinTiempo = 0;
            

        }

        Pause.MenuDePausa();

        if (Acertar)
        {
            PuntosText.text = "" + puntos;
            StartCoroutine(ColorVerde());
            Acertar = false;
        }

        if (Fallar)
        {
            PuntosText.text = "" + puntos;
            StartCoroutine(ColorRojo());
            Fallar = false;
        }


        puntosFinal.text = "" + puntos;


        /*if (avocadowashere == true && FacilSelection == true)
        {
            Facil();
        }*/

    }
    #endregion

    #region Corrutinas Juego
    public IEnumerator Facil()
    {


        //counter = 4;

        while (SinTiempo <= 60 && SinTiempo > 0)
        {
            avocadowashere = true;
            Spawn.SpawnDeObjetosBuenos();
            Spawn.SpawnObjectMalo();

            yield return new WaitForSeconds(10F);

            if (SinTiempo == 0)
            {
                StopAllCoroutines();
                Canvas_Juego.SetActive(false);
                StartCoroutine(GameOver());
                break;
            }
        }
    }

    IEnumerator Normal()
    {
        //counter = 3;

        while (SinTiempo <= 90 && SinTiempo > 0)
        {
            avocadowashere = true;
            Spawn.SpawnDeObjetosBuenosNormal();
            Spawn.SpawnObjectMalosNormal();
            yield return new WaitForSeconds(7F);


            if (SinTiempo == 0)
            {
                StopAllCoroutines();
                Canvas_Juego.SetActive(false);
                StartCoroutine(GameOver());
                break;
            }

        }
    }

    IEnumerator Dificil()
    {
        //counter = 2;

        while (SinTiempo <= 120 && SinTiempo > 0)
        {
            avocadowashere = true;
            Spawn.SpawnDeObjetosBuenosDificil();
            Spawn.SpawnObjectMalosDificil();
            yield return new WaitForSeconds(7F);

            if (SinTiempo == 0)
            {
                StopAllCoroutines();
                Canvas_Juego.SetActive(false);
                StartCoroutine(GameOver());
                break;
            }

        }
    }

    #endregion

    #region Corrutinas Cambios De Escena
    IEnumerator CargaEscenaFacil()
    {
        Canvas_Juego.SetActive(true);
        FacilTexto.SetActive(true);
        yield return new WaitForSeconds(3F);
        SinTiempo = TiempoDeJuego_Facil;
        Barrita = true;
        StartCoroutine(Facil());
    }

    IEnumerator CargaEscenaNormal()
    {
        Canvas_Juego.SetActive(true);
        NormalTexto.SetActive(true);
        yield return new WaitForSeconds(3F);
        SinTiempo = TiempoDeJuego_Normal;
        Barrita = true;
        StartCoroutine(Normal());
    }

    IEnumerator CargaEscenaDificil()
    {
        Canvas_Juego.SetActive(true);
        DificilTexto.SetActive(true);
        yield return new WaitForSeconds(3f);
        SinTiempo = TiempoDeJuego_Dificil;
        Barrita = true;
        StartCoroutine(Dificil());
    }

    #endregion

    #region Dificultades y GameOver

    public void Dificultad_Facil()
    {
        FacilSelection = true;
        StartCoroutine(CargaEscenaFacil());
        Canvas_Botones.SetActive(false);
    }

    public void Dificultad_Normal()
    {
        NormalSelection = true;

        StartCoroutine(CargaEscenaNormal());
        Canvas_Botones.SetActive(false);
    }
    public void Dificultad_Dificil()
    {
        DificilSelection = true;
        StartCoroutine(CargaEscenaDificil());
        Canvas_Botones.SetActive(false);
    }

    IEnumerator GameOver()
    {
        if (puntos >= Estrella1)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }

        if (puntos / Estrella3 <= 0.99f)
        {
            feedbackmanager.tiempo = puntos / Estrella3;
        }
        else
        {
            feedbackmanager.tiempo = 0.99f;
        }


        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Feedback_Escena");
    }
    #endregion

    public void Dificultades()
    {
        EscenaInicial.SetActive(true);
    }

    public static void Acierta()
    {
        puntos = puntos + 1;

        Acertar = true;

    }

    public static void Falla()
    {
        puntos--;
        Fallar = true;

        if (puntos < 0)
        {
            puntos = 0;
        }
    }

    IEnumerator ColorVerde()
    {
        PuntosText.color = Color.green;
        yield return new WaitForSeconds(1f);
        Cambia();

    }

    IEnumerator ColorRojo()
    {
        PuntosText.color = Color.red;
        yield return new WaitForSeconds(1f);
        Cambia();

    }

    void Cambia()
    {
        PuntosText.color = Color.white;
    }


    public void BotonInicio()
    {
        switch (Dif)
        {
            case 1:
                EscenaInicial.SetActive(false);
                Dificultad_Facil();
                break;
            case 2:
                EscenaInicial.SetActive(false);
                Dificultad_Normal();
                break;
            case 3:
                EscenaInicial.SetActive(false);
                Dificultad_Dificil();
                break;
            default:
                break;
        }

    }
}
