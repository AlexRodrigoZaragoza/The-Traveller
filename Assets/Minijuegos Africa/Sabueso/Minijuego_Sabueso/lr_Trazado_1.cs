using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class lr_Trazado_1 : MonoBehaviour
{
    public GameObject[] JuegoFUsuario = new GameObject[9];
    public GameObject[] JuegoMUsuario = new GameObject[16];
    public GameObject[] JuegoDUsuario = new GameObject[25];

    public GameObject FacilObj;
    public GameObject MedioObj;
    public GameObject DificilObj;

    public GameObject DibujoIA;

    public LineRenderer LineR;
    public GameObject LineaDibu;

    public Color DefaultColor;
    public Color ColorResaltado;
    public Renderer Rend;

    public bool isDown = false;
    public bool Active = false;

    public static List<GameObject> Puntos = new List<GameObject>();

    public float magnitud;
    public static int SUMAR;
    public static int NumerosLista;

    public Text PuntosCorrectos;
    public Text IntentosCorrectos;

    public Vector3[,] matrix;
    public Vector3 Clicado;
    Vector3 PosCamara;

    public float magnitudC;

    //AÑADIDO DEL SCRIPT CABLE
    public Vector3 PuntoFinal = new Vector3(-3.0f, 3.0f, 0.0f);
    public Vector3 PuntoInicial = new Vector3(6.0f, 0.0f, 0.0f);

    public static Collider2D collider_2D;



    private static int lastPoint = 0;
    private static List<GameObject> adjPoints = new List<GameObject>();

    public static float intentos = 3;
    public Text Intentos;
    public Text PuntosIncorrectos;

    public GameObject MenuPausa;
    //bool cerrar = false;

    public static bool start_time = false;
    public AudioSource click, Fallo;

    private void Awake()
    {
        if (Application.isEditor == false)
            Debug.unityLogger.logEnabled = false;
    }

    void Start()
    {

        collider_2D = GetComponent<Collider2D>();
        collider_2D.enabled = true;
        Debug.Log(gameObject.name + collider_2D.enabled);
        Intentos.text = "Intentos: " + intentos + "/3";

        LineR.positionCount = 0;


        LineR.positionCount = 0;
        adjPoints.Clear();
        Puntos.Clear();
        lastPoint = 0;
        SUMAR = 0;


    }
    public void OnMouseOver()
    {
        if (isDown == true)
        {

        }
    }


    void Update()
    {
        Debug.Log(gameObject.name + collider_2D.enabled);

    }

    public void Error()
    {
        intentos = intentos - 1;
        Fallo.Play();
        if (intentos > 0)
        {

            for (int i = 0; i < Puntos.Count; i++)
            {
                Puntos[i].GetComponent<Collider2D>().enabled = true;
            }
            Debug.Log("intentos" + intentos);
            LineR.positionCount = 0;
            adjPoints.Clear();
            Puntos.Clear();
            lastPoint = 0;
            SUMAR = 0;

            Intentos.text = "Intentos: " + intentos + "/3";
        }
        if (intentos == 0)
        {
            collider_2D.enabled = true;
            LineR.positionCount = 0;
            adjPoints.Clear();
            Puntos.Clear();
            lastPoint = 0;
            SUMAR = 0;
            Debug.Log("No te quedan intentos");
            IntentosCorrectos.color = Color.red;
            Intentos.text = "Intentos: " + intentos + "/3";
        }
        if (intentos < 0)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
            SceneManager.LoadScene("Feedback_Escena");
        }
    }
    public void OnMouseDown()
    {

        #region  Normal                                       
        if (gameObject.tag == "Boton")
        {
            click.Play();
            LineR.SetWidth(0.3f, 0.3f);


            DibujoIA.SetActive(false);

            if (lr_Selector_Dificultad_1.Facil == true)
            {
                FacilObj.SetActive(true);
                MedioObj.SetActive(false);
                DificilObj.SetActive(false);



                int j = 0;
                bool found = false;
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Input.mousePosition " + p);
                while (j < JuegoFUsuario.Length && !found)
                {

                    float d = Vector2.Distance(p, JuegoFUsuario[j].transform.position);
                    Debug.Log(j + ": " + JuegoFUsuario[j].transform.position + " - " + d);
                    if (Vector2.Distance(p, JuegoFUsuario[j].transform.position) <= 0.5)
                    {
                        Puntos.Add(JuegoFUsuario[j]);
                        found = true;
                    }

                    j++;
                }


                if (Vector3.Distance(Puntos[Puntos.Count - 1].transform.position, Puntos[lastPoint].transform.position) <= 4.5f)
                {
                    adjPoints.Add(Puntos[Puntos.Count - 1]);
                    LineR.positionCount += 1;

                }
                else
                {
                    Puntos.RemoveAt(Puntos.Count - 1);

                }

                lastPoint = Puntos.Count - 1;

                for (int i = 0; i < adjPoints.Count; i++)
                {
                    Debug.Log(i + ":" + adjPoints[i].transform.position);
                    adjPoints[i].GetComponent<Collider2D>().enabled = false;
                    LineR.SetPosition(i, adjPoints[i].transform.position);
                }


                // Debug.Log("SUMAR " + SUMAR);
                //Debug.Log("lr_LineController_1.PuntosSeleccionados[SUMAR].transform.position " + lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x);
                //Debug.Log("Puntos[SUMAR].transform.position " + Puntos[SUMAR].transform.position);

                Vector2 offset = new Vector2(lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x, lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.y) - new Vector2(Puntos[SUMAR].transform.position.x, Puntos[SUMAR].transform.position.y);

                Debug.Log("SU");

                magnitud = Math.Abs(offset.sqrMagnitude);

                Debug.Log("magnitud " + magnitud);

                if (magnitud <= 2)
                {
                    SUMAR++;
                    Debug.Log("Punto " + SUMAR + " Correcto");
                    StartCoroutine(Espera());

                }
                else
                {

                    Debug.Log("Punto " + SUMAR + " incorrecto");
                    StartCoroutine(NoEspera());

                }
                IEnumerator NoEspera()
                {
                    //collider_2D.enabled = false;
                    adjPoints[lastPoint].GetComponent<Renderer>().material.color = Color.red;
                    PuntosIncorrectos.text = "¡Incorrecto!";
                    yield return new WaitForSeconds(1f);
                    PuntosIncorrectos.text = "";
                    // collider_2D.enabled = true;
                    Error();

                }

                IEnumerator Espera()
                {
                    adjPoints[lastPoint].GetComponent<Renderer>().material.color = Color.green;
                    PuntosCorrectos.text = "¡Correcto!";
                    yield return new WaitForSeconds(1f);
                    PuntosCorrectos.text = "";

                }


                if (LineaDibu.GetComponent<lr_LineController_1>().Man.NumPuntos == SUMAR)
                {
                    feedbackmanager.win = true;
                    feedbackmanager.lose = false;
                    SceneManager.LoadScene("Feedback_Escena");

                }
            }




            if (lr_Selector_Dificultad_1.Medio == true)
            {
                FacilObj.SetActive(false);
                MedioObj.SetActive(true);
                DificilObj.SetActive(false);



                int j = 0;
                bool found = false;
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Input.mousePosition " + p);
                while (j < JuegoMUsuario.Length && !found)
                {

                    float d = Vector2.Distance(p, JuegoMUsuario[j].transform.position);
                    Debug.Log(j + ": " + JuegoMUsuario[j].transform.position + " - " + d);
                    if (Vector2.Distance(p, JuegoMUsuario[j].transform.position) <= 1.5)
                    {
                        Puntos.Add(JuegoMUsuario[j]);
                        found = true;

                    }

                    j++;
                }


                if (Vector3.Distance(Puntos[Puntos.Count - 1].transform.position, Puntos[lastPoint].transform.position) <= 3f)
                {
                    adjPoints.Add(Puntos[Puntos.Count - 1]);
                    LineR.positionCount += 1;

                }
                else
                {
                    Puntos.RemoveAt(Puntos.Count - 1);

                }

                lastPoint = Puntos.Count - 1;

                for (int i = 0; i < adjPoints.Count; i++)
                {
                    Debug.Log(i + ":" + adjPoints[i].transform.position);
                    adjPoints[i].GetComponent<Collider2D>().enabled = false;
                    LineR.SetPosition(i, adjPoints[i].transform.position);
                }


                Debug.Log("SUMAR " + SUMAR);
                Debug.Log("lr_LineController_1.PuntosSeleccionados[SUMAR].transform.position " + lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x);
                Debug.Log("Puntos[SUMAR].transform.position " + Puntos[SUMAR].transform.position);

                Vector2 offset = new Vector2(lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x, lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.y) - new Vector2(Puntos[SUMAR].transform.position.x, Puntos[SUMAR].transform.position.y);

                Debug.Log("SU");

                magnitud = Math.Abs(offset.sqrMagnitude);

                Debug.Log("magnitud " + magnitud);

                if (magnitud <= 2)
                {
                    SUMAR++;
                    Debug.Log("Punto " + SUMAR + " Correcto");
                    StartCoroutine(Espera());

                }
                else
                {
                    Debug.Log("Punto " + SUMAR + " incorrecto");
                    StartCoroutine(NoEspera());
                }
                IEnumerator NoEspera()
                {

                    adjPoints[lastPoint].GetComponent<Renderer>().material.color = Color.red;
                    PuntosIncorrectos.text = "¡Incorrecto!";
                    yield return new WaitForSeconds(1f);
                    PuntosIncorrectos.text = "";

                    Error();


                }

                IEnumerator Espera()
                {
                    PuntosCorrectos.text = "¡Correcto!";
                    yield return new WaitForSeconds(1f);
                    PuntosCorrectos.text = "";
                }


                if (LineaDibu.GetComponent<lr_LineController_1>().Man.NumPuntos == SUMAR)
                {
                    feedbackmanager.win = true;
                    feedbackmanager.lose = false;
                    SceneManager.LoadScene("Feedback_Escena");

                }
            }


            if (lr_Selector_Dificultad_1.Dificil == true)
            {
                FacilObj.SetActive(false);
                MedioObj.SetActive(false);
                DificilObj.SetActive(true);



                int j = 0;
                bool found = false;
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Input.mousePosition " + p);
                while (j < JuegoDUsuario.Length && !found)
                {

                    float d = Vector2.Distance(p, JuegoDUsuario[j].transform.position);
                    Debug.Log(j + ": " + JuegoDUsuario[j].transform.position + " - " + d);
                    if (Vector2.Distance(p, JuegoDUsuario[j].transform.position) <= 0.5)
                    {
                        Puntos.Add(JuegoDUsuario[j]);
                        found = true;

                    }

                    j++;
                }


                if (Vector3.Distance(Puntos[Puntos.Count - 1].transform.position, Puntos[lastPoint].transform.position) <= 3f)
                {
                    adjPoints.Add(Puntos[Puntos.Count - 1]);
                    LineR.positionCount += 1;

                }
                else
                {
                    Puntos.RemoveAt(Puntos.Count - 1);

                }


                lastPoint = Puntos.Count - 1;

                for (int i = 0; i < adjPoints.Count; i++)
                {
                    Debug.Log(i + ":" + adjPoints[i].transform.position);
                    adjPoints[i].GetComponent<Collider2D>().enabled = false;
                    LineR.SetPosition(i, adjPoints[i].transform.position);
                }


                Debug.Log("SUMAR " + SUMAR);
                Debug.Log("lr_LineController_1.PuntosSeleccionados[SUMAR].transform.position " + lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x);
                Debug.Log("Puntos[SUMAR].transform.position " + Puntos[SUMAR].transform.position);

                Vector2 offset = new Vector2(lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.x, lr_LineController_1.PuntosRepetidos[SUMAR].transform.position.y) - new Vector2(Puntos[SUMAR].transform.position.x, Puntos[SUMAR].transform.position.y);

                Debug.Log("SU");

                magnitud = Math.Abs(offset.sqrMagnitude);

                Debug.Log("magnitud " + magnitud);

                if (magnitud <= 2)
                {
                    SUMAR++;
                    Debug.Log("Punto " + SUMAR + " Correcto");
                    StartCoroutine(Espera());

                }
                else
                {
                    Debug.Log("Punto " + SUMAR + " incorrecto");
                    StartCoroutine(NoEspera());
                }
                IEnumerator NoEspera()
                {

                    adjPoints[lastPoint].GetComponent<Renderer>().material.color = Color.red;

                    PuntosIncorrectos.text = "¡Incorrecto!";
                    yield return new WaitForSeconds(1f);
                    PuntosIncorrectos.text = "";

                    Error();


                }

                IEnumerator Espera()
                {
                    PuntosCorrectos.text = "¡Correcto!";
                    yield return new WaitForSeconds(1f);
                    PuntosCorrectos.text = "";
                }



                if (LineaDibu.GetComponent<lr_LineController_1>().Man.NumPuntos == SUMAR)
                {
                    feedbackmanager.win = true;
                    feedbackmanager.lose = false;
                    SceneManager.LoadScene("Feedback_Escena");
                    //Canvas.SetActive(true);
                }
            }


            #endregion




        }
    }
}
