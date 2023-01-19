using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class lr_Trazado : MonoBehaviour
{
    public Transform[] JuegoFUsuario = new Transform[9];
    public Transform[] JuegoMUsuario = new Transform[16];
    public Transform[] JuegoDUsuario = new Transform[25];

    Audios Sonidos;

    public static int victoria;

    public Vector2 PosInicial;
    public Vector2 PosInicial1;
    public LineRenderer LineR;
    public LineRenderer LineaDibujo;
    GameObject linea;

    public Color DefaultColor;
    public Color ColorResaltado;
    public Renderer Rend;

    public GameObject CorrectoIcono;

    public int count, comp;

    public bool isDown = false;
    public bool Active = false;
    public bool entrado = false;

    public Text Correcto;
    public Text Incorrecto;

    public static List<Vector3> Puntos = new List<Vector3>();
    public static List<Vector3> Puntos2 = new List<Vector3>();
    public static List<Vector3> Pulsados = new List<Vector3>();

    public float magnitud;
    public static int SUMAR;
    public static int NumerosLista;
    int clicks = 0;

    public Color negro;

    public Vector3[,] matrix;
    public Vector3 Clicado;

    public float magnitudC;

    public int correcto = 0;
    public int finalds;

    public bool acabado = false;

    public Text finalT;

    Vector3 Comprobacion;

    int filaC = 0, columnaC = 0, i;

    public lr_LineController cont;

    int j, h;

    bool existe = false;
    float mag;
    int conte;
    public static bool win;
    public static bool lose;

    public static float RealTime;
    public static float TotalTime;


    List<bool> Comprobate = new List<bool>();


    void Start()
    {
        LineR.positionCount = 0;
        SUMAR = 0;
        Puntos.Clear();
        Pulsados.Clear();
        Comprobate.Clear();
        acabado = false;
        finalds = lr_LineController.IA.Count - 1;
        conte = lr_LineController.IA.Count;
        Corregir_();
        count = 0;
        Sonidos = FindObjectOfType<Audios>();
        win = false;
        lose = false;
    }

    public IEnumerator esperar()
    {
        yield return new WaitForSeconds(2f);

        CorrectoIcono.SetActive(false);
    }

    public void Corregir_()
    {
        SUMAR = 0;
        j = 0;
        i = 0;
        h = 0;
        Puntos.Clear();
        Pulsados.Clear();
        Comprobate.Clear();
        Puntos2.Clear();
        lr_LineController.comprobar_ = lr_LineController.comprobar2_;
        conte = lr_LineController.IA.Count;
        LineR.positionCount= 0;
        correcto = 0;
        Correcto.text = "Correctos: " + j;
        Incorrecto.text = "Incorrectos: " + h;
        entrado = false;
        comp = 0;
        count = 0;
    }




    void Update()
    {
        if(acabado == true)
        {
            final();
        }

        if(SUMAR == lr_LineController.IA.Count)
        {
           acabado = true;
        }
    }

    void final()
    {
        if (SUMAR == correcto && correcto == lr_LineController.IA.Count)
        {
            win = true;
            lose = false;
            lr_LineController.running = false;
            victoria = 0;
            Puntos.Clear();
            lr_Trazado.RealTime = lr_LineController.crono;
            StartCoroutine(delayEnd());
        }

        if(SUMAR != correcto && correcto != lr_LineController.IA.Count)
        {
            win = false;
            lose = true;
            lr_LineController.running = false;
            victoria = 1;
            Puntos.Clear();
            lr_Trazado.RealTime = lr_LineController.crono;
            StartCoroutine(delayEnd());
        }

        acabado = false;
    }

    public IEnumerator delayEnd()
    {
        if(win == true)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else if(lose == true)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }

        feedbackmanager.tiempo = RealTime / TotalTime;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Feedback_Escena");
    }

    public void OnMouseDown()
    {
        #region FACIL
        if (gameObject.tag == "Boton")
        {
            PosInicial1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Puntos2.Add(new Vector3(Mathf.Round(PosInicial1.x * 10.0f) * 0.1f, Mathf.Round(PosInicial1.y * 10.0f) * 0.1f, 0f));

            comp = lr_LineController.IA.Count - 1;

            Vector3 Comprobacion1 = new Vector3(lr_LineController.IA[0].x, lr_LineController.IA[0].y, lr_LineController.IA[0].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);
            Vector3 Comprobacion2 = new Vector3(lr_LineController.IA[comp].x, lr_LineController.IA[comp].y, lr_LineController.IA[comp].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);

            float Comp_1 = Comprobacion1.sqrMagnitude;
            float Comp_2 = Comprobacion2.sqrMagnitude;


            if (lr_Selector_Dificultad.Dificultad == 1 && Comp_1 < 2 && Comp_2 > 2)
            {
                entrado = true;

                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 2)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);
                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {

                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {
                        Vector3 offset = new Vector3(lr_LineController.IA[SUMAR].x, lr_LineController.IA[SUMAR].y, lr_LineController.IA[SUMAR].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);

                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[j]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {
                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }
                    Comprobate.Clear();

                    if (magnitud <= 2)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 2)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }

                    SUMAR++;
                }

            }

            else if (lr_Selector_Dificultad.Dificultad == 1 && Comp_1 > 2 && Comp_2 < 2)
            {
                entrado = true;
                Debug.Log("vergon");
                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 2)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {
                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {

                        Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);
                        conte--;
                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[conte]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {

                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }
                    Comprobate.Clear();



                    if (magnitud <= 2)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());

                    }
                    if (magnitud > 2)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }
            }


            if (lr_Selector_Dificultad.Dificultad == 1 && entrado == false)
            {
                Debug.Log("vergon2");
                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 2)
                    {
                        existe = true;
                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }

                else
                {
                    LineR.positionCount += 1;
                    Debug.Log("3");
                    for (int j = 0; j < Puntos.Count; j++)
                    {
                        LineR.SetPosition(j, Puntos[j]);
                        Sonidos.SeleccionAudio(1);
                    }
                    Comprobate.Clear();

                    Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                    magnitud = Math.Abs(offset.sqrMagnitude);

                    if (magnitud <= 2)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 2)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }

                entrado = false;
            }

        }



        #endregion

        #region MEDIO
        if (gameObject.tag == "Boton")
        {
            PosInicial1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Puntos2.Add(new Vector3(Mathf.Round(PosInicial1.x * 10.0f) * 0.1f, Mathf.Round(PosInicial1.y * 10.0f) * 0.1f, 0f));

            int comp = lr_LineController.IA.Count - 1;

            Vector3 Comprobacion1 = new Vector3(lr_LineController.IA[0].x, lr_LineController.IA[0].y, lr_LineController.IA[0].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);
            Vector3 Comprobacion2 = new Vector3(lr_LineController.IA[comp].x, lr_LineController.IA[comp].y, lr_LineController.IA[comp].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);

            float Comp_1 = Comprobacion1.sqrMagnitude;
            float Comp_2 = Comprobacion2.sqrMagnitude;


            if (lr_Selector_Dificultad.Dificultad == 2 && Comp_1 < 2 && Comp_2 > 2)
            {
                entrado = true;

                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1.1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);
                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {
                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {
                        Vector3 offset = new Vector3(lr_LineController.IA[SUMAR].x, lr_LineController.IA[SUMAR].y, lr_LineController.IA[SUMAR].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);

                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[j]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {
                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                }
            }

            else if (lr_Selector_Dificultad.Dificultad == 2 && Comp_1 > 2 && Comp_2 < 2)
            {
                entrado = true;

                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1.1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {
                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {

                        Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);
                        conte--;
                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[conte]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {

                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }
                    Comprobate.Clear();

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }
            }

            if (lr_Selector_Dificultad.Dificultad == 2 && entrado == false)
            {
                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1.1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }

                else
                {
                    LineR.positionCount += 1;

                    for (int j = 0; j < Puntos.Count; j++)
                    {
                        LineR.SetPosition(j, Puntos[j]);
                        Sonidos.SeleccionAudio(1);
                    }
                    Comprobate.Clear();

                    Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                    magnitud = Math.Abs(offset.sqrMagnitude);

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }

                entrado = false;
            }
        }

        #endregion

        #region DIFICIL
        if (gameObject.tag == "Boton")
        {
            PosInicial1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Puntos2.Add(new Vector3(Mathf.Round(PosInicial1.x * 10.0f) * 0.1f, Mathf.Round(PosInicial1.y * 10.0f) * 0.1f, 0f));

            int comp = lr_LineController.IA.Count - 1;

            Vector3 Comprobacion1 = new Vector3(lr_LineController.IA[0].x, lr_LineController.IA[0].y, lr_LineController.IA[0].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);
            Vector3 Comprobacion2 = new Vector3(lr_LineController.IA[comp].x, lr_LineController.IA[comp].y, lr_LineController.IA[comp].z) - new Vector3(Puntos2[0].x, Puntos2[0].y, Puntos2[0].z);

            float Comp_1 = Comprobacion1.sqrMagnitude;
            float Comp_2 = Comprobacion2.sqrMagnitude;




            if (lr_Selector_Dificultad.Dificultad == 3 && Comp_1 < 2 && Comp_2 > 2)
            {
                entrado = true;

                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);
                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {
                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {
                        Vector3 offset = new Vector3(lr_LineController.IA[SUMAR].x, lr_LineController.IA[SUMAR].y, lr_LineController.IA[SUMAR].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);

                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[j]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {

                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }
                    Comprobate.Clear();

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                }
 
            }

            else if (lr_Selector_Dificultad.Dificultad == 3 && Comp_1 > 2 && Comp_2 < 2)
            {
                entrado = true;

                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }
                else
                {
                    LineR.positionCount += 1;
                    for (int j = count; j < Puntos.Count; j++)
                    {

                        Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                        magnitud = Math.Abs(offset.sqrMagnitude);
                        conte--;
                        if (magnitud <= 2)
                        {
                            LineR.SetPosition(j, lr_LineController.IA[conte]);
                            Sonidos.SeleccionAudio(0);
                        }
                        if (magnitud > 2)
                        {

                            LineR.SetPosition(j, Puntos[j]);
                            Sonidos.SeleccionAudio(1);
                        }

                        count++;
                    }
                    Comprobate.Clear();

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }
            }

            if (lr_Selector_Dificultad.Dificultad == 3 && entrado == false)
            {
                PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));
                Pulsados.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));


                for (int i = 0; i < Puntos.Count - 1; i++)
                {
                    Vector3 Comprobar = new Vector3(Puntos[i].x, Puntos[i].y, Puntos[i].z) - new Vector3(Pulsados[SUMAR].x, Pulsados[SUMAR].y, Pulsados[SUMAR].z);
                    mag = Comprobar.sqrMagnitude;

                    if (mag < 1)
                    {
                        existe = true;

                    }
                    else
                    {
                        existe = false;
                    }
                    Comprobate.Add(existe);

                }

                if (Comprobate.Contains(true))
                {
                    Puntos.RemoveAt(SUMAR);
                    Pulsados.RemoveAt(SUMAR);
                    Comprobate.Clear();
                }

                else
                {
                    LineR.positionCount += 1;

                    for (int j = 0; j < Puntos.Count; j++)
                    {
                        LineR.SetPosition(j, Puntos[j]);
                        Sonidos.SeleccionAudio(1);
                    }
                    Comprobate.Clear();

                    Vector3 offset = new Vector3(lr_LineController.IA[lr_LineController.comprobar_].x, lr_LineController.IA[lr_LineController.comprobar_].y, lr_LineController.IA[lr_LineController.comprobar_].z) - new Vector3(Puntos[SUMAR].x, Puntos[SUMAR].y, Puntos[SUMAR].z);
                    magnitud = Math.Abs(offset.sqrMagnitude);

                    if (magnitud <= 1.1)
                    {
                        j++;
                        Correcto.text = "Correctos: " + j;
                        correcto++;
                        CorrectoIcono.SetActive(true);
                        StartCoroutine(esperar());
                    }
                    if (magnitud > 1.1)
                    {
                        h++;
                        Incorrecto.text = "Incorrectos: " + h;
                    }
                    SUMAR++;
                    lr_LineController.comprobar_--;
                }

                entrado = false;
            }
        }
        #endregion
    }
}
