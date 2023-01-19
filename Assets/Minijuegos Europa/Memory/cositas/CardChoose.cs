using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class CardChoose : MonoBehaviour
{
    public GameObject DataBase_Memory;
    public Animator anim;

    List<GameObject> cartas = new List<GameObject>();  //Cartas que hay en escena
    List<int> parejas = new List<int>(); // para hacer las parejas

    [Header("Listas que se envían a las cartas")]
    public List<int> cartas_giradas = new List<int>(); // para comprobar las imagenes de las 2 cartas giradas (public)
    public List<Sprite> images = new List<Sprite>(); //para almacenar todos los sprites de las cartas. 0 sería la cara de atrás de la carta, a partir del 1 son las caras de delante (public)

    int Randomizar; // distribuir las imagenes
    int valor = 1; // para que salgan 2 de cada 

    //public bool canPress = true; // para denegar el poder pulsar las cartas (public)

    public float aciertos = 0; // Parejas conseguidas (GUARDAR PARA BASE DE DATOS)

    public enum difficulty { none, easy, medium, hard };
    public static difficulty myDiff;  //(GUARDAR PARA BASE DE DATOS)

    int fallos; // para la dificil (limite de errores)

    [Tooltip("Texto del tiempo pequeño")]
    [SerializeField] Text t_tiempo;

    [Tooltip("Texto donde se va sumando el score de las cartas")]
    [SerializeField] Text t_bigTiempo;

    [Tooltip("Texto de los puntos que suman dependiendo del tiempo")]
    [SerializeField] Text t_TiempoSobra;

    [Tooltip("Tiempo que le ha sobrado al paciente")]
    public float TiempoSobra = 0; //(GUARDAR PARA BASE DE DATOS)
   
    float Tiempo = 120; //Tiempo límite
    float TiempoTotal = 0;

    bool iniciar; // inicia el juego

    [Tooltip("Puntuación total")]
    public float puntuacion;
    float limiteParejas;

    [Tooltip("Puntuación total (feedback ingame)")]
    [SerializeField] Text puntuacionInGame;

    [Header("GameObjects de las pantallas del juego")]

    [Tooltip("GameObject Inicio")]
    [SerializeField] GameObject inicio;

    [Tooltip("GameObject Fácil")]
    [SerializeField] GameObject facil;

    [Tooltip("GameObject Medio")]
    [SerializeField] GameObject medio;

    [Tooltip("GameObject Dificil")]
    [SerializeField] GameObject dificil;

    [Tooltip("GameObject Final")]
    [SerializeField] GameObject score;

    [Tooltip("GameObject Pausa")]
    [SerializeField] GameObject pause;

    [Tooltip("GameObject Se quedó sin tiempo")]
    [SerializeField] GameObject timeOut;
    [Space]

    public Text t_puntuacion;
    public Text t_fallos;

    bool bien = false;
    bool mal = false;
    bool rendirse = false;

    bool pausado; //Para saber cuando está en pausa

    Color tiempoColor = Color.black; //Color original del texto

    float tiempoAnim; //Tiempo que tarda en hacer la animación

    [Tooltip("Texto final que recopila todas las cartas que has acertado")]
    [SerializeField] Text cartasTotales;

    [SerializeField] GameObject SFX;
    [SerializeField] AudioSource Click; 

    void Start()
    {
        feedbackmanager.juego_feedback = "memory";
        tiempoColor = Color.black;
        iniciar = false;
        pausado = false;
        bien = false;
        mal = false;

        fallos = 25;
        aciertos = 0;
        cartasTotales.text = "";
    }
    public void IniciarJuego()
    {
        Card.canPress = false;

        iniciar = true;
        inicio.SetActive(false);

        if (myDiff == difficulty.easy)
        {
            Tiempo = 80;
            TiempoTotal = 80;
            facil.SetActive(true);
        }
        else if (myDiff == difficulty.medium)
        {
            Tiempo = 120;
            TiempoTotal = 120;
            medio.SetActive(true);
        }
        else if (myDiff == difficulty.hard)
        {
            Tiempo = 180;
            TiempoTotal = 180;
            dificil.SetActive(true);
        }
        
        //

        AddCards(); // añade cartas a la lista
        Randomize(); // y las pone en posiciones random

        t_tiempo.text = "" + Tiempo + "  s";
        // comprueba dificultad para hacer una animación distinta
        if (myDiff == difficulty.easy)
        {
            tiempoAnim = 2f;
            limiteParejas = 4;
            StartCoroutine("ShowResults");
        }
        if (myDiff == difficulty.medium)
        {
            tiempoAnim = 2f;
            limiteParejas = 8;
            StartCoroutine("Animacion");
        }
        if (myDiff == difficulty.hard)
        {
            tiempoAnim = 3f;
            limiteParejas = 15;
            t_fallos.text = "" + fallos;
            StartCoroutine("Animacion");
        }

        puntuacionInGame.text = "0  /  " + limiteParejas;

    }
    void AddCards()
    {
        cartas = new List<GameObject>(GameObject.FindGameObjectsWithTag("cards"));

        for (int i = 0; i < cartas.Count; i++)
        {
            parejas.Add(valor);
            if ((parejas.Count % 2) == 0)
            {
                valor++;
                parejas[i] = parejas[i - 1];
            }
        }
    }

    void Randomize()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            Randomizar = Random.Range(0, parejas.Count);
            cartas[i].GetComponent<Card>().cardpair = parejas[Randomizar];

            parejas.RemoveAt(Randomizar);
        }
    }
    IEnumerator ShowResults()  //para la dificultad más fácil
    {
        iniciar = false;
        t_tiempo.color = Color.grey;
        yield return new WaitForSeconds(tiempoAnim);

        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Card>().StartCoroutine("GirarCarta");
            cartas[i].GetComponent<Card>().activo = true;
        }

        //hacer que no sean clickables
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Card>().StartCoroutine("NoGirarCarta");
        }
        t_tiempo.color = tiempoColor;
        Card.canPress = true;
        iniciar = true;
    }
    IEnumerator Animacion()
    {
        iniciar = false;

        yield return new WaitForSeconds(tiempoAnim);

        t_tiempo.color = tiempoColor;
        iniciar = true;
        Card.canPress = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false) // menú pausa
        {
            if (pausado)
            {
                resume();
            }
            else
            {
                Time.timeScale = 0;
                t_tiempo.color = Color.grey;
                pause.SetActive(true);
                pausado = true;
                anim.Play("Anim_PauseOn"); //Animación de poner Pausa
            }

        }
        if (iniciar) // se activa cuando termina la animación de las cartas
        {
            t_tiempo.text = "" + Mathf.Round(Tiempo) + "  s";
            if ((bien == false) && (mal == false))
            {
                Tiempo -= Time.deltaTime;
            }
            if (fallos <= 0)
            {
                if (bien == false)
                {
                    mal = true;
                    StartCoroutine(Fin());
                }
            }
            if (Tiempo <= 0)
            {
                if (bien == false)
                {
                    mal = true;
                    StartCoroutine(Fin());
                }
            }

            if (cartas.Count <= 0)
            {
                if (mal == false)
                {
                    bien = true;
                    StartCoroutine(Fin());
                }
            }
        }
    }

    public IEnumerator Comprobar() // lo llaman las cartas, por lo que tiene que ser publico
    {
        Card.canPress = false;
        yield return new WaitForSeconds(1f);

        if (cartas_giradas[0] == cartas_giradas[1])
        {
            Acertado();
        }
        else
        {
            Fallado(myDiff);
        }
    }
    void Acertado()
    {
        SFX.GetComponent<MakeSound>().GoodHit();
        //Sonido de acertado
        GameObject A = null, B = null;
        int counter = 0;

        while (A == null || B == null) 
        {
            if (cartas[counter].GetComponent<Card>().cardpair == cartas_giradas[1])
            {
                if (A == null)
                {
                    A = cartas[counter];
                } 
                else
                {
                    B = cartas[counter];
                }
            }
            counter++;
        }
        
        A.SetActive(false);
        B.SetActive(false);
        cartas.Remove(A);
        cartas.Remove(B);
        aciertos = aciertos + 25;

        puntuacionInGame.text = aciertos / 25 + "  /  " + limiteParejas;
        //yield return new WaitForSeconds(0.1f);
        cartas_giradas.Clear();
        Card.canPress = true;
    }

    void Fallado(difficulty diff)
    {
        SFX.GetComponent<MakeSound>().BadHit();
        //Sonindo de fallado
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Card>().StartCoroutine("NoGirarCarta");
        }

        //aplicado a la dificultad dificil
        if (diff == difficulty.hard)
        {
            fallos--;
            t_fallos.text = "" + fallos;
        }

        //yield return new WaitForSeconds(0.1f);
        cartas_giradas.Clear();
        Card.canPress = true;
    }

    public void HacerClick()
    {
        Click.Play();
    }
    IEnumerator Fin()
    {

        //pasar bien + tiempo o mal (fallado)
        if (bien)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else if (mal)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }

        feedbackmanager.tiempo = Tiempo / TiempoTotal;

        if (rendirse)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Feedback_Escena");
        }

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Feedback_Escena");
    }

    public void Replay()
    {
        mal = true;
        rendirse = true;
        StartCoroutine(Fin());
    }


    //PARA DAR TIEMPO A LA ANIMACIÓN DE SALIR DE PAUSA
    public void resume()
    {
        StartCoroutine(resume_Anim()); //necesita corrutina para darle tiempo a la animación
    }

    public IEnumerator resume_Anim()
    {
        anim.Play("Anim_PauseOff"); //Animación de quitar Pausa
        yield return new WaitForSecondsRealtime(1f); //Tiempo de animación ¡¡¡¡¡WaitForSecondsREALTIME!!!!!
        Time.timeScale = 1;  //Volver a que el tiempo funcione

        //Cosas adicionales de mi minijuego
        t_tiempo.color = tiempoColor;
        pausado = false;
        pause.SetActive(false);
    }
}
