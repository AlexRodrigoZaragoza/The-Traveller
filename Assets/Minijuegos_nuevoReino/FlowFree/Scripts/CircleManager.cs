using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleManager : MonoBehaviour
{

    public static string changeColor = "none";
    public static List<GameObject> posis = new List<GameObject>();
    public static List<GameObject> allGO = new List<GameObject>();
    public GameObject[] NivelesF = new GameObject[10];
    public GameObject[] NivelesM = new GameObject[10];
    public GameObject[] NivelesD = new GameObject[10];

    public static int numColors;
    public static int realColors;

    public GameObject MenuPausa;
    public GameObject Boton;
    public GameObject Inicio;
    public GameObject Marco;
    GameObject Tablero;

    public bool finalizado;

    public Animator anim;

    public static float tiempo, tiempototal;
    [SerializeField] Text TimerText;
    public GameObject muestratexto;
    Circle_Info circulo;

    public bool cerrar, empezado;
    public static bool win, lose;
    public static bool facil, medio, dificil;

    private void Start()
    {
        Inicio.SetActive(true);
        posis.Clear();
        allGO.Clear();
        numColors = 0;
        tiempo = 0;
        tiempototal = 0;
        empezado = false;
        win = false;
        lose = false;
        feedbackmanager.juego_feedback = "flow";

        if (facil)
        {
            CircleManager.realColors = 3;
            CircleManager.tiempo = 180f;
            CircleManager.tiempototal = 180f;
            Circle_Info.rango = 1.70f;  
        }

        if (medio)
        {
            CircleManager.tiempo = 360f;
            CircleManager.tiempototal = 360f;
            CircleManager.realColors = 4;
            Circle_Info.rango = 1.60f;
        }

        if (dificil)
        {
            CircleManager.tiempo = 360f;
            CircleManager.tiempototal = 360f;
            CircleManager.realColors = 5;
            Circle_Info.rango = 1.50f;
        }

    
    }

    public void Update()
    {
        if(finalizado==false)
        {
            tiempo -= 1 * Time.deltaTime;
        }

        TimerText.text = tiempo.ToString("0 s");

        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false && empezado == true)
        {
            if(cerrar == false)
            {
                TimerText.gameObject.SetActive(false);
                Time.timeScale = 0;
                cerrar = true;
                MenuPausa.SetActive(true);
                Boton.SetActive(false);
                Tablero.SetActive(false);
                Marco.SetActive(false);
                anim.Play("Anim_PauseOn");
            }
            else
            {
                TimerText.gameObject.SetActive(true);
                Time.timeScale = 1;
                cerrar = false;
                MenuPausa.SetActive(false);
                Boton.SetActive(true);
                Tablero.SetActive(true);
                Marco.SetActive(true);
                anim.Play("Anim_PauseOff");
            }
        }

        if(tiempo <= 20)
        {
            TimerText.color = Color.red;
        }

        if (tiempo >= 20)
        {
            TimerText.color = Color.black;
        }

        if (tiempo <= 0)
        {
            finalizado = true;
            lose = true;
            StartCoroutine(delayEnd());
        }
    }
    public static void ResetList()
    {
        Debug.Log("Estoy en el otro");
        for (int i = 0; i<posis.Count; i++)
        {
            posis[i].GetComponent<Circle_Info>().done = false;

            if (posis[i].GetComponent<Circle_Info>().changed)
            {
                posis[i].GetComponent<Circle_Info>().myColor = "none";
                posis[i].GetComponent<Circle_Info>().changed = false;
                posis[i].GetComponent<Circle_Info>().ReloadColors();
            }

        }
    }

    public static void ResetAll()
    {
        Debug.Log("Estoy");
        for (int i = 0; i < allGO.Count; i++)
        {
            allGO[i].GetComponent<Circle_Info>().done = false;

            if (allGO[i].GetComponent<Circle_Info>().changed)
            {
                allGO[i].GetComponent<Circle_Info>().myColor = "none";
                allGO[i].GetComponent<Circle_Info>().changed = false;
            }

            allGO[i].GetComponent<Circle_Info>().ReloadColors();
            numColors = 0;
        }
    }

    public void Check()
    {
        bool notdone = false;

        if (numColors < realColors)
        {
            notdone = true;
        }

        foreach (var GO in allGO)
        {
            if (GO.GetComponent<Circle_Info>().myColor == "none")
            {
                notdone = true;
            }
        }

        if (!notdone)
        {
            win = true;
            finalizado = true;
            StartCoroutine(delayEnd());
        }
    }

    public void Empezar()
    {

        if (facil == true)
        {
            tiempo = 180;
            muestratexto.SetActive(true);
            int Rand = Random.Range(0, 9);
            NivelesF[Rand].SetActive(true);
            Tablero = NivelesF[Rand];
            Tablero.SetActive(true);
            Boton.SetActive(true);
            Inicio.SetActive(false);
            empezado = true;
            finalizado = false;
        }
        else if (medio == true)
        {
            tiempo = 360;
            muestratexto.SetActive(true);
            int Rand = Random.Range(0, 9);
            NivelesM[Rand].SetActive(true);
            Tablero = NivelesM[Rand];
            Tablero.SetActive(true);
            Boton.SetActive(true);
            Inicio.SetActive(false);
            empezado = true;
            finalizado = false;
        }
        else if (dificil == true)
        {
            tiempo = 360;
            muestratexto.SetActive(true);
            int Rand = Random.Range(0, 9);
            NivelesD[Rand].SetActive(true);
            Tablero = NivelesD[Rand];
            Tablero.SetActive(true);
            Boton.SetActive(true);
            Inicio.SetActive(false);
            empezado = true;
            finalizado = false;
        }

        foreach (var dot in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (dot.name == "Circle")
            {
                allGO.Add(dot);
            }
        }
    }

    public IEnumerator delayEnd()
    {
        if (win == true)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else if (lose == true)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }

        feedbackmanager.tiempo = tiempototal / tiempo;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Feedback_Escena");
    }

}
