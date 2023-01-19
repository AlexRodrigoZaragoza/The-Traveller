using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//BD
using System;
using System.Data;
using Mono.Data.Sqlite;

public class feedbackmanager : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion

    public static feedbackmanager instance;

    public GameObject infiniteData;
    public static string juego_feedback;

    public static bool win = false;
    public static bool lose = false;
    public static float tiempo = 0;

    string minigame;

    [SerializeField] Slider sliderPuntacion; // entre 0 - 1.5  EXPLICACIÓN: 0-1 = Tiempo, 1-1.5 = Win/Lose (Si llega a 0.88 = 2 estrellas, si llega a 1.111 = 3 estrellas) MARGEN DE 0.4 (casi la mitad de tiempo)
    [Header("GO de los fondos")]
    [SerializeField] GameObject simon;
    [SerializeField] GameObject numeros;
    [SerializeField] GameObject copia;
    [SerializeField] GameObject tarea;
    [SerializeField] GameObject sabueso;
    [SerializeField] GameObject memory;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject tangram;
    [SerializeField] GameObject katamino;
    [SerializeField] GameObject att;
    [SerializeField] GameObject flow;

    [Space]
    [Header("Cosas para cambiar las estrellas")]

    //para "animar"
    [SerializeField] Text t_Tiempo;
    [SerializeField] Text t_Resultado; //win o lose

    //para la barra
    [SerializeField] Image limit1, limit2, limit3;


    [SerializeField] Image firstStar;
    [SerializeField] Image secondStar;
    [SerializeField] Image thirdStar;
    [SerializeField] Sprite winSprite, blankSprite;

    float tiempoAnim = 0;
    float limiteEstrellas;
    float empiezaEstrellas;

    [SerializeField] GameObject firstPoint, secondPoint, thirdPoint;

    public GameObject boton_finHistoria, boton_finNormal, HUDNormal, HUDFalloInfinito;

    [Space]
    [Header("NUMEROSRANDOMIZADOS")]
    public Text PARTIDAS_NUMEROSRANDOMIZADOS;
    public static bool NUMEROSRANDOMIZADOS_FACIL, NUMEROSRANDOMIZADOS_MEDIO, NUMEROSRANDOMIZADOS_DIFICIL;
    [Header("MEMORY")]
    public string PARTIDAS_MEMORY;
    public static bool MEMORY_FACIL, MEMORY_MEDIO, MEMORY_DIFICIL;
    [Header("SIMON")]
    public string PARTIDAS_SIMON;
    public static bool SIMON_FACIL, SIMON_MEDIO, SIMON_DIFICIL;
    [Header("COPIAYSIMETRIA_FACIL")]
    public string PARTIDAS_COPIAYSIMETRIA;
    public static bool COPIAYSIMETRIA_FACIL, COPIAYSIMETRIA_MEDIO, COPIAYSIMETRIA_DIFICIL;
    [Header("TAREANBACK")]
    public string PARTIDAS_TAREANBACK;
    public static bool TAREANBACK_FACIL, TAREANBACK_MEDIO, TAREANBACK_DIFICIL;
    [Header("PUZZLE")]
    public string PARTIDAS_PUZZLE;
    public static bool PUZZLE_FACIL, PUZZLE_MEDIO, PUZZLE_DIFICIL;
    [Header("SABUESO")]
    public string PARTIDAS_SABUESO;
    public static bool SABUESO_FACIL, SABUESO_MEDIO, SABUESO_DIFICIL;
    [Header("KATAMINO")]
    public string PARTIDAS_KATAMINO;
    public static bool KATAMINO_FACIL, KATAMINO_MEDIO, KATAMINO_DIFICIL;
    [Header("TANGRAM")]
    public string PARTIDAS_TANGRAM;
    public static bool TANGRAM_FACIL, TANGRAM_MEDIO, TANGRAM_DIFICIL;
    [Header("FLOWFREE")]
    public string PARTIDAS_FLOWFREE;
    public static bool FLOWFREE_FACIL, FLOWFREE_MEDIO, FLOWFREE_DIFICIL;
    [Header("FLOWFREE")]
    public string PARTIDA_ATSELECTIVA;
    public static bool ATSELECTIVA_FACIL, ATSELECTIVA_MEDIO, ATSELECTIVA_DIFICIL;

    // Start is called before the first frame update
    void Start()
    {
        #region Base de datos path
        DBfile = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBase.db"; //Path to database.
        #endregion

        if (Seleccionar_Dificultad.infiniteMode)
        {
            boton_finNormal.SetActive(false);
        }
        if (Seleccionar_Dificultad.normalMode)
        {
            boton_finHistoria.SetActive(false);
        }

        if (juego_feedback == "simon")
        {
            minigame = "Simon";
            simon.SetActive(true);

        }
        if (juego_feedback == "numeros")
        {
            minigame = "Números randomizados";
            numeros.SetActive(true);
        }
        if (juego_feedback == "copia")
        {
            minigame = "Copia y simetria";
            copia.SetActive(true);
        }
        if (juego_feedback == "tarean")
        {
            minigame = "Tarea n-back";
            tarea.SetActive(true);
        }
        if (juego_feedback == "sabueso")
        {
            minigame = "Sabueso";
            sabueso.SetActive(true);
        }
        if (juego_feedback == "memory")
        {
            minigame = "Memory";
            memory.SetActive(true);
        }
        if (juego_feedback == "puzzle")
        {
            minigame = "Puzzle";
            puzzle.SetActive(true);
        }
        if (juego_feedback == "tangram")
        {
            minigame = "Tangram";
            tangram.SetActive(true);
        }
        if (juego_feedback == "katamino")
        {
            minigame = "Katamino";
            katamino.SetActive(true);
        }
        if (juego_feedback == "att")
        {
            minigame = "Atención selectiva";
            att.SetActive(true);
        }
        if (juego_feedback == "flow")
        {
            minigame = "Flow free";
            flow.SetActive(true);
        }

        if (win)
        {
            // hacer primera estrella + tiempo
            StartCoroutine(WonGame());

        }
        if (lose)
        {
            //estrellas = 0
            LostGame();
        }


    }

    IEnumerator WonGame()
    {
        infiniteData.GetComponent<SendGameData>().AddNewInfo(minigame, "¡COMPLETADO!");

        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    t_Resultado.text = "¡Enhorabuena " + reader["Usuario"] + " ,has completado el nivel!";
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }

        if (tiempo >= 0.6f)
        {
            //tres estrellas
            tiempoAnim = 0;
            empiezaEstrellas = 0f;
            limiteEstrellas = 0.5f;
            yield return new WaitForSeconds(1f);
            tiempoAnim = 0;
            empiezaEstrellas = 0.5f;
            limiteEstrellas = 1f;
            yield return new WaitForSeconds(1f);
            tiempoAnim = 0;
            empiezaEstrellas = 1f;
            limiteEstrellas = 1.5f;
        }
        else if (tiempo >= 0.3f)
        {
            //dos estrellas
            tiempoAnim = 0;
            empiezaEstrellas = 0f;
            limiteEstrellas = 0.5f;
            yield return new WaitForSeconds(1f);
            tiempoAnim = 0;
            empiezaEstrellas = 0.5f;
            limiteEstrellas = 1f;
        }
        else if (tiempo < 0.3f)
        {
            //una estrella
            tiempoAnim = 0;
            empiezaEstrellas = 0f;
            limiteEstrellas = 0.5f;
        }
    }

    private void Update()
    {
        //Debug.Log(sliderPuntacion.value);
        tiempoAnim += Time.deltaTime;
        sliderPuntacion.value = Mathf.Lerp(empiezaEstrellas, limiteEstrellas, tiempoAnim / 1);

        if (sliderPuntacion.value > 0.45f && sliderPuntacion.value < 0.55f)
        {
            firstStar.sprite = winSprite;

        }
        if (sliderPuntacion.value > 0.75f && sliderPuntacion.value < 0.85f)
        {
            secondStar.sprite = winSprite;
        }
        if (sliderPuntacion.value > 1.05f && sliderPuntacion.value < 1.15f)
        {
            thirdStar.sprite = winSprite;
        }
    }

    void LostGame()
    {
        if (Seleccionar_Dificultad.infiniteMode)
        {
            HUDNormal.SetActive(false);
            HUDFalloInfinito.SetActive(true);
        }
        infiniteData.GetComponent<SendGameData>().AddNewInfo(minigame, "VIAJE FINALIZADO");
        sliderPuntacion.value = 0;

        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    t_Resultado.text = "¡ " + reader["Usuario"] + " casi lo consigues!";
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
}
