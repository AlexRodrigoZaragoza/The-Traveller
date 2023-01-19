using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject Database_Puzzle;
    public int numImagesOnScene;
    public GameObject[] PuzzleImages_OnScene;
    //List<GameObject> PuzzleImages_OnScene = new List<GameObject>();
    public int randomImage;
    public List<Sprite> PuzzleImages = new List<Sprite>();
    public int puntos;
    public Text texto;
    public Text time;
    public Text finalTime;
    public float RealTime;
    float TotalTime;
    public static int dificultad_puzzle;
    public GameObject facil, medio, dificil, final, pause, inicio;
    //public GameObject facilF, medioF, dificilF;
    public GameObject chosenImage;
    public GameObject EasyBG;
    public GameObject esconder;
    bool parah=false;
    bool cerrar=false;
    public Animator anim;
    bool empieza;


    bool ganar = false; bool perder = false;
    // Start is called before the first frame update
    void Start()
    {
        feedbackmanager.juego_feedback = "puzzle";
    }

    public void StartGame()
    {

        StartCoroutine("aguacateeee");
    }

    IEnumerator aguacateeee()
    {
        inicio.SetActive(false);
        facil.SetActive(false);
        medio.SetActive(false);
        dificil.SetActive(false);
        final.SetActive(false);

        randomImage = Random.Range(0, PuzzleImages.Count);
        chosenImage.SetActive(true);
        chosenImage.transform.GetChild(0).GetComponent<Image>().sprite = PuzzleImages[randomImage];
       
        
        switch (dificultad_puzzle)
        {

            case 1:
                TotalTime = 60;
                RealTime = 60;


                break;

            case 2:
                TotalTime = 180;
                RealTime = 180;

                break;


            case 3:
                TotalTime = 240;
                RealTime = 240;

                break;
        }
        time.text = "" + Mathf.Round(RealTime) + "  s";


        yield return new WaitForSeconds(4);
        parah = true;
        chosenImage.SetActive(false);
        switch (dificultad_puzzle)
        {

            case 1:
                //facilF.SetActive(false);
                empieza = true;
                facil.SetActive(true);
                medio.SetActive(false);
                dificil.SetActive(false);

                numImagesOnScene = 4;
                break;

            case 2:
                //medioF.SetActive(false);
                empieza = true;

                facil.SetActive(false);
                medio.SetActive(true);
                dificil.SetActive(false);

                numImagesOnScene = 9;
                break;


            case 3:
                //dificilF.SetActive(false);
                RealTime = 180;
                empieza = true;

                facil.SetActive(false);
                medio.SetActive(false);
                dificil.SetActive(true);

                numImagesOnScene = 36;
                break;
        }

        PuzzleImages_OnScene = (GameObject.FindGameObjectsWithTag("PuzzleIMG"));
       
        EasyBG.GetComponent<SpriteRenderer>().sprite = PuzzleImages[randomImage];

        for (int i = 0; i<numImagesOnScene; i++)
        {
            PuzzleImages_OnScene[i].GetComponent<SpriteRenderer>().sprite = PuzzleImages[randomImage];
        }
        //GameObject.Find("Puzzle_IMG").GetComponent<SpriteRenderer>().sprite = PuzzleImages[Random.Range(0, PuzzleImages.Count - 1)];
    }

    public void Replay()
    {
        Time.timeScale = 1;

        feedbackmanager.tiempo = RealTime / TotalTime;
        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");
    }
    public void resume()
    {
        StartCoroutine("resume_Anim");
    }

    public IEnumerator resume_Anim()
    {
        anim.Play("Anim_PauseOff"); //Animación de quitar Pausa
        yield return new WaitForSecondsRealtime(1f); //Tiempo de animación ¡¡¡¡¡WaitForSecondsREALTIME!!!!!

        switch (dificultad_puzzle)
        {

            case 1:

                facil.SetActive(true);
                medio.SetActive(false);
                dificil.SetActive(false);

                break;

            case 2:
                facil.SetActive(false);
                medio.SetActive(true);
                dificil.SetActive(false);

                break;


            case 3:
                facil.SetActive(false);
                medio.SetActive(false);
                dificil.SetActive(true);

                break;
        }

        cerrar = false;

        Time.timeScale = 1;
        pause.SetActive(false);
    }
    IEnumerator delayEnd()
    {
        if (ganar)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else if (perder)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }
        feedbackmanager.tiempo = RealTime / TotalTime;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Feedback_Escena");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&parah==true && Settings.isOn == false)
        {

            if (cerrar == false)
            {


                switch (dificultad_puzzle)
                {
                    case 1:
                       
                        facil.SetActive(false);
                        break;

                    case 2:
                        medio.SetActive(false);
                        break;

                    case 3:
                        dificil.SetActive(false);

                        break;
                }

                Time.timeScale = 0;
                pause.SetActive(true);
                anim.Play("Anim_PauseOn");
                cerrar = true;
            }
            else
            {
                switch (dificultad_puzzle)
                {

                    case 1:

                        facil.SetActive(true);
                        medio.SetActive(false);
                        dificil.SetActive(false);

                        break;

                    case 2:
                        facil.SetActive(false);
                        medio.SetActive(true);
                        dificil.SetActive(false);

                        break;


                    case 3:
                        facil.SetActive(false);
                        medio.SetActive(false);
                        dificil.SetActive(true);

                        break;
                }




                Time.timeScale = 1;
                cerrar = false;
                //startcoroutine
                anim.Play("Anim_PauseOff");
                pause.SetActive(false);
            }



        }


        switch (dificultad_puzzle)
        {

            case 1:
                if (puntos != 4 && parah==true)
                {
                    if(RealTime >= 0)
                    {
                        RealTime -= Time.deltaTime;
                    }
                    
                    time.text = "" + Mathf.Round(RealTime) + "  s";
                }
                else if (parah ==true)
                {
                    Database_Puzzle.GetComponent<BD_Puzzle>().Tiempo_Puzzle = RealTime.ToString();
                    ganar = true;
                    StartCoroutine("delayEnd");
                }

                break;

            case 2:
                if (puntos != 9 && parah == true)
                {

                    if (RealTime >= 0)
                    {
                        RealTime -= Time.deltaTime;
                    }
                    time.text = "" + Mathf.Round(RealTime) + "  s";
                }
                else if (parah == true)
                {
                    Database_Puzzle.GetComponent<BD_Puzzle>().Tiempo_Puzzle = RealTime.ToString();
                    ganar = true;
                    StartCoroutine("delayEnd");
                }

                break;


            case 3:
                if (puntos != 36 && parah == true)
                {

                    if (RealTime >= 0)
                    {
                        RealTime -= Time.deltaTime;
                    }
                    time.text = "" + Mathf.Round(RealTime) + "  s";
                }
                else if (parah == true)
                {
                    Database_Puzzle.GetComponent<BD_Puzzle>().Tiempo_Puzzle = RealTime.ToString();
                    ganar = true;
                    StartCoroutine("delayEnd");
                }

                break;
        }
        if (RealTime <= 0&&empieza==true)
        {
            perder = true;
            StartCoroutine("delayEnd");

        }
    }
}
