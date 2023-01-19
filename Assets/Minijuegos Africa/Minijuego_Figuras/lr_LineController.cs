using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lr_LineController : MonoBehaviour
{
    public Renderer Rend;
    private LineRenderer lr;
    public lr_Selector_Dificultad Man;
    public lr_Trazado traz_facil;
    public lr_Trazado traz_medio;
    public lr_Trazado traz_dificil;
    string conversion;
    public static List<int> NumRepetidos = new List<int>();
    public static List<Vector3> IA = new List<Vector3>();
    public static List<Vector3> Anteriores = new List<Vector3>();
    public Vector3[,] matrix;
    public GameObject EscenaInicio;

    public GameObject TuTurno;
    public GameObject _Corregir;
    public Text TiempoTuTurno;
    public Text Recordatorio;
    public Text Lineas;
    public Animator anim;
    public GameObject reco;

    public GameObject Linerenderer2;
    public GameObject Marco;
    public GameObject CajaDePolla;

    public GameObject FacilUsuario;
    public GameObject MedioUsuario;
    public GameObject DificilUsuario;

    public GameObject FacilIA;
    public GameObject MedioIA;
    public GameObject DificilIA;

    public GameObject Linea;

    public float TiempoMyD = 40;
    public float TiempoF = 30;
    public static float crono;
    public static float tiempo;

    public Text TuT;
    public Text Fin;

    public bool fin;
    public bool dibujando;
    public bool start_time;
    public bool cerrar;

    public bool vuelta;
    public static int comprobar_;
    public static int comprobar2_;
    public int num_comprobar = 0;
    public bool bien;
    public int NumRandom;
    public int vueltas_while;
    public bool saltar;
    public int num;
    public int vultas_max = 50;

    public int LineasP;
    public static int diff;

    public static bool running = false;
    public bool Started = false;

    public GameObject UsuarioFacil;
    public GameObject UsuarioMedio;
    public GameObject UsuarioDificil;
    public GameObject MenuPausa;
    public GameObject Correct, Incorrect, Punt;

    Audios Sonidos;


    bool inicio;
    private void Start()
    {
        reco.SetActive(false);
        #region TiempoDificultad
        if (lr_Selector_Dificultad.Dificultad == 1)
        {
            TiempoTuTurno.text = "Tiempo: 30 s";
            crono = 30;
        }

        else if (lr_Selector_Dificultad.Dificultad == 2)
        {
            TiempoTuTurno.text = "Tiempo: 40 s";
            crono = 40;
        }

        else if (lr_Selector_Dificultad.Dificultad == 3)
        {
            TiempoTuTurno.text = "Tiempo: 40 s";
            crono = 40;
        }
        #endregion

        lr = GetComponent<LineRenderer>();
        inicio = true;
        lr.positionCount = 0;
        //StartCoroutine(Recuerda());
        NumRepetidos.Clear();
        IA.Clear();
        Anteriores.Clear();
        Time.timeScale = 1;
        lr.positionCount = 0;
        tiempo = 0;
        vueltas_while = 0;
        saltar = false;
        NumRandom = 0;
        bien = false;
        vuelta = false;
        num = 0;
        num_comprobar = 0;
        TuTurno.SetActive(false);
        _Corregir.SetActive(false);
        Correct.SetActive(false);
        Incorrect.SetActive(false);
        Punt.SetActive(false);
        feedbackmanager.juego_feedback = "copia";
        Sonidos = FindObjectOfType<Audios>();
        lr_Trazado.win = false;
        lr_Trazado.lose = false;
        CajaDePolla.SetActive(false);
    }

    private void Update()
    {


        if (running == true)
        {
            tiempo += 1 * Time.deltaTime;
            crono -= 1 * Time.deltaTime;
            int tiem = (int)crono;
            TiempoTuTurno.text ="Tiempo: "+ tiem + " s";
        }


        if (crono < 10 && fin == true)
        {
            TiempoTuTurno.color = Color.red;

        }

        if (crono <= 0)
        {
            crono = 0;
        }

        if (crono <= 0 && fin == true)
        {
            crono = 0;
            lr_Trazado.RealTime = crono;
            lr_Trazado.victoria = 2;
            lr_Trazado.Puntos.Clear();
            lr_Trazado.win = false;
            lr_Trazado.lose = true;
            running = false;

            if (lr_Selector_Dificultad.Dificultad == 1)
            {
                StartCoroutine(traz_facil.delayEnd());
            }

            else if (lr_Selector_Dificultad.Dificultad == 2)
            {
                StartCoroutine(traz_medio.delayEnd());
            }

            else if (lr_Selector_Dificultad.Dificultad == 3)
            {
                StartCoroutine(traz_dificil.delayEnd());
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && start_time == true && Settings.isOn == false && Started == true)
        {

            if (cerrar == false)
            {
                Marco.SetActive(false);
                Linea.SetActive(false);
                Time.timeScale = 0;
                MenuPausa.SetActive(true);
                cerrar = true;
                anim.Play("Anim_PauseOn");
                lr.enabled = false;
                Linerenderer2.SetActive(false);
                CajaDePolla.SetActive(false);

                if (lr_Selector_Dificultad.Dificultad == 1)
                {
                    FacilIA.SetActive(false);
                    FacilUsuario.SetActive(false);
                }

                if (lr_Selector_Dificultad.Dificultad == 2)
                {
                    MedioIA.SetActive(false);
                    MedioUsuario.SetActive(false);
                }

                if (lr_Selector_Dificultad.Dificultad == 3)
                {
                    DificilIA.SetActive(false);
                    DificilUsuario.SetActive(false);
                }
            }
            else
            {
                StartCoroutine(PausaTerminada());
            }
        }
    }

    IEnumerator PausaTerminada()
    {
        anim.Play("Anim_PauseOff");

        yield return new WaitForSecondsRealtime(1f);
        Marco.SetActive(true);
        Linea.SetActive(true);
        Time.timeScale = 1;
        MenuPausa.SetActive(false);
        cerrar = false;
        CajaDePolla.SetActive(true);

        lr.enabled = true;
        Linerenderer2.SetActive(true);

        if (lr_Selector_Dificultad.Dificultad == 1)
        {
            FacilIA.SetActive(true);
            FacilUsuario.SetActive(true);
        }

        if (lr_Selector_Dificultad.Dificultad == 2)
        {
            MedioIA.SetActive(true);
            MedioUsuario.SetActive(true);
        }

        if (lr_Selector_Dificultad.Dificultad == 3)
        {
            DificilIA.SetActive(true);
            DificilUsuario.SetActive(true);
        }
    }
    public void volver()
    {
        StartCoroutine(PausaTerminada());
    }

    public void Vuelta()
    {
        Time.timeScale = 1;


        if(lr_Selector_Dificultad.Dificultad == 1)
        {
            feedbackmanager.tiempo = crono / 30;
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
            SceneManager.LoadScene("Feedback_Escena");
        }

        else if(lr_Selector_Dificultad.Dificultad == 2 || lr_Selector_Dificultad.Dificultad == 3)
        {
            feedbackmanager.tiempo = crono / 30;
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
            SceneManager.LoadScene("Feedback_Escena");
        }

    }


    IEnumerator Recuerda()
    {
        while (dibujando == false)
        {
            Recordatorio.color = Color.black;
            yield return new WaitForSeconds(1f);
            Recordatorio.color = Color.white;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator pasosF()
    {
        lr.SetWidth(0.15f, 0.15f);

        while (saltar == false && num < lr_Selector_Dificultad.NumPuntos)
        {
            for (num = 0; num < lr_Selector_Dificultad.NumPuntos; num++)
            {
                float magComprobar;

                if (vuelta == true)
                {
                    num_comprobar++;
                    Anteriores.Add(new Vector3(Man.JuegoF[NumRandom].transform.position.x, Man.JuegoF[NumRandom].transform.position.y, Man.JuegoF[NumRandom].transform.position.z));
                }

                while (bien == false && vuelta == true && saltar == false)
                {
                    if (vueltas_while > vultas_max)
                    {
                        saltar = true;

                        dibujando = true;
                        StartCoroutine(TuTurnomyd());
                        UsuarioFacil.SetActive(true);
                        UsuarioMedio.SetActive(false);
                        UsuarioDificil.SetActive(false);
                        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
                        dibujando = false;
                        comprobar_ = IA.Count - 1;
                        comprobar2_ = IA.Count - 1;
                        BD_CopiaYSimetria.datos();
                        //StartCoroutine(Recuerda());


                        break;
                        yield break;
                    }

                    NumRandom = Random.Range(0, 9);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 9);
                    }

                    Vector3 Comprobar = new Vector3(Man.JuegoF[NumRandom].transform.position.x, Man.JuegoF[NumRandom].transform.position.y, Man.JuegoF[NumRandom].transform.position.z) - new Vector3(Anteriores[num_comprobar].x, Anteriores[num_comprobar].y, Anteriores[num_comprobar].z);
                    magComprobar = Comprobar.sqrMagnitude;
                    Debug.Log("La magnitud es:" + magComprobar);

                    if (magComprobar < 7)
                    {
                        bien = true;
                    }
                    else
                        bien = false;

                    vueltas_while++;
                }

                if (vuelta == false)
                {
                    NumRandom = Random.Range(0, 9);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 9);
                    }

                    num_comprobar--;
                }

                if (saltar == false)
                {
                    lr.positionCount++;

                    NumRepetidos.Add(NumRandom);


                    lr.SetPosition(num, Man.JuegoF[NumRandom].localPosition);
                    Debug.Log("Dubujo");
                    gameObject.transform.localScale = new Vector3(-1f, 1, 1);

                    start_time = true;

                    IA.Add(new Vector3(Man.JuegoF[NumRandom].transform.position.x, Man.JuegoF[NumRandom].transform.position.y, Man.JuegoF[NumRandom].transform.position.z));


                    bien = false;
                    vueltas_while = 0;
                }

                yield return new WaitForSeconds(1f);
                vuelta = true;
            }
        }


        dibujando = true;
        StartCoroutine(TuTurnof());
        UsuarioFacil.SetActive(true);
        UsuarioMedio.SetActive(false);
        UsuarioDificil.SetActive(false);
        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
        dibujando = false;
        comprobar_ = IA.Count - 1;
        comprobar2_ = IA.Count - 1;
        BD_CopiaYSimetria.datos();
        //StartCoroutine(Recuerda());
    }

    IEnumerator pasosM()
    {
        lr.SetWidth(0.15f, 0.15f);

        while (saltar == false && num < lr_Selector_Dificultad.NumPuntos)
        {
            for (num = 0; num < lr_Selector_Dificultad.NumPuntos; num++)
            {

                float magComprobar;

                if (vuelta == true)
                {
                    num_comprobar++;
                    Anteriores.Add(new Vector3(Man.JuegoM[NumRandom].transform.position.x, Man.JuegoM[NumRandom].transform.position.y, Man.JuegoM[NumRandom].transform.position.z));
                }

                while (bien == false && vuelta == true && saltar == false)
                {
                    if (vueltas_while > vultas_max)
                    {
                        saltar = true;

                        dibujando = true;
                        StartCoroutine(TuTurnomyd());
                        UsuarioFacil.SetActive(false);
                        UsuarioMedio.SetActive(true);
                        UsuarioDificil.SetActive(false);
                        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
                        dibujando = false;
                        comprobar_ = IA.Count - 1;
                        comprobar2_ = IA.Count - 1;
                        BD_CopiaYSimetria.datos();
                        //StartCoroutine(Recuerda());

                        break;
                        yield break;
                    }

                    NumRandom = Random.Range(0, 16);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 16);
                    }

                    Vector3 Comprobar = new Vector3(Man.JuegoM[NumRandom].transform.position.x, Man.JuegoM[NumRandom].transform.position.y, Man.JuegoM[NumRandom].transform.position.z) - new Vector3(Anteriores[num_comprobar].x, Anteriores[num_comprobar].y, Anteriores[num_comprobar].z);
                    magComprobar = Comprobar.sqrMagnitude;
                    Debug.Log("La magnitud es:" + magComprobar);

                    if (magComprobar < 4)
                    {
                        bien = true;
                    }
                    else
                        bien = false;

                    vueltas_while++;
                }

                if (vuelta == false)
                {
                    NumRandom = Random.Range(0, 16);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 16);
                    }

                    num_comprobar--;
                }

                if (saltar == false)
                {
                    lr.positionCount++;

                    NumRepetidos.Add(NumRandom);


                    lr.SetPosition(num, Man.JuegoM[NumRandom].localPosition);
                    Debug.Log("Dubujo");
                    gameObject.transform.localScale = new Vector3(-1f, 1, 1);

                    start_time = true;

                    IA.Add(new Vector3(Man.JuegoM[NumRandom].transform.position.x, Man.JuegoM[NumRandom].transform.position.y, Man.JuegoM[NumRandom].transform.position.z));


                    bien = false;
                    vueltas_while = 0;
                }

                yield return new WaitForSeconds(2f);
                vuelta = true;
            }
        }


        dibujando = true;
        StartCoroutine(TuTurnomyd());
        UsuarioFacil.SetActive(false);
        UsuarioMedio.SetActive(true);
        UsuarioDificil.SetActive(false);
        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
        dibujando = false;
        comprobar_ = IA.Count - 1;
        comprobar2_ = IA.Count - 1;
        BD_CopiaYSimetria.datos();
        //StartCoroutine(Recuerda());
    }

    IEnumerator pasosD()
    {
        lr.SetWidth(0.15f, 0.15f);

        while (saltar == false && num < lr_Selector_Dificultad.NumPuntos)
        {
            for (num = 0; num < lr_Selector_Dificultad.NumPuntos; num++)
            {
                float magComprobar;

                if (vuelta == true)
                {
                    num_comprobar++;
                    Anteriores.Add(new Vector3(Man.JuegoD[NumRandom].transform.position.x, Man.JuegoD[NumRandom].transform.position.y, Man.JuegoD[NumRandom].transform.position.z));
                }

                while (bien == false && vuelta == true && saltar == false)
                {
                    if (vueltas_while > vultas_max)
                    {
                        saltar = true;

                        dibujando = true;
                        StartCoroutine(TuTurnomyd());
                        UsuarioFacil.SetActive(false);
                        UsuarioMedio.SetActive(false);
                        UsuarioDificil.SetActive(true);
                        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
                        dibujando = false;
                        comprobar_ = IA.Count - 1;
                        comprobar2_ = IA.Count - 1;
                        BD_CopiaYSimetria.datos();
                        //StartCoroutine(Recuerda());

                        break;
                        yield break;
                    }

                    NumRandom = Random.Range(0, 25);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 25);
                    }

                    Vector3 Comprobar = new Vector3(Man.JuegoD[NumRandom].transform.position.x, Man.JuegoD[NumRandom].transform.position.y, Man.JuegoD[NumRandom].transform.position.z) - new Vector3(Anteriores[num_comprobar].x, Anteriores[num_comprobar].y, Anteriores[num_comprobar].z);
                    magComprobar = Comprobar.sqrMagnitude;
                    Debug.Log("La magnitud es:" + magComprobar);

                    if (magComprobar < 4)
                    {
                        bien = true;
                    }
                    else
                        bien = false;

                    vueltas_while++;
                }

                if (vuelta == false)
                {
                    NumRandom = Random.Range(0, 25);

                    while (NumRepetidos.Contains(NumRandom))
                    {
                        NumRandom = Random.Range(0, 25);
                    }

                    num_comprobar--;
                }

                if (saltar == false)
                {
                    lr.positionCount++;

                    NumRepetidos.Add(NumRandom);


                    lr.SetPosition(num, Man.JuegoD[NumRandom].localPosition);
                    Debug.Log("Dubujo");
                    gameObject.transform.localScale = new Vector3(-1f, 1, 1);

                    start_time = true;

                    IA.Add(new Vector3(Man.JuegoD[NumRandom].transform.position.x, Man.JuegoD[NumRandom].transform.position.y, Man.JuegoD[NumRandom].transform.position.z));


                    bien = false;
                    vueltas_while = 0;
                }

                yield return new WaitForSeconds(2f);
                vuelta = true;
            }
        }


        dibujando = true;
        StartCoroutine(TuTurnomyd());
        UsuarioFacil.SetActive(false);
        UsuarioMedio.SetActive(false);
        UsuarioDificil.SetActive(true);
        Recordatorio.text = "ES TU TURNO DE DIBUJAR, RECUERDA DEBES REALIZAR LA FIGURA EN ESPEJO";
        dibujando = false;
        comprobar_ = IA.Count - 1;
        comprobar2_ = IA.Count - 1;
        BD_CopiaYSimetria.datos();
        //StartCoroutine(Recuerda());
    }

    IEnumerator TuTurnof()
    {
        running = true;
        yield return new WaitForSeconds(5f);


        TuT.color = Color.white;
        fin = true;

    }

    IEnumerator TuTurnomyd()
    {
        running = true;
        yield return new WaitForSeconds(5f);



        TuT.color = Color.white;
        fin = true;

    }

    public void Boton()
    {

        if (inicio == true && lr_Selector_Dificultad.Dificultad == 1)
        {
            Lineas.text = "Puntos a dibujar: " + lr_Selector_Dificultad.NumPuntos + ".";

            StartCoroutine(pasosF());

            crono = TiempoF;

            Recordatorio.text = "SE ESTA DIBUJANDO LA FIGURA PRESTA ATENCION Y SIGUE LOS PUNTOS";

            inicio = false;

            _Corregir.SetActive(true);

            diff = 1;

            EscenaInicio.SetActive(false);
            reco.SetActive(true);
            Man.IAFacil.SetActive(true);
            Man.IAMedio.SetActive(false);
            Man.IADificil.SetActive(false);
            Man.UsuarioFacil.SetActive(true);
            Man.UsuarioMedio.SetActive(false);
            Man.UsuarioDificil.SetActive(false);
            CajaDePolla.SetActive(true);
        }

        else if (inicio == true && lr_Selector_Dificultad.Dificultad == 2)
        {

            Lineas.text = "Puntos a dibujar: " + lr_Selector_Dificultad.NumPuntos + ".";

            StartCoroutine(pasosM());

            crono = TiempoMyD;

            Recordatorio.text = "SE ESTA DIBUJANDO LA FIGURA PRESTA ATENCION Y SIGUE LOS PUNTOS";

            inicio = false;

            _Corregir.SetActive(true);

            diff = 2;

            reco.SetActive(true);
            EscenaInicio.SetActive(false);
            Man.IAFacil.SetActive(false);
            Man.IAMedio.SetActive(true);
            Man.IADificil.SetActive(false);
            Man.UsuarioFacil.SetActive(false);
            Man.UsuarioMedio.SetActive(true);
            Man.UsuarioDificil.SetActive(false);
            CajaDePolla.SetActive(true);
        }

        else if (inicio == true && lr_Selector_Dificultad.Dificultad == 3)
        {

            Lineas.text = "Puntos a dibujar: " + lr_Selector_Dificultad.NumPuntos + ".";

            StartCoroutine(pasosD());

            crono = TiempoMyD;

            Recordatorio.text = "SE ESTA DIBUJANDO LA FIGURA PRESTA ATENCION Y SIGUE LOS PUNTOS";

            inicio = false;

            _Corregir.SetActive(false);

            diff = 3;

            EscenaInicio.SetActive(false);

            Man.IAFacil.SetActive(false);
            Man.IAMedio.SetActive(false);
            Man.IADificil.SetActive(true);
            Man.UsuarioFacil.SetActive(false);
            Man.UsuarioMedio.SetActive(false);
            Man.UsuarioDificil.SetActive(true);
            CajaDePolla.SetActive(true);
        }

        reco.SetActive(true);
        TuTurno.SetActive(true);
        _Corregir.SetActive(true);
        Correct.SetActive(true);
        Incorrect.SetActive(true);
        Punt.SetActive(true);
        Linea.SetActive(true);
        Started = true;
    }
    public void Difs()
    {
        if (inicio == true && lr_Selector_Dificultad.Dificultad == 1)
        {
            EscenaInicio.SetActive(true);
        }

        else if (inicio == true && lr_Selector_Dificultad.Dificultad == 2)
        {
            EscenaInicio.SetActive(true);
        }

        else if (inicio == true && lr_Selector_Dificultad.Dificultad == 3)
        {
            EscenaInicio.SetActive(true);
        }

        else
            Debug.Log("Default");
    }
}
