using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//BD
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Sqlite_Feedback : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion

    public GameObject PARTIDAS_NUMEROSRANDOMIZADOS, NUMEROSRANDOMIZADOS_FACIL, NUMEROSRANDOMIZADOS_MEDIO, NUMEROSRANDOMIZADOS_DIFICIL;
    public GameObject PARTIDAS_MEMORY, MEMORY_FACIL, MEMORY_MEDIO, MEMORY_DIFICIL;
    public GameObject PARTIDAS_SIMON, SIMON_FACIL, SIMON_MEDIO, SIMON_DIFICIL;
    public GameObject PARTIDAS_COPIAYSIMETRIA, COPIAYSIMETRIA_FACIL, COPIAYSIMETRIA_MEDIO, COPIAYSIMETRIA_DIFICIL;
    public GameObject PARTIDAS_TAREANBACK, TAREANBACK_FACIL, TAREANBACK_MEDIO, TAREANBACK_DIFICIL;
    public GameObject PARTIDAS_PUZZLE, PUZZLE_FACIL, PUZZLE_MEDIO, PUZZLE_DIFICIL;
    public GameObject PARTIDAS_SABUESO, SABUESO_FACIL, SABUESO_MEDIO, SABUESO_DIFICIL;
    public GameObject PARTIDAS_KATAMINO, KATAMINO_FACIL, KATAMINO_MEDIO, KATAMINO_DIFICIL;
    public GameObject PARTIDAS_TANGRAM, TANGRAM_FACIL, TANGRAM_MEDIO, TANGRAM_DIFICIL;
    public GameObject PARTIDAS_FLOWFREE, FLOWFREE_FACIL, FLOWFREE_MEDIO, FLOWFREE_DIFICIL;
    public GameObject PARTIDA_ATSELECTIVA, ATSELECTIVA_FACIL, ATSELECTIVA_MEDIO, ATSELECTIVA_DIFICIL;

    // Start is called before the first frame update

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeerBD()
    {
        using (var connection = new SqliteConnection(DBfile)) //Crando una conecxion con la DB
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

                        PARTIDAS_NUMEROSRANDOMIZADOS.GetComponent<Text>().text = reader["PARTIDAS_NUMEROSRANDOMIZADOS"].ToString();
                        NUMEROSRANDOMIZADOS_FACIL.GetComponent<Text>().text = reader["NUMEROSRANDOMIZADOS_FACIL"].ToString();
                        NUMEROSRANDOMIZADOS_MEDIO.GetComponent<Text>().text = reader["NUMEROSRANDOMIZADOS_MEDIO"].ToString();
                        NUMEROSRANDOMIZADOS_DIFICIL.GetComponent<Text>().text = reader["NUMEROSRANDOMIZADOS_DIFICIL"].ToString();

                        PARTIDAS_MEMORY.GetComponent<Text>().text = reader["PARTIDAS_MEMORY"].ToString();
                        MEMORY_FACIL.GetComponent<Text>().text = reader["MEMORY_FACIL"].ToString();
                        MEMORY_MEDIO.GetComponent<Text>().text = reader["MEMORY_MEDIO"].ToString();
                        MEMORY_DIFICIL.GetComponent<Text>().text = reader["MEMORY_DIFICIL"].ToString();

                        PARTIDAS_SIMON.GetComponent<Text>().text = reader["PARTIDAS_SIMON"].ToString();
                        SIMON_FACIL.GetComponent<Text>().text = reader["SIMON_FACIL"].ToString();
                        SIMON_MEDIO.GetComponent<Text>().text = reader["SIMON_MEDIO"].ToString();
                        SIMON_DIFICIL.GetComponent<Text>().text = reader["SIMON_DIFICIL"].ToString();

                        PARTIDAS_COPIAYSIMETRIA.GetComponent<Text>().text = reader["PARTIDAS_COPIAYSIMETRIA"].ToString();
                        COPIAYSIMETRIA_FACIL.GetComponent<Text>().text = reader["COPIAYSIMETRIA_FACIL"].ToString();
                        COPIAYSIMETRIA_MEDIO.GetComponent<Text>().text = reader["COPIAYSIMETRIA_MEDIO"].ToString();
                        COPIAYSIMETRIA_DIFICIL.GetComponent<Text>().text = reader["COPIAYSIMETRIA_DIFICIL"].ToString();

                        PARTIDAS_TAREANBACK.GetComponent<Text>().text = reader["PARTIDAS_TAREANBACK"].ToString();
                        TAREANBACK_FACIL.GetComponent<Text>().text = reader["TAREANBACK_FACIL"].ToString();
                        TAREANBACK_MEDIO.GetComponent<Text>().text = reader["TAREANBACK_MEDIO"].ToString();
                        TAREANBACK_DIFICIL.GetComponent<Text>().text = reader["TAREANBACK_DIFICIL"].ToString();

                        PARTIDAS_PUZZLE.GetComponent<Text>().text = reader["PARTIDAS_PUZZLE"].ToString();
                        PUZZLE_FACIL.GetComponent<Text>().text = reader["PUZZLE_FACIL"].ToString();
                        PUZZLE_MEDIO.GetComponent<Text>().text = reader["PUZZLE_MEDIO"].ToString();
                        PUZZLE_DIFICIL.GetComponent<Text>().text = reader["PUZZLE_DIFICIL"].ToString();

                        PARTIDAS_SABUESO.GetComponent<Text>().text = reader["PARTIDAS_SABUESO"].ToString();
                        SABUESO_FACIL.GetComponent<Text>().text = reader["SABUESO_FACIL"].ToString();
                        SABUESO_MEDIO.GetComponent<Text>().text = reader["SABUESO_MEDIO"].ToString();
                        SABUESO_DIFICIL.GetComponent<Text>().text = reader["SABUESO_DIFICIL"].ToString();

                        PARTIDAS_KATAMINO.GetComponent<Text>().text = reader["PARTIDAS_KATAMINO"].ToString();
                        KATAMINO_FACIL.GetComponent<Text>().text = reader["KATAMINO_FACIL"].ToString();
                        KATAMINO_MEDIO.GetComponent<Text>().text = reader["KATAMINO_MEDIO"].ToString();
                        KATAMINO_DIFICIL.GetComponent<Text>().text = reader["KATAMINO_DIFICIL"].ToString();

                        PARTIDAS_TANGRAM.GetComponent<Text>().text = reader["PARTIDAS_TANGRAM"].ToString();
                        TANGRAM_FACIL.GetComponent<Text>().text = reader["TANGRAM_FACIL"].ToString();
                        TANGRAM_MEDIO.GetComponent<Text>().text = reader["TANGRAM_MEDIO"].ToString();
                        TANGRAM_DIFICIL.GetComponent<Text>().text = reader["TANGRAM_DIFICIL"].ToString();

                        PARTIDAS_FLOWFREE.GetComponent<Text>().text = reader["PARTIDAS_FLOWFREE"].ToString();
                        FLOWFREE_FACIL.GetComponent<Text>().text = reader["FLOWFREE_FACIL"].ToString();
                        FLOWFREE_MEDIO.GetComponent<Text>().text = reader["FLOWFREE_MEDIO"].ToString();
                        FLOWFREE_DIFICIL.GetComponent<Text>().text = reader["FLOWFREE_DIFICIL"].ToString();

                        PARTIDA_ATSELECTIVA.GetComponent<Text>().text = reader["PARTIDAs_ATSELECTIVA"].ToString();
                        ATSELECTIVA_FACIL.GetComponent<Text>().text = reader["ATSELECTIVA_FACIL"].ToString();
                        ATSELECTIVA_MEDIO.GetComponent<Text>().text = reader["ATSELECTIVA_MEDIO"].ToString();
                        ATSELECTIVA_DIFICIL.GetComponent<Text>().text = reader["ATSELECTIVA_DIFICIL"].ToString();
                    }
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
}
