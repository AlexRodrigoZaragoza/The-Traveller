using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DistributeCards : MonoBehaviour
{
    //Dificultades
    [Header("DIFICULTAD entre 0 y 2")]
    public static int Diff = 2;  //BASE DE DATOS TRAE DIFICULTAD 0,1,2

    [Space(100)]

    //Carta de ejemplo
    public static GameObject ExampleCard;
    //Cartas en la escena
    List<GameObject> CardsInScene = new List<GameObject>();

    public List<GameObject> EasyCardsInScene = new List<GameObject>();
    public List<GameObject> MediumCardsInScene = new List<GameObject>();
    public List<GameObject> HardCardsInScene = new List<GameObject>();

    //Imagenes del fondo
    public List<Sprite> CardsBackGround = new List<Sprite>();

    //Imagenes de las figuras (separando si es 1, 2 o 3)
    public List<Sprite> Cards1Figure = new List<Sprite>();
    public List<Sprite> Cards2Figures = new List<Sprite>();
    public List<Sprite> Cards3Figures = new List<Sprite>();

    public List<Sprite> ExampleCards = new List<Sprite>();


    //Valores para randomizar

    Sprite FinalSprite;
    Sprite sec_FinalSprite;

    int RandomizeBackground;
    int RandomizeNumFigures;
    int RandomizeFigure;

    int randomNumber = 0;
    List<string> RandomizedFigures = new List<string>();  //Lista GENERAL combinaciones de imagenes usadas

    //Para dificultad dificil

    int numCartasParecidas = 0;
    int numCorrectos = 0;
    //timer

    float RealTime;

    //puntuación
   
    public float puntos = 0;

    //Cosas para mostrar en HUD

    public Text T_Puntuacion;
    public Text T_Puntuacion2;
    public Text T_Tiempo;
    public Text T_instruccionIngame;

    public Text T_Instrucciones;

    //Escenas
    public GameObject inGame;

    public GameObject Start;
    public GameObject Facil;
    public GameObject Medio;
    public GameObject Dificil;
    public GameObject Final;
    public GameObject Pause;

    //public GameObject Panel;
    public GameObject siguienteRonda;

    //Cosas escena final

    public Text T_PuntFinal;

    //PAUSA
    bool pausado = false;
    bool startGame = false;
    public Animator anim;

    float limite1Estrella, limite3Estrellas;

    [SerializeField] AudioSource click, comprobar;
    [SerializeField] AudioClip bien, mal;


    bool rendirse = false;
    // Start is called before the first frame update
    void Awake()
    {
        feedbackmanager.juego_feedback = "att";

        Start.SetActive(true);
        inGame.SetActive(false);
        //Panel.SetActive(false);
        Facil.SetActive(false);
        Medio.SetActive(false);
        Dificil.SetActive(false);

        if (Diff == 0)
        {
            limite1Estrella = 5;
            limite3Estrellas = 41;  //limite real: 25    ||    Record mio:61


            T_Instrucciones.text = "Tienes 3 cosas que comprobar:                                                                 la IMAGEN DE FONDO, la FIGURA y el NÚMERO de figuras.                                             Localiza la ÚNICA imagen que es IGUAL a la imagen de referencia.";
        }
        else if (Diff == 1)
        {
            limite1Estrella = 7;
            limite3Estrellas = 45;  //limite real: 27    ||    Record mio:51
            T_Instrucciones.text = "Tienes 3 cosas que comprobar:                                                                 la IMAGEN DE FONDO, la FIGURA y el NÚMERO de figuras.                                             Localiza la ÚNICA imagen que tiene DOS O TRES cosas similares a la imagen de referencia.";
        }
        else if (Diff == 2)
        {
            limite1Estrella = 10;
            limite3Estrellas = 50; //limite real: 30     ||    Record inventado: 41
            T_Instrucciones.text = "Tienes 3 cosas que comprobar:                                                                 la IMAGEN DE FONDO, la FIGURA y el NÚMERO de figuras.                                             Localiza LAS IMÁGENES que tengan DOS O TRES cosas similares a la imagen de referencia.";
        }

    }

    public void StartGame()
    {
        Start.SetActive(false);
        inGame.SetActive(true);
        RealTime = 120;

        if (Diff == 0)
        {
            Facil.SetActive(true);
            T_instruccionIngame.text = "Identifica la imagen IGUAL";
            CardsInScene = EasyCardsInScene;
        }
        else if (Diff == 1)
        {
            Medio.SetActive(true);
            T_instruccionIngame.text = "Identifica la imagen SIMILAR";

            CardsInScene = MediumCardsInScene;
        }
        else if (Diff == 2)
        {
            Dificil.SetActive(true);
            T_instruccionIngame.text = "Identifica las imágenes SIMILARES";

            CardsInScene = HardCardsInScene;
        }

        puntos = 0;
        numCartasParecidas = 0;
        ExampleCard = GameObject.FindGameObjectWithTag("Respawn");
        Distribute(); //poner en el botón de inicio
        startGame = true;
    }



    private void Update()
    {
        if (startGame)
        {
            RealTime -= Time.deltaTime;
            T_Tiempo.text = Mathf.Round(RealTime) + " s";

            if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false)
            {
                if (pausado)
                {
                    StartCoroutine(resume_Anim());
                }
                else
                {
                    Time.timeScale = 0;
                    T_Tiempo.color = Color.grey;
                    Pause.SetActive(true);
                    pausado = true;
                    anim.Play("Anim_PauseOn");
                }
            }


            if (RealTime <= 5)
            {
                T_Tiempo.color = Color.red;
            }
            if (RealTime <= 0)
            {
                RealTime = 0;
                StartCoroutine(EndGame());

            }
        }

    }

    void Distribute()
    {
        RandomizedFigures.Clear();
        numCartasParecidas = 0;
        numCorrectos = 0;

        foreach (GameObject Cards in CardsInScene)
        {
            Cards.GetComponent<Image>().color = Color.white;
            Cards.GetComponent<ATS_Card>().CantClick = false;
            Randomize(Cards);
        }

        SetExample();
    }  //Distribuir las cartas

    void Randomize (GameObject Cards) //Randomizar las cartas
    {
        //Get Background
        RandomizeBackground = Random.Range(0, CardsBackGround.Count);

        //Get NumFigures
        RandomizeNumFigures = Random.Range(1, 4);

        //Get Figure
        if (RandomizeNumFigures == 1)
        {
            RandomizeFigure = Random.Range(0, Cards1Figure.Count);
            FinalSprite = Cards1Figure[RandomizeFigure];
        }
        else if (RandomizeNumFigures == 2)
        {
            RandomizeFigure = Random.Range(0, Cards2Figures.Count);
            FinalSprite = Cards2Figures[RandomizeFigure];
        }
        else if (RandomizeNumFigures == 3)
        {
            RandomizeFigure = Random.Range(0, Cards3Figures.Count);
            FinalSprite = Cards3Figures[RandomizeFigure];
        }
        CheckCardsAreDifferent(Cards);
    }

    void CheckCardsAreDifferent(GameObject Cards) //Checkear si sale una carta igual que otra (y cambiarla)
    {
        bool Checked = false; //Si pasa a ser true, significa que el valor es distinto de cualquier otro anterior.

        if (RandomizedFigures.Contains("Background: " + RandomizeBackground + ", Sprite: " + FinalSprite.name + ", " + RandomizeNumFigures + " times."))
        {
            Checked = false;
        }
        else
        {
            Checked = true;
        }
        if (Checked)
        {
            PutValues(Cards);           
        }
        else
        {
            Randomize(Cards);
        }

    }

    void PutValues(GameObject Cards)  //Introducir valores en las cartas
    {
        //Put values
        Cards.GetComponent<ATS_Card>().Background = CardsBackGround[RandomizeBackground].name; //Texto para script Card con nombre del fondo
        

        Cards.GetComponent<ATS_Card>().numFigures = RandomizeNumFigures; // Texto para script Card con nombre del numFiguras

        RandomizedFigures.Add("Background: " +RandomizeBackground + ", Sprite: " + FinalSprite.name + ", " + RandomizeNumFigures + " times.");
        //Debug.Log("Background: " + CardsBackGround[RandomizeBackground].name + ", Sprite: " + FinalSprite.name + ", " + RandomizeNumFigures + " times.");
        Cards.GetComponent<ATS_Card>().Figure = FinalSprite.name;  // Texto para script Card con nombre de la figura

        Cards.GetComponent<ATS_Card>().myFigures.sprite = FinalSprite;  //Cambia el sprite de dentro
        Cards.GetComponent<Image>().sprite = CardsBackGround[RandomizeBackground];  //Cambia el sprite background
    }  

    void SetExample() //Introducir el valor de la carta ejemplo
    {

        randomNumber = Random.Range(0, CardsInScene.Count);

        int randomSimil = Random.Range(0, 4);
        int randomNumber2 = Random.Range(1, 4);

        int randomFigure = Random.Range(0, Cards1Figure.Count);

        bool found = false;
        int searching = 0;
        //ExampleCard
        ExampleCard.GetComponent<ATS_Card>().Background = CardsInScene[randomNumber].GetComponent<ATS_Card>().Background;
        ExampleCard.GetComponent<ATS_Card>().Figure = CardsInScene[randomNumber].GetComponent<ATS_Card>().Figure;
        ExampleCard.GetComponent<ATS_Card>().numFigures = CardsInScene[randomNumber].GetComponent<ATS_Card>().numFigures;

        if (ExampleCard.GetComponent<ATS_Card>().numFigures == 1)
        {
            ExampleCards = Cards1Figure;
        }
        if (ExampleCard.GetComponent<ATS_Card>().numFigures == 2)
        {
            ExampleCards = Cards2Figures;
        }
        if (ExampleCard.GetComponent<ATS_Card>().numFigures == 3)
        {
            ExampleCards = Cards3Figures;
        }

        ExampleCard.GetComponent<Image>().sprite = CardsInScene[randomNumber].GetComponent<Image>().sprite;
        ExampleCard.GetComponent<ATS_Card>().myFigures.sprite = CardsInScene[randomNumber].GetComponent<ATS_Card>().myFigures.sprite;

        if (Diff == 1)
        {
            if (randomSimil < 2)
            {
                ExampleCard.GetComponent<ATS_Card>().Background = CardsInScene[randomNumber2].GetComponent<ATS_Card>().Background;
                ExampleCard.GetComponent<Image>().sprite = CardsInScene[randomNumber2].GetComponent<Image>().sprite;

            }
            else if (randomSimil >= 2 && randomSimil <= 4)
            {
                ExampleCard.GetComponent<ATS_Card>().Figure = CardsInScene[randomNumber2].GetComponent<ATS_Card>().Figure;

                while (found == false)
                {
                    if (ExampleCards[searching].name == ExampleCard.GetComponent<ATS_Card>().Figure)
                    {
                        found = true;
                    }
                    else
                    {
                        searching++;
                    }
                }
                ExampleCard.GetComponent<ATS_Card>().myFigures.sprite = ExampleCards[searching];
            }


            foreach (GameObject Cards in CardsInScene)
            {
                RemovingSimilarOnes(Cards, ExampleCard, CardsInScene[randomNumber]);
            }
            //Debug.Log("EX -- Background: " + ExampleCard.GetComponent<Card>().Background + ", Sprite: " + ExampleCard.GetComponent<Card>().Figure + ", " + ExampleCard.GetComponent<Card>().numFigures + " times.");
        }

        else if (Diff == 2)
        {
            if (randomSimil < 2)
            {
                ExampleCard.GetComponent<ATS_Card>().Background = CardsInScene[randomNumber2].GetComponent<ATS_Card>().Background;
                ExampleCard.GetComponent<Image>().sprite = CardsInScene[randomNumber2].GetComponent<Image>().sprite;

            }
            else if (randomSimil >= 2 && randomSimil <= 4)
            {
                ExampleCard.GetComponent<ATS_Card>().Figure = CardsInScene[randomNumber2].GetComponent<ATS_Card>().Figure;

                while ( found == false)
                {
                    if (ExampleCards[searching].name == ExampleCard.GetComponent<ATS_Card>().Figure)
                    {
                        found = true;
                    }
                    else
                    {
                        searching++;
                    }
                }
                ExampleCard.GetComponent<ATS_Card>().myFigures.sprite = ExampleCards[searching];
            }
            foreach (GameObject Cards in CardsInScene)
            {
                CheckingSimilarOnes(Cards, ExampleCard);
            }
        }
    }

    void RemovingSimilarOnes(GameObject Cards, GameObject ExampleCard, GameObject ChosenOne) //Para la dificultad media
    {
        int Similarity = 0;
        bool notTheChosen = false;
        int ChosenSimilarity = 0;
        //Busco similitud a la imagen de referencia (2 o más cosas iguales)
        if (Cards.GetComponent<ATS_Card>().Background == ExampleCard.GetComponent<ATS_Card>().Background)
        {
            Similarity++;
        }
        if (Cards.GetComponent<ATS_Card>().numFigures == ExampleCard.GetComponent<ATS_Card>().numFigures)
        {
            Similarity++;
        }
        if (Cards.GetComponent<ATS_Card>().Figure == ExampleCard.GetComponent<ATS_Card>().Figure)
        {
            Similarity++;
        }

        //Busco similitud a la imagen elegida (todas iguales)
        if (Cards.GetComponent<ATS_Card>().Background == ChosenOne.GetComponent<ATS_Card>().Background)
        {
            ChosenSimilarity++;
        }
        if (Cards.GetComponent<ATS_Card>().numFigures == ChosenOne.GetComponent<ATS_Card>().numFigures)
        {
            ChosenSimilarity++;
        }
        if (Cards.GetComponent<ATS_Card>().Figure == ChosenOne.GetComponent<ATS_Card>().Figure)
        {
            ChosenSimilarity++;
        }

        //Si no son todas iguales a la imagen elegida, significa que es otra imagen
        if (ChosenSimilarity == 3)
        {
            notTheChosen = false;
        }
        else
        {
            notTheChosen = true;
        }

        //Si no es la imagen elegida, no puede tener 2 o más cosas iguales a la imagen de referencia
        if (Similarity >= 2 && notTheChosen)
        {
           RandomizeSimilarOnes(Cards);
        }
    }

    void RandomizeSimilarOnes(GameObject Card)
    {
        int sec_RandomizeBackground = Random.Range(0, CardsBackGround.Count);
        int sec_RandomizeNumFigures = Random.Range(1, 4);
        int sec_RandomizeFigure = 0;

        if (sec_RandomizeNumFigures == 1)
        {
            sec_RandomizeFigure = Random.Range(0, Cards1Figure.Count);
            sec_FinalSprite = Cards1Figure[sec_RandomizeFigure];
        }
        else if (sec_RandomizeNumFigures == 2)
        {
            sec_RandomizeFigure = Random.Range(0, Cards2Figures.Count);
            sec_FinalSprite = Cards2Figures[sec_RandomizeFigure];
        }
        else if (sec_RandomizeNumFigures == 3)
        {
            sec_RandomizeFigure = Random.Range(0, Cards3Figures.Count);
            sec_FinalSprite = Cards3Figures[sec_RandomizeFigure];
        }

        //Put values
        Card.GetComponent<ATS_Card>().Background = CardsBackGround[sec_RandomizeBackground].name; //Texto para script Card con nombre del fondo


        Card.GetComponent<ATS_Card>().numFigures = sec_RandomizeNumFigures; // Texto para script Card con nombre del numFiguras

        RandomizedFigures.Add("Background: " + sec_RandomizeBackground + ", Sprite: " + sec_FinalSprite.name + ", " + sec_RandomizeNumFigures + " times.");
        //Debug.Log("Background: " + CardsBackGround[RandomizeBackground].name + ", Sprite: " + FinalSprite.name + ", " + RandomizeNumFigures + " times.");
        Card.GetComponent<ATS_Card>().Figure = sec_FinalSprite.name;  // Texto para script Card con nombre de la figura

        Card.GetComponent<ATS_Card>().myFigures.sprite = sec_FinalSprite;  //Cambia el sprite de dentro
        Card.GetComponent<Image>().sprite = CardsBackGround[sec_RandomizeBackground];  //Cambia el sprite background

        SecondCheck(Card, ExampleCard);
    }
    void SecondCheck(GameObject Card, GameObject ExampleCard)
    {
        int Similarity = 0;
        //Busco similitud a la imagen de referencia (2 o más cosas iguales)
        if (Card.GetComponent<ATS_Card>().Background == ExampleCard.GetComponent<ATS_Card>().Background)
        {
            Similarity++;
        }
        if (Card.GetComponent<ATS_Card>().numFigures == ExampleCard.GetComponent<ATS_Card>().numFigures)
        {
            Similarity++;
        }
        if (Card.GetComponent<ATS_Card>().Figure == ExampleCard.GetComponent<ATS_Card>().Figure)
        {
            Similarity++;
        }

        if (Similarity >= 2)
        {
            RandomizeSimilarOnes(Card);
        }
    }

    void CheckingSimilarOnes(GameObject Cards, GameObject ExampleCard) //Para la dificultad dificil
    {
        int Similarity = 0;

        //Busco similitud a la imagen de referencia (2 o más cosas iguales)
        if (Cards.GetComponent<ATS_Card>().Background == ExampleCard.GetComponent<ATS_Card>().Background)
        {
            Similarity++;
        }
        if (Cards.GetComponent<ATS_Card>().numFigures == ExampleCard.GetComponent<ATS_Card>().numFigures)
        {
            Similarity++;
        }
        if (Cards.GetComponent<ATS_Card>().Figure == ExampleCard.GetComponent<ATS_Card>().Figure)
        {
            Similarity++;
        }

        if (Similarity >= 2)
        {
            numCartasParecidas++;
        }
    }  

    public void CheckCorrect(GameObject Button)  //Checkea si hace click en los buenos
    {
        int Correct = 0;

        if (Button.GetComponent<ATS_Card>().Background == ExampleCard.GetComponent<ATS_Card>().Background)
        {
            Correct++;
        }
        if (Button.GetComponent<ATS_Card>().numFigures == ExampleCard.GetComponent<ATS_Card>().numFigures)
        {
            Correct++;
        }
        if (Button.GetComponent<ATS_Card>().Figure == ExampleCard.GetComponent<ATS_Card>().Figure)
        {
            Correct++;
        }

        click.Play();

        //Modo facil
        if (Diff == 0) 
        {
            if (Correct == 3)
            {
                StartCoroutine(Win());

                Button.GetComponent<ATS_Card>().Correct = true;
                Button.GetComponent<ATS_Card>().ButtonClicked();
                //CORRECTO
            }
            else
            {
                
                StartCoroutine(Lose());
                Button.GetComponent<ATS_Card>().Correct = false;
                Button.GetComponent<ATS_Card>().ButtonClicked();
                //INCORRECTO
            }
        }

        //Modo medio
        if (Diff == 1) 
        {
           
            if (Correct >= 2)
            {
                Button.GetComponent<ATS_Card>().Correct = true;
                Button.GetComponent<ATS_Card>().ButtonClicked();
                StartCoroutine(Win());

                //CORRECTO
            }
            else
            {
                
                Button.GetComponent<ATS_Card>().Correct = false;
                Button.GetComponent<ATS_Card>().ButtonClicked();
                StartCoroutine(Lose());
                //INCORRECTO
            }
        }

        //Modo dificil
        if (Diff == 2) 
        {          
            if (Correct >= 2)
            {
                comprobar.clip = bien;
                numCorrectos++;
                
                //CORRECTO PERO NO TERMINA LA PARTIDA (hay más de 1 bien)

                Button.GetComponent<ATS_Card>().Correct = true;
                Button.GetComponent<ATS_Card>().ButtonClicked();

                if (numCorrectos >= numCartasParecidas)
                {
                    StartCoroutine(Win());
                }               
            }
            else
            {
                
                Button.GetComponent<ATS_Card>().Correct = false;
                Button.GetComponent<ATS_Card>().ButtonClicked();
                StartCoroutine(Lose());
                //INCORRECTO
            }
        }

        comprobar.Play();
    }  

   
    IEnumerator Win()
    {
        comprobar.clip = bien;
        puntos++;
        T_Puntuacion.text = puntos.ToString();
        T_Puntuacion.color = Color.green;
        T_Puntuacion2.color = Color.green;

        StartCoroutine(NewRound());
        //Panel.SetActive(true);
        //Panel.GetComponent<Image>().color = new Color(0, 10, 0, 0.3f);
        yield return new WaitForSeconds(1f);
        //Panel.SetActive(false);
        T_Puntuacion.color = Color.white;
        T_Puntuacion2.color = Color.white;

    }

    IEnumerator Lose()
    {
        comprobar.clip = mal;
        if (puntos > 0)
        {
            puntos--;
        }

        T_Puntuacion.text = puntos.ToString();
        T_Puntuacion.color = Color.red;
        T_Puntuacion2.color = Color.red;
        StartCoroutine(NewRound());
        //Panel.SetActive(true);
        //Panel.GetComponent<Image>().color = new Color(10, 0, 0, 0.3f);
        yield return new WaitForSeconds(1.5f);
        //Panel.SetActive(false);
        T_Puntuacion.color = Color.white;
        T_Puntuacion2.color = Color.white;
    }

    IEnumerator NewRound()
    {
        siguienteRonda.SetActive(true);
        yield return new WaitForSeconds(1f);
        siguienteRonda.SetActive(false);
        Distribute();
    }

    public void resume()
    {
        StartCoroutine(resume_Anim());
    }
    IEnumerator resume_Anim()
    {
        anim.Play("Anim_PauseOff");
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        T_Tiempo.color = Color.white;
        pausado = false;
        Pause.SetActive(false);
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
        rendirse = true;
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        if (!rendirse)
        {
            if (puntos >= limite1Estrella)
            {
                //win
                feedbackmanager.win = true;
                feedbackmanager.lose = false;
            }
            else
            {
                //lose
                feedbackmanager.win = false;
                feedbackmanager.lose = true;
            }

            if (puntos / limite3Estrellas <= 0.99f)
            {
                feedbackmanager.tiempo = (puntos / limite3Estrellas);
            }
            else
            {
                feedbackmanager.tiempo = 0.99f;
            }


            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("Feedback_Escena");
        }
        else
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
            feedbackmanager.tiempo = (puntos / limite3Estrellas);
            SceneManager.LoadScene("Feedback_Escena");
        }

    }

}
