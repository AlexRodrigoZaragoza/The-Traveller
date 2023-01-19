using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class numeros : MonoBehaviour
{
    public static int dificultad; //ESTO IRÁ DENTRO DE BOTON YA QUE SELECCIONA LA DIFICULTAD. 9=EASY 30= MEDIO por lo que cuando se implemente cambiar a static
    public List<int> numeros_random = new List<int>();
    public List<int> numeros_elegidos = new List<int>();
    public List<Text> numeros_pantalla = new List<Text>();
    Color moneditas = new Vector4(0, 0, 0, 0.3f);
    public List<Text> facil_pantalla = new List<Text>();
    public List<Text> hard_pantalla = new List<Text>();
    public List<GameObject> facil_value = new List<GameObject>();
    public List<GameObject> hard_value = new List<GameObject>();
    public List<GameObject> add_value = new List<GameObject>();
    public static int elegido;
    public Text elegir;
    public GameObject dif_facil, dif_medio, dif_dificil;
    public Text aciertos;
    public Text mostrar_elegir;
    public Text tiempos;
    float Total_time; //tiempo no reset
    public static float guardar_tiempo;
    public static bool siguiente = false;
    public static bool time_on;
    public static int acertar;
    public static int numero_aciertos;
    bool cerrar = false;
    public GameObject pause;
    public GameObject final;
    public GameObject todo;
    public Text puntuacion;
    public Animator anim;
    bool pausarse;
    public GameObject ajuste;
    public GameObject empezar_button;
    public AudioSource perder, acertars,ganar;
    public static bool parateh;
    public GameObject marco;
    bool rata;
    bool terminare;
    void Start()
    {
        feedbackmanager.juego_feedback = "numeros";

        if (valores.acertare == true)
        {
            valores.acertare = false;
            acertars.Play();
        }
        if (valores.perdere == true)
        {
            valores.perdere = false;
            perder.Play();
        }
        elegir.text = "";
        mostrar_elegir.text = "";
        
        Time.timeScale = 1;
        aciertos.text = "" + numero_aciertos;
        acertar = 0;

        if (siguiente == true)
        {
            marco.SetActive(true);
            Total_time = guardar_tiempo;

        }
        if (siguiente == false)
        {
            Total_time = 120;
        }
        tiempos.text = "" + Mathf.Round(Total_time) + "  s";


        for (int i = 0; i <= 99; i++)
        {
            numeros_random.Add(i);
        }
        if (time_on == true)
        {
            empezar_button.SetActive(false);
            StartCoroutine("mostrar");
        }
      //  StartCoroutine("mostrar");
    }
    IEnumerator mostrar()
    {
        for (int i = 0; i < dificultad; i++)
        {
            int aleatorio = Random.Range(0, numeros_random.Count - 1);

            numeros_elegidos.Add(numeros_random[aleatorio]);
            numeros_random.RemoveAt(aleatorio);

            switch (dificultad)
            {
                case 99:
                    hard_pantalla[i].text = "" + numeros_elegidos[i];
                    hard_pantalla[i].color = moneditas;

                    hard_value[i].GetComponent<valores>().valor = numeros_elegidos[i];

                    float stature = Random.Range(0.9f, 1.4f);
                    hard_value[i].transform.localScale = new Vector3(stature, stature, stature);

                    hard_value[i].transform.localPosition = new Vector3(hard_value[i].transform.localPosition.x + Random.Range(-50, 20), hard_value[i].transform.localPosition.y + Random.Range(-10, 10), 0);


                    break;

                case 9:
                    facil_pantalla[i].text = "" + numeros_elegidos[i];
                    facil_pantalla[i].color = moneditas;
                    facil_value[i].GetComponent<valores>().valor = numeros_elegidos[i];

                    facil_value[i].transform.localPosition = new Vector3(facil_value[i].transform.localPosition.x + Random.Range(-100, 100), facil_value[i].transform.localPosition.y + Random.Range(-50, 50), 0);

                    break;
                case 30:
                    numeros_pantalla[i].text = "" + numeros_elegidos[i];
                    numeros_pantalla[i].color = moneditas;

                    add_value[i].GetComponent<valores>().valor = numeros_elegidos[i];

                    stature = Random.Range(0.8f, 1.4f);
                    add_value[i].transform.localScale = new Vector3(stature, stature, stature);
                    add_value[i].transform.localPosition = new Vector3(add_value[i].transform.localPosition.x + Random.Range(-70, 70), add_value[i].transform.localPosition.y + Random.Range(-25, 25), 0);
                    break;



            }


            if (dificultad > 10)
            {

            }



        }
        int otro_random = Random.Range(0, dificultad - 1);
        elegido = numeros_elegidos[otro_random];
        elegir.text = "Encuentra el " + elegido;
        mostrar_elegir.text = "Encuentra el " + elegido;

        yield return new WaitForSeconds(2);
        time_on = true;
        switch (dificultad)
        {

            case 9:
                dif_facil.SetActive(true);
                elegir.text = "";
                break;

            case 30:
                dif_medio.SetActive(true);
                elegir.text = "";
                break;

            case 99:
                dif_dificil.SetActive(true);
                elegir.text = "";
                break;
        }
        
        pausarse = true;

    }
    public void resumir()
    {

        ajuste.SetActive(false);
        StartCoroutine(resumirse());
    }
    public void empezar()
    {
        marco.SetActive(true);
        mostrar_elegir.text = "Encuentra el " + elegido;
        empezar_button.SetActive(false);
        StartCoroutine("mostrar");
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape) && time_on == true && pausarse == true && Settings.isOn == false)
        {

            if (cerrar == false)
            {
                switch (dificultad)
                {

                    case 9:
                        dif_facil.SetActive(false);
                        break;

                    case 30:
                        dif_medio.SetActive(false);
                        break;

                    case 99:
                        dif_dificil.SetActive(false);
                        break;
                }
                Time.timeScale = 0;
                pause.SetActive(true);
                anim.Play("Anim_PauseOn");
                cerrar = true;
            }
            else
            {
                ajuste.SetActive(false);
                StartCoroutine(resumirse());
            }



        }

        if (time_on == true && acertar != 1 && Total_time > 0)
        {
            Total_time -= Time.deltaTime;
            tiempos.text = "" + Mathf.Round(Total_time) + "  s";
            if (Total_time <= 0)
            {
                BD_NumerosRandom.puntos_numeros_random = " " + numero_aciertos;
                siguiente = false;
                Terminar();
            }
        }
        if (acertar == 1)
        {
            siguiente = true;
            guardar_tiempo = Total_time;
            //falta definir cuantas veces se repite
            SceneManager.LoadScene("numeros");
            //Terminar();
        }

    }
    IEnumerator resumirse()
    {
        anim.Play("Anim_PauseOff");
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        pause.SetActive(false);
        switch (dificultad)
        {

            case 9:
                dif_facil.SetActive(true);
                break;

            case 30:
                dif_medio.SetActive(true);
                break;

            case 99:
                dif_dificil.SetActive(true);
                break;
        }
        cerrar = false;
    }
    public void Replay()
    {

        Time.timeScale = 1;
        siguiente = false;
        numero_aciertos = 0;
        musica_numeros.romper_numeros = false;
        time_on = false;
        SceneManager.LoadScene("LevelDif");

    }

    public void Salir()
    {

        Time.timeScale = 1;
        siguiente = false;
        numero_aciertos = 0;
        musica_numeros.romper_numeros = false;
        time_on = false;




        switch (dificultad)
        {
            case 9:

                feedbackmanager.tiempo = numero_aciertos / 20;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
            case 30:
                feedbackmanager.tiempo = numero_aciertos / 10;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
            case 99:
                feedbackmanager.tiempo = numero_aciertos / 5;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
        }

        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");
    }

    public void Terminar()
    {
       
        puntuacion.text = "Has conseguido: " + numero_aciertos + " puntos";

        time_on = false;
       

        
        StartCoroutine(DELAY());
    }
    IEnumerator DELAY()
    {
        switch (dificultad)
        {
            case 9:
                
                feedbackmanager.tiempo = numero_aciertos / 20;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
            case 30:
                feedbackmanager.tiempo = numero_aciertos / 10;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
            case 99:
                feedbackmanager.tiempo = numero_aciertos / 5;
                if (feedbackmanager.tiempo >= 1)
                {
                    feedbackmanager.tiempo = 1;
                }
                break;
        }
        if (numero_aciertos >= 1)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }
        parateh = true;
        yield return new WaitForSeconds(1);
        musica_numeros.romper_numeros = false;
        numero_aciertos = 0;
        parateh = false;
        SceneManager.LoadScene("Feedback_Escena");
    }

    
}
