using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//BD
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Sqlite_ListaUsuarios : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion
    public static Sqlite_ListaUsuarios instance;
    public static UserActive _UserActive;
    public static UserButton _UserButton;

    public Text list;

    public RectTransform Content;
    public GameObject Boton_Usuario;
    public Animator tablet;

    public static List<string> ListaDeIDs = new List<string>();
    public List<string> ListaDeUsuarios = new List<string>();
    //public List<string> ListaDeDificultades = new List<string>();
    public List<DatosUsuario> datos_usuario = new List<DatosUsuario>();
    public List<GameObject> ListaDeBoton_Usuario = new List<GameObject>();
    public GameObject cosa;
    static bool primeraVez = true;

    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }
    void Start()
    {
        #region Base de datos path
        DBfile = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBase.db"; //Path to database.
        #endregion
        LeerBD();
        if (primeraVez)
        {
            cosa.SetActive(false);
            tablet.SetBool("tablet", true);
            primeraVez = false;
            StartCoroutine(Avocado());
        }
        else
        {
            tablet.SetBool("abierta", true);
        }
    }
    IEnumerator Avocado()
    {
        yield return new WaitForSeconds(1.3f);
        cosa.SetActive(true);
    }

    public void LeerBD()
    {
        GameObject New_Boton_Usuario;

        list.text = "";

        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //Creando comando
            {
                command.CommandText = "SELECT * " + "FROM Usuarios"; //Dandole tipo al comanmdo [SELECT "SELECCIONAR" * "TODO" FROM "DE DONDE" Usuarios "EL NOMBRE DE LA TABLA"]

                using (IDataReader reader = command.ExecuteReader()) //Comando "reader" para leer
                {
                    while (reader.Read()) //Mientras lo lee
                    {
                        ListaDeIDs.Add(reader["ID"].ToString());
                        ListaDeUsuarios.Add(reader["Usuario"].ToString());
                        //ListaDeDificultades.Add(reader["Dificultad"].ToString());

                        datos_usuario.Add(new DatosUsuario(reader["ID"].ToString(), reader["Usuario"].ToString()/*, reader["Dificultad"].ToString()*/));
                        New_Boton_Usuario = Instantiate(Boton_Usuario, Content);
                        ListaDeBoton_Usuario.Add(New_Boton_Usuario);
                        ListaDeBoton_Usuario[ListaDeBoton_Usuario.Count - 1].transform.GetChild(1).GetComponent<Text>().text = datos_usuario[datos_usuario.Count - 1].usuario;
                        New_Boton_Usuario.GetComponent<UserButton>()._id = ListaDeIDs[ListaDeIDs.Count - 1];

                        //list.text +=  "Usuario \t\t" + reader["Usuario"] + "\t\t" + "Dificultad \t\t" + reader["Dificultad"].ToString() + "\n"; //Lo imprime
                    }
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }

    public void DestroyObjects(string boton_usuario)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(boton_usuario);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }
    public void CambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void AlCrearUsuario()          //para que no haga falta recargar escena
    {
        datos_usuario.Clear();
        ListaDeIDs.Clear();
        ListaDeUsuarios.Clear();

        for (int i = 0; i < ListaDeBoton_Usuario.Count; i++)
        {
            Destroy(ListaDeBoton_Usuario[i]);
        }
        ListaDeBoton_Usuario.Clear();
        LeerBD();
    }

    public void vueltaInicio()
    {
        primeraVez = true;
        SceneManager.LoadScene("EscenaInicial");
    }
}