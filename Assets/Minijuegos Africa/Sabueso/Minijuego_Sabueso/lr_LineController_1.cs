using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lr_LineController_1 : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;

    public Renderer Rend;
    private LineRenderer lr;
    //public lr_Raton rat;
    public lr_Selector_Dificultad_1 Man;
    public Text puntosT;
    string conversion;
    public static List<int> NumRepetidos = new List<int>();
    public static List<Vector3> IA = new List<Vector3>();
    //Color color1 = Color.white;
    //Color color2 = Color.red;

    //EXTRA
   // private Collider2D collider2D;
   // private static int lastPointIA = 0;
    public static List<GameObject> PuntosRepetidos = new List<GameObject>();
    public static List<GameObject> PuntosSeleccionados = new List<GameObject>();
    GameObject PuntoAnterior;
    GameObject PuntoSeleccionado;

    public Material Transparente;
    public Material NoTransparente;
    Renderer rend;

    public  GameObject FacilIA;
    public  GameObject MedioIA;
    public  GameObject DificilIA;

    public GameObject DibujoObjeto;

    public GameObject FacilPrint;
    public GameObject MedioPrint;
    public GameObject DificilPrint;

    //public GameObject LogoTiempo;
    public GameObject IATexto;
    public GameObject DibujarTexto;

    public GameObject NoPrint;
    public static float TiempoArab = 0.0f;
    float TiempoTotal = 0;
    public Text Tempo;

    bool inicio;
    bool timer = false;

    public GameObject MenuPausa;

    public Animator anim;

    public static bool start_time = false;
    bool cerrar = false;

    private void Awake()
    {
        if (Application.isEditor == false)
            Debug.unityLogger.logEnabled = false;


    }
    private void Start()
    {
        //start_time = false;
        Reanudar();
        lr = GetComponent<LineRenderer>();
        inicio = true;
        lr.positionCount = 0;
        rend = lr.GetComponent<Renderer>();

        PuntosRepetidos.Clear();
        PuntosSeleccionados.Clear();
        NumRepetidos.Clear();
        IA.Clear();
        lr.positionCount = 0;
        TiempoArab = 0.0f;
        timer = false;
        feedbackmanager.juego_feedback = "sabueso";
       

        lr_Trazado_1.intentos = 3;

    }

    private void Update()
    {
        if (inicio) 
        {
            StartCoroutine(pasos());

            inicio = false;       
        }

        conversion = Man.NumPuntos.ToString();
        if (timer == true)
        {
            TiempoArab -= 1 * Time.deltaTime;
            Tempo.text = TiempoArab.ToString("Tiempo:         " +"  0" + " s");

            if (TiempoArab < 5)
            {
                Tempo.color = Color.red;
            }


            if (TiempoArab <= 0)
            {
                TiempoArab = 0;
                Debug.Log("FIN DE LA PARTIDA");
                feedbackmanager.win = false;
                feedbackmanager.lose = true;
                SceneManager.LoadScene("Feedback_Escena");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && start_time == true && Settings.isOn == false)
        {
            
            if (cerrar == false)
            {
                Time.timeScale = 0;
                MenuPausa.SetActive(true);
                cerrar = true;
                anim.Play("Anim_PauseOn");
                FacilIA.SetActive(false);
                MedioIA.SetActive(false);
                DificilIA.SetActive(false);

                FacilPrint.SetActive(false);
                MedioPrint.SetActive(false);
                DificilPrint.SetActive(false);
               
            }
            else
            {
                //StartCoroutine(resume_Anim());
               
            }
        }
       
    }
    public IEnumerator resume_Anim()
    {
        anim.Play("Anim_PauseOff");
        yield return new WaitForSecondsRealtime(1f);
        MenuPausa.SetActive(false);
        cerrar = false;
        
        Time.timeScale = 1;
        MenuPausa.SetActive(false);
        cerrar = false;
        if (lr_Selector_Dificultad_1.Facil == true)
        {
            FacilIA.SetActive(true);
            FacilPrint.SetActive(true);

        }
        if (lr_Selector_Dificultad_1.Medio == true)
        {
            MedioIA.SetActive(true);
            MedioPrint.SetActive(true);

        }
        if (lr_Selector_Dificultad_1.Dificil == true)
        {
            DificilIA.SetActive(true);
            DificilPrint.SetActive(true);

        }
       
    }
    public void Reiniciar()
    {

        Time.timeScale = 1;
        lr_Selector_Dificultad_1.Facil = false;
        lr_Selector_Dificultad_1.Medio = false;
        lr_Selector_Dificultad_1.Dificil = false;


        lr_Trazado_1.intentos = 3;

        feedbackmanager.tiempo = (TiempoArab / TiempoTotal);
        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");

    }

    public void Reanudar()
    {
        StartCoroutine(resume_Anim());
    }
    IEnumerator pasos()
    {
        
        lr.SetWidth(0.3f, 0.3f);
        DibujoObjeto.SetActive(false);
   


        if (lr_Selector_Dificultad_1.Facil == true)
        {
            FacilIA.SetActive(true);
            MedioIA.SetActive(false);
            DificilIA.SetActive(false);

            FacilPrint.SetActive(true);
            MedioPrint.SetActive(false);
            DificilPrint.SetActive(false);

            start_time = true;
            NoPrint.SetActive(true);
            //LogoTiempo.SetActive(false);
            IATexto.SetActive(true);
            DibujarTexto.SetActive(false);
           

            for (int num = 0; num < Man.NumPuntos; num++)
            {

                if (PuntosRepetidos.Count == 0)
                {
                    int NumRandom = Random.Range(0, 9);//CAMBIAR EL NUMERO 9 POR EL NUMERO DE LAS OTRAS DIFICULTADES
                    PuntoAnterior = (Man.JuegoF[NumRandom]);
                    PuntosSeleccionados.Add(PuntoAnterior);
                    PuntosRepetidos.Add(PuntoAnterior);
                    PuntoSeleccionado = PuntoAnterior;
                }
                else
                {
                    for (int i = 0; i < 9; i++) //CAMBIAR EL NUMERO 9 POR EL NUMERO DE LAS OTRAS DIFICULTADES
                    {

                        if (Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoF[i].transform.position) <= 3.5f && Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoF[i].transform.position) > 2.0f)
                        {
                            Debug.Log(Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoF[i].transform.position));
                            PuntosSeleccionados.Add(Man.JuegoF[i]);

                        }
                    }

                    for (int i = 0; i < PuntosRepetidos.Count; i++)
                    {
                        if (PuntosSeleccionados.Contains(PuntosRepetidos[i]))
                        {
                            PuntosSeleccionados.Remove(PuntosRepetidos[i]);
                        }
                    }
                    if (PuntosSeleccionados.Count == 0)
                    {
                       Man.NumPuntos = PuntosRepetidos.Count;
                    }
                    else
                    {
                        PuntoSeleccionado = PuntosSeleccionados[Random.Range(0, PuntosSeleccionados.Count - 1)];
                        PuntosRepetidos.Add(PuntoSeleccionado);
                        PuntoAnterior = PuntoSeleccionado;
                    }


                }




                lr.positionCount += 1;
                lr.SetPosition(num, PuntoSeleccionado.transform.position);
                PuntosSeleccionados.Clear();
                PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.blue;

                yield return new WaitForSeconds(2f);

                PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.green;

            }
            rend.material = Transparente;
            NoPrint.SetActive(false);
            DibujoObjeto.SetActive(true);
            //LogoTiempo.SetActive(true);
            IATexto.SetActive(false);
            DibujarTexto.SetActive(true);
            start_time = true;
            
            //iniciar timer
            TiempoArab = 60f;
            TiempoTotal = 60;

            timer = true;
           

            if (TiempoArab < 5)
            {
                Tempo.color = Color.red;
            }


            if (TiempoArab <= 0)
            {
                TiempoArab = 0;
                Debug.Log("FIN DE LA PARTIDA");
                SceneManager.LoadScene("Feedback_Escena");
            }
        }
        

          if (lr_Selector_Dificultad_1.Medio == true)
          {
            FacilIA.SetActive(false);
            MedioIA.SetActive(true);
            DificilIA.SetActive(false);

            FacilPrint.SetActive(false);
            MedioPrint.SetActive(true);
            DificilPrint.SetActive(false);

            start_time = true;
            NoPrint.SetActive(true);
            //LogoTiempo.SetActive(false);
            IATexto.SetActive(true);
            DibujarTexto.SetActive(false);


            for (int num = 0; num < Man.NumPuntos; num++)
              {

                  if (PuntosRepetidos.Count == 0)
                  {
                      int NumRandom = Random.Range(0, 16);//CAMBIAR EL NUMERO POR EL NUMERO DE LAS OTRAS DIFICULTADES
                      PuntoAnterior = (Man.JuegoM[NumRandom]);
                      PuntosSeleccionados.Add(PuntoAnterior);
                      PuntosRepetidos.Add(PuntoAnterior);
                      PuntoSeleccionado = PuntoAnterior;
                  }
                  else
                  {
                      for (int i = 0; i < 16; i++) //CAMBIAR EL NUMERO POR EL NUMERO DE LAS OTRAS DIFICULTADES
                      {

                          if (Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoM[i].transform.position) <= 3.0f && Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoM[i].transform.position) > 1.5f)
                          {
                              Debug.Log(Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoM[i].transform.position));
                              PuntosSeleccionados.Add(Man.JuegoM[i]);

                          }
                      }

                      for (int i = 0; i < PuntosRepetidos.Count; i++)
                      {
                          if (PuntosSeleccionados.Contains(PuntosRepetidos[i]))
                          {
                              PuntosSeleccionados.Remove(PuntosRepetidos[i]);
                          }
                      }
                      if (PuntosSeleccionados.Count == 0)
                      {
                        Man.NumPuntos = PuntosRepetidos.Count;
                      }
                    else
                    {
                        PuntoSeleccionado = PuntosSeleccionados[Random.Range(0, PuntosSeleccionados.Count - 1)];
                        PuntosRepetidos.Add(PuntoSeleccionado);
                        PuntoAnterior = PuntoSeleccionado;
                    }

                  }




                  lr.positionCount += 1;
                  lr.SetPosition(num, PuntoSeleccionado.transform.position);
                  PuntosSeleccionados.Clear();
                  PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.blue;

                  yield return new WaitForSeconds(2f);

                  PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.green;

            }
              rend.material = Transparente;
              NoPrint.SetActive(false);
            //LogoTiempo.SetActive(true);
            IATexto.SetActive(false);
            DibujarTexto.SetActive(true);
            DibujoObjeto.SetActive(true);

           
            start_time = true;

            TiempoArab = 90f;
            TiempoTotal = 90;
            timer = true;
           
            

            if (TiempoArab < 5)
            {
                Tempo.color = Color.red;
            }


            if (TiempoArab <= 0)
            {
                TiempoArab = 0;
                Debug.Log("FIN DE LA PARTIDA");
                SceneManager.LoadScene("Feedback_Escena");
            }

        }

          if (lr_Selector_Dificultad_1.Dificil == true)
          {
            FacilIA.SetActive(false);
            MedioIA.SetActive(false);
            DificilIA.SetActive(true);

            FacilPrint.SetActive(false);
            MedioPrint.SetActive(false);
            DificilPrint.SetActive(true);

            start_time = true;
            NoPrint.SetActive(true);
            //LogoTiempo.SetActive(false);
            IATexto.SetActive(true);
            DibujarTexto.SetActive(false);

            for (int num = 0; num < Man.NumPuntos; num++)
              {

                  if (PuntosRepetidos.Count == 0)
                  {
                      int NumRandom = Random.Range(0, 25);//CAMBIAR EL NUMERO POR EL NUMERO DE LAS OTRAS DIFICULTADES
                      PuntoAnterior = (Man.JuegoD[NumRandom]);
                      PuntosSeleccionados.Add(PuntoAnterior);
                      PuntosRepetidos.Add(PuntoAnterior);
                      PuntoSeleccionado = PuntoAnterior;
                  }
                  else
                  {
                      for (int i = 0; i < 25; i++) //CAMBIAR EL NUMERO POR EL NUMERO DE LAS OTRAS DIFICULTADES
                      {

                          if (Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoD[i].transform.position) <= 2.5f && Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoD[i].transform.position) > 1.0f)
                          {
                              Debug.Log(Vector3.Distance(PuntoAnterior.transform.position, Man.JuegoD[i].transform.position));
                              PuntosSeleccionados.Add(Man.JuegoD[i]);

                          }
                      }

                      for (int i = 0; i < PuntosRepetidos.Count; i++)
                      {
                          if (PuntosSeleccionados.Contains(PuntosRepetidos[i]))
                          {
                              PuntosSeleccionados.Remove(PuntosRepetidos[i]);
                          }
                      }
                      if (PuntosSeleccionados.Count == 0)
                      {
                        Man.NumPuntos = PuntosRepetidos.Count;
                      }
                    else
                    {
                        PuntoSeleccionado = PuntosSeleccionados[Random.Range(0, PuntosSeleccionados.Count - 1)];
                        PuntosRepetidos.Add(PuntoSeleccionado);
                        PuntoAnterior = PuntoSeleccionado;
                    }

                }




                  lr.positionCount += 1;
                  lr.SetPosition(num, PuntoSeleccionado.transform.position);
                  PuntosSeleccionados.Clear();
                  PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.blue;

                  yield return new WaitForSeconds(2f);

                  PuntoSeleccionado.GetComponent<Renderer>().material.color = Color.green;

              }
              rend.material = Transparente;
              NoPrint.SetActive(false);
            //LogoTiempo.SetActive(true);
            IATexto.SetActive(false);
            DibujarTexto.SetActive(true);
            DibujoObjeto.SetActive(true);
            start_time = true;

            TiempoArab = 180f;
            TiempoTotal = 180;

            timer = true;

            

            if (TiempoArab < 5)
            {
                Tempo.color = Color.red;
            }


            if (TiempoArab <= 0)
            {
                TiempoArab = 0;
                Debug.Log("FIN DE LA PARTIDA");
                SceneManager.LoadScene("Feedback_Escena");
            }
        }
        
    }
    public void Fin()
    { 
        if (win)
        {
            feedbackmanager.win = true;
        }
        else if (lose)
        {
            feedbackmanager.lose = true;

        }

        float puntosTiempo = (TiempoArab / TiempoTotal);

        feedbackmanager.tiempo = puntosTiempo;

        SceneManager.LoadScene("Feedback_Escena");

    }


}
