using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

//BD 
using System;
using System.Data;
using Mono.Data.Sqlite;
public class Seleccionar_Dificultad : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion
    private int Facil = 1;
    private int Medio = 2;
    private int Dificil = 3;
    string juego_elegido;

    public static bool infiniteMode = false;
    public static bool normalMode = false;
    public static bool nobucle = false;
    public static List<string> escenas = new List<string>();
    int elegir;
    string voids;
    public GameObject nubes;
    public Animator tablet;
    public GameObject juegos;
    public GameObject tablets;
    public List<GameObject> boton = new List<GameObject>();
    bool stops;
    public static bool nubeh;
    public static bool terminars;
    public GameObject atras;
    public GameObject bolamundo; //lo usas para algo?
    public GameObject bolaMundoCOMPLETO_Prefab;
    public GameObject bolaMundoCOMPLETO;
    public GameObject camara;
    public static bool fixtimer;

    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }
    void Start()
    {
        Debug.Log(normalMode);
        if (normalMode == true)
        {
            tablets.SetActive(true);
            if (terminars == false)
            {
                tablet.SetBool("abierta", true);

            }
            if (terminars == true)
            {
                tablet.SetBool("transicion_in", true);
                Instantiate(bolaMundoCOMPLETO_Prefab);

            }
            atras.SetActive(false);
            for (int i = 0; i < boton.Count; i++)
            {
                    boton[i].SetActive(false);
            }
            StartCoroutine(botones());
            
        }
        #region Base de datos path
        DBfile = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBase.db"; //Path to database.
        #endregion
        
        if (infiniteMode == true)
        {
            atras.SetActive(false);
            juegos.SetActive(false);
            tablets.SetActive(false);

            if (nobucle == false)
            {
                escenas.Add("jeje");
                escenas.Add("numeros");
                escenas.Add("Minijuego_Figuras");
                escenas.Add("Facil");
                escenas.Add("Minijuego_Sabueso");
                escenas.Add("puzzle_escena");
                escenas.Add("memory_escena");
                escenas.Add("MinijuegoTangram");
                escenas.Add("Katamino");
                escenas.Add("Atencion");
                escenas.Add("FlowFre_juego");
                nobucle = true;
            }
            
            elegir = UnityEngine.Random.Range(0, escenas.Count);            
            voids = escenas[elegir];
            escenas.RemoveAt(elegir);

            #region unitydaasco
            if (voids == "jeje")
            {
                Dificultad_SIMON();
            }
            if (voids == "numeros")
            {
                Dificultad_NUMEROSRANDOMIZADOS();
            }
            if (voids == "Minijuego_Figuras")
            {
                Dificultad_COPIAYSIMETRIA();
            }
            if (voids == "Facil")
            {
                Dificultad_TAREANBACK();
            }
            if (voids == "Minijuego_Sabueso")
            {
                Dificultad_SABUESO();
            }
            if (voids == "memory_escena")
            {
                Dificultad_MEMORY();
            }
            if (voids == "puzzle_escena")
            {
                Dificultad_PUZZLE();
            }
            if (voids == "MinijuegoTangram")
            {
                Dificultad_TANGRAM();
            }
            if (voids == "Katamino")
            {
                Dificultad_KATAMINO();
            }
            if (voids == "Atencion")
            {
                Dificultad_ATSELECTIVA();
            }
            if (voids == "FlowFre_juego")
            {
                Dificultad_FLOWFREE();
            }
            #endregion

            if (escenas.Count == 0)
            {
                nobucle = false;
            }
        }

        bolaMundoCOMPLETO = GameObject.Find("BOLAMUNDO_PREFAB");

    }
    IEnumerator botones()
    {
        if (fixtimer == true)
        {
            yield return new WaitForSeconds(2);
        }
        
        atras.SetActive(true);
        for (int i = 0; i < boton.Count; i++)
        {
            if (stops == false)
            {
                boton[i].SetActive(true);

            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator botonesout()
    {
        atras.SetActive(false);
        for (int i = 0; i < boton.Count; i++)
        {
            boton[i].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator macedonia()
    {
        if (juego_elegido == "jeje")
        {
            stops = true;
            Earth.chosenPlace = 9;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "FlowFre_juego")
        {
            stops = true;
            Earth.chosenPlace = 8;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido== "numeros")
        {
            stops = true;
            Earth.chosenPlace = 1;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "Minijuego_Figuras")
        {
            stops = true;
            Earth.chosenPlace = 10;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "Facil")
        {
            stops = true;
            Earth.chosenPlace = 11;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "Previa")
        {
            stops = true;
            Earth.chosenPlace = 3;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "memory_escena")
        {
            stops = true;
            Earth.chosenPlace = 2;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "puzzle_escena")
        {
            stops = true;
            Earth.chosenPlace = 4;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "MinijuegoTangram")
        {
            stops = true;
            Earth.chosenPlace = 6;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);            
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "Minijuego_AtencionSelectiva")
        {
            stops = true;
            Earth.chosenPlace = 7;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }
        if (juego_elegido == "InicioKatamino")
        {
            stops = true;
            Earth.chosenPlace = 5;
            Earth.ChosenMinigame = true;
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }

        yield return new WaitForSeconds(1.3f);
        Earth.ChosenMinigame = false;
        Destroy(bolaMundoCOMPLETO);
        SceneManager.LoadScene(juego_elegido);
    }
    private void Update()
    {
        if (nubeh == true)
        {
            camara.transform.Rotate(-80, 0, 0);
            camara.transform.localPosition = new Vector3(0, -47, 68);
            nubeh = false;
        }
    }
    IEnumerator platano()
    {
        if (juego_elegido == "jeje")
        {
            Earth.chosenPlace = 9;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
            
        }
        if (juego_elegido == "FlowFre_juego")
        {
            Earth.chosenPlace = 8;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;

        }
        if (juego_elegido == "numeros")
        {
            Earth.chosenPlace = 1;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "Minijuego_Figuras")
        {
            Earth.chosenPlace = 10;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "Facil")
        {
            Earth.chosenPlace = 11;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "Previa")
        {
            Earth.chosenPlace = 3;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "memory_escena")
        {
            Earth.chosenPlace = 2;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "puzzle_escena")
        {
            Earth.chosenPlace = 4;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "MinijuegoTangram")
        {
            Earth.chosenPlace = 6;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "InicioKatamino")
        {
            Earth.chosenPlace = 5;
            Earth.ChosenMinigame = true;
            yield return new WaitForSeconds(1);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            juegos.SetActive(false);
            nubeh = true;
        }
        if (juego_elegido == "Minijuego_AtencionSelectiva")
        {
            Earth.chosenPlace = 7;
            Earth.ChosenMinigame = true;
            
            StartCoroutine(botonesout());
            yield return new WaitForSeconds(1);
            tablet.SetBool("cerrar_tablet", true);
            yield return new WaitForSeconds(1.3f);
            nubes.SetActive(true);
            yield return new WaitForSeconds(1.3f);
            nubeh = true;
        }

        yield return new WaitForSeconds(1.3f);
        Earth.ChosenMinigame = false;
        Destroy(bolaMundoCOMPLETO);
        SceneManager.LoadScene(juego_elegido);
    }

    public void LeerBD()
    {
        using (var connection = new SqliteConnection(DBfile)) //Estableces una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    while (reader.Read()) //Mientras lo lee
                    {
                        Debug.Log("Usuario: " + reader["ID"] + " " + reader["Usuario"] + "\n" + "NUMEROS RANDOMIZADOS: " + reader["NUMEROSRANDOMIZADOS"] + "\n" + "MEMORY: " + reader["MEMORY"] + "\n" + "SIMON: " + reader["SIMON"] + "\n" + "COPIA Y SIMETRIA: " + reader["COPIAYSIMETRIA"] + "\n" + "TAREA N-BACK: " + reader["TAREANBACK"] + "\n" + "PUZZLE: " + reader["PUZZLE"] + "\n" + "SABUESO: " + reader["SABUESO"] + "\n" + "KATAMINO: " + reader["KATAMINO"] + "\n" + "TANGRAM: " + reader["TANGRAM"] + "\n" + "COLMENAS: " + reader["COLMENAS"] + "\n" + "FLOW FREE: " + reader["FLOWFREE"] + "\n" + "AT SELECTIVA: " + reader["ATSELECTIVA"]);
                    }
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    #region Establecer Dificultades Y Cargar escenas
    public void Dificultad_NUMEROSRANDOMIZADOS() 
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["NUMEROSRANDOMIZADOS"].ToString() == Facil.ToString()) 
                    { 
                        numeros.dificultad = 9;
                        juego_elegido=("numeros");

                        feedbackmanager.NUMEROSRANDOMIZADOS_FACIL = true;
                        feedbackmanager.NUMEROSRANDOMIZADOS_MEDIO = false;
                        feedbackmanager.NUMEROSRANDOMIZADOS_DIFICIL = false;
                        
                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["NUMEROSRANDOMIZADOS"].ToString() == Medio.ToString()) 
                    { 
                        numeros.dificultad = 30;
                        juego_elegido = ("numeros");

                        feedbackmanager.NUMEROSRANDOMIZADOS_FACIL = false;
                        feedbackmanager.NUMEROSRANDOMIZADOS_MEDIO = true;
                        feedbackmanager.NUMEROSRANDOMIZADOS_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["NUMEROSRANDOMIZADOS"].ToString() == Dificil.ToString()) 
                    { 
                        numeros.dificultad = 99; 
                        juego_elegido = ("numeros");

                        feedbackmanager.NUMEROSRANDOMIZADOS_FACIL = false;
                        feedbackmanager.NUMEROSRANDOMIZADOS_MEDIO = false;
                        feedbackmanager.NUMEROSRANDOMIZADOS_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_MEMORY()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["MEMORY"].ToString() == Facil.ToString()) 
                    { 
                        CardChoose.myDiff = CardChoose.difficulty.easy; 
                        juego_elegido = ("memory_escena");

                        feedbackmanager.MEMORY_FACIL = true;
                        feedbackmanager.MEMORY_MEDIO = false;
                        feedbackmanager.MEMORY_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["MEMORY"].ToString() == Medio.ToString()) 
                    {
                        CardChoose.myDiff = CardChoose.difficulty.medium;
                        juego_elegido = ("memory_escena");

                        feedbackmanager.MEMORY_FACIL = false;
                        feedbackmanager.MEMORY_MEDIO = true;
                        feedbackmanager.MEMORY_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["MEMORY"].ToString() == Dificil.ToString()) 
                    { 
                        CardChoose.myDiff = CardChoose.difficulty.hard;
                        juego_elegido = ("memory_escena");

                        feedbackmanager.MEMORY_FACIL = false;
                        feedbackmanager.MEMORY_MEDIO = false;
                        feedbackmanager.MEMORY_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_SIMON()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["SIMON"].ToString() == Facil.ToString()) 
                    { 
                        Secuencia.dificultad = 1;
                        juego_elegido = ("jeje");

                        feedbackmanager.SIMON_FACIL = true;
                        feedbackmanager.SIMON_MEDIO = false;
                        feedbackmanager.SIMON_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["SIMON"].ToString() == Medio.ToString()) 
                    { 
                        Secuencia.dificultad = 2;
                        juego_elegido = ("jeje");

                        feedbackmanager.SIMON_FACIL = false;
                        feedbackmanager.SIMON_MEDIO = true;
                        feedbackmanager.SIMON_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["SIMON"].ToString() == Dificil.ToString()) { if (UnityEngine.Random.Range(0, 4) == 1) { Secuencia.dificultad = 4; } else { Secuencia.dificultad = 3; } juego_elegido = ("jeje");

                        feedbackmanager.SIMON_FACIL = false;
                        feedbackmanager.SIMON_MEDIO = false;
                        feedbackmanager.SIMON_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_COPIAYSIMETRIA()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["COPIAYSIMETRIA"].ToString() == Facil.ToString()) { lr_Selector_Dificultad.Dificultad = 1; juego_elegido = ("Minijuego_Figuras");

                        feedbackmanager.COPIAYSIMETRIA_FACIL = true;
                        feedbackmanager.COPIAYSIMETRIA_MEDIO = false;
                        feedbackmanager.COPIAYSIMETRIA_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["COPIAYSIMETRIA"].ToString() == Medio.ToString()) { lr_Selector_Dificultad.Dificultad = 2; juego_elegido = ("Minijuego_Figuras");

                        feedbackmanager.COPIAYSIMETRIA_FACIL = false;
                        feedbackmanager.COPIAYSIMETRIA_MEDIO = true;
                        feedbackmanager.COPIAYSIMETRIA_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["COPIAYSIMETRIA"].ToString() == Dificil.ToString()) { lr_Selector_Dificultad.Dificultad = 3; juego_elegido = ("Minijuego_Figuras");

                        feedbackmanager.COPIAYSIMETRIA_FACIL = false;
                        feedbackmanager.COPIAYSIMETRIA_MEDIO = false;
                        feedbackmanager.COPIAYSIMETRIA_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_TAREANBACK()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["TAREANBACK"].ToString() == Facil.ToString()) { Juego_Numeros.Dif = 1; juego_elegido = ("Facil");

                        feedbackmanager.TAREANBACK_FACIL = true;
                        feedbackmanager.TAREANBACK_MEDIO = false;
                        feedbackmanager.TAREANBACK_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["TAREANBACK"].ToString() == Medio.ToString()) { Juego_Numeros.Dif = 2; juego_elegido = ("Facil");

                        feedbackmanager.TAREANBACK_FACIL = false;
                        feedbackmanager.TAREANBACK_MEDIO = true;
                        feedbackmanager.TAREANBACK_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["TAREANBACK"].ToString() == Dificil.ToString()) { Juego_Numeros.Dif = 3; juego_elegido = ("Facil");

                        feedbackmanager.TAREANBACK_FACIL = false;
                        feedbackmanager.TAREANBACK_MEDIO = false;
                        feedbackmanager.TAREANBACK_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_PUZZLE()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["PUZZLE"].ToString() == Facil.ToString()) { PuzzleManager.dificultad_puzzle = 1; juego_elegido = ("puzzle_escena");

                        feedbackmanager.PUZZLE_FACIL = true;
                        feedbackmanager.PUZZLE_MEDIO = false;
                        feedbackmanager.PUZZLE_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["PUZZLE"].ToString() == Medio.ToString()) { PuzzleManager.dificultad_puzzle = 2; juego_elegido = ("puzzle_escena");

                        feedbackmanager.PUZZLE_FACIL = false;
                        feedbackmanager.PUZZLE_MEDIO = true;
                        feedbackmanager.PUZZLE_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["PUZZLE"].ToString() == Dificil.ToString()) { PuzzleManager.dificultad_puzzle = 3; juego_elegido = ("puzzle_escena");

                        feedbackmanager.PUZZLE_FACIL = false;
                        feedbackmanager.PUZZLE_MEDIO = false;
                        feedbackmanager.PUZZLE_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_SABUESO()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["SABUESO"].ToString() == Facil.ToString()) 
                    { 
                        lr_Selector_Dificultad_1.Facil = true;
                        lr_Selector_Dificultad_1.Medio = false;
                        lr_Selector_Dificultad_1.Dificil = false;

                        juego_elegido = ("Previa");

                        feedbackmanager.SABUESO_FACIL = true;
                        feedbackmanager.SABUESO_MEDIO = false;
                        feedbackmanager.SABUESO_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["SABUESO"].ToString() == Medio.ToString()) 
                    {
                        lr_Selector_Dificultad_1.Facil = false;
                        lr_Selector_Dificultad_1.Medio = true;
                        lr_Selector_Dificultad_1.Dificil = false;

                        juego_elegido = ("Previa");

                        feedbackmanager.SABUESO_FACIL = false;
                        feedbackmanager.SABUESO_MEDIO = true;
                        feedbackmanager.SABUESO_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["SABUESO"].ToString() == Dificil.ToString()) 
                    {
                        lr_Selector_Dificultad_1.Facil = false;
                        lr_Selector_Dificultad_1.Medio = false;
                        lr_Selector_Dificultad_1.Dificil = true;

                        juego_elegido = ("Previa");

                        feedbackmanager.SABUESO_FACIL = false;
                        feedbackmanager.SABUESO_MEDIO = false;
                        feedbackmanager.SABUESO_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_KATAMINO()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["KATAMINO"].ToString() == Facil.ToString()) { juego_elegido = ("InicioKatamino");
                        Grid.t_max = 180;
                        Grid.t_dificultad = 180;
                        DifKatamino.Facil = true;

                        feedbackmanager.KATAMINO_FACIL = true;
                        feedbackmanager.KATAMINO_MEDIO = false;
                        feedbackmanager.KATAMINO_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["KATAMINO"].ToString() == Medio.ToString()) { juego_elegido = ("InicioKatamino");
                        Grid.t_max = 180;
                        Grid.t_dificultad = 180;
                        DifKatamino.Medio = true;

                        feedbackmanager.KATAMINO_FACIL = false;
                        feedbackmanager.KATAMINO_MEDIO = true;
                        feedbackmanager.KATAMINO_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["KATAMINO"].ToString() == Dificil.ToString()) { juego_elegido = ("InicioKatamino");
                        Grid.t_max = 360;
                        Grid.t_dificultad = 360;
                        DifKatamino.Dificil = true;

                        feedbackmanager.KATAMINO_FACIL = false;
                        feedbackmanager.KATAMINO_MEDIO = false;
                        feedbackmanager.KATAMINO_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_TANGRAM()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["TANGRAM"].ToString() == Facil.ToString()) { Dificultades.facil = true; Dificultades.normal = false; Dificultades.dificil = false; Dificultades.juegoIniciado = true; juego_elegido = ("MinijuegoTangram");

                        feedbackmanager.TANGRAM_FACIL = true;
                        feedbackmanager.TANGRAM_MEDIO = false;
                        feedbackmanager.TANGRAM_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["TANGRAM"].ToString() == Medio.ToString()) { Dificultades.facil = false; Dificultades.normal = true; Dificultades.dificil = false; Dificultades.juegoIniciado = true; juego_elegido = ("MinijuegoTangram");

                        feedbackmanager.TANGRAM_FACIL = false;
                        feedbackmanager.TANGRAM_MEDIO = true;
                        feedbackmanager.TANGRAM_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["TANGRAM"].ToString() == Dificil.ToString()) { Dificultades.facil = false; Dificultades.normal = false; Dificultades.dificil = true; Dificultades.juegoIniciado = true; juego_elegido = ("MinijuegoTangram");

                        feedbackmanager.TANGRAM_FACIL = false;
                        feedbackmanager.TANGRAM_MEDIO = false;
                        feedbackmanager.TANGRAM_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_ATSELECTIVA()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["ATSELECTIVA"].ToString() == Facil.ToString())
                    {
                        DistributeCards.Diff = 0; juego_elegido = ("Minijuego_AtencionSelectiva");

                        feedbackmanager.ATSELECTIVA_FACIL = true;
                        feedbackmanager.ATSELECTIVA_MEDIO = false;
                        feedbackmanager.ATSELECTIVA_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["ATSELECTIVA"].ToString() == Medio.ToString())
                    {
                        DistributeCards.Diff = 1; juego_elegido = ("Minijuego_AtencionSelectiva");

                        feedbackmanager.ATSELECTIVA_FACIL = false;
                        feedbackmanager.ATSELECTIVA_MEDIO = true;
                        feedbackmanager.ATSELECTIVA_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["ATSELECTIVA"].ToString() == Dificil.ToString())
                    {
                        DistributeCards.Diff = 2; juego_elegido = ("Minijuego_AtencionSelectiva");

                        feedbackmanager.ATSELECTIVA_FACIL = false;
                        feedbackmanager.ATSELECTIVA_MEDIO = false;
                        feedbackmanager.ATSELECTIVA_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    public void Dificultad_FLOWFREE()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["FLOWFREE"].ToString() == Facil.ToString())
                    {
                        CircleManager.facil = true; CircleManager.medio = false; CircleManager.dificil = false; juego_elegido = ("FlowFre_juego");

                        feedbackmanager.FLOWFREE_FACIL = true;
                        feedbackmanager.FLOWFREE_MEDIO = false;
                        feedbackmanager.FLOWFREE_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["FLOWFREE"].ToString() == Medio.ToString())
                    {
                        CircleManager.facil = false; CircleManager.medio = true; CircleManager.dificil = false; juego_elegido = ("FlowFre_juego");

                        feedbackmanager.FLOWFREE_FACIL = false;
                        feedbackmanager.FLOWFREE_MEDIO = true;
                        feedbackmanager.FLOWFREE_DIFICIL = false;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }
                    else if (reader["FLOWFREE"].ToString() == Dificil.ToString())
                    {
                        CircleManager.facil = false; CircleManager.medio = false; CircleManager.dificil = true; juego_elegido = ("FlowFre_juego");

                        feedbackmanager.FLOWFREE_FACIL = false;
                        feedbackmanager.FLOWFREE_MEDIO = false;
                        feedbackmanager.FLOWFREE_DIFICIL = true;

                        if (normalMode)
                        {
                            StartCoroutine(macedonia());
                        }
                        else if (infiniteMode)
                        {
                            StartCoroutine(platano());
                        }
                    }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    #endregion
    #region Dificultades Sin establecer
    public void Dificultad_COLMENAS() 
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * FROM Usuarios WHERE ID == " + UserActive.instance._id; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    if (reader["COLMENAS"].ToString() == Facil.ToString()) { }
                    else if (reader["COLMENAS"].ToString() == Medio.ToString()) { }
                    else if (reader["COLMENAS"].ToString() == Dificil.ToString()) { }

                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    #endregion
}
