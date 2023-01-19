using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//BD
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Sqlite_CrearUsuario : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion

    #region Objecos Crear Usuario
    public GameObject canvasError;
    public GameObject canvasCreado;
    public InputField Usuario_InputField;
    #endregion

    public GameObject recarga;

    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }

    void Start()
    {
        DBfile = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBase.db"; //Path to database.
    }

    #region Crear Usuario
    public void AddUsuario()
    {
        if (Usuario_InputField.text == "")
        {
            canvasError.SetActive(true);
            canvasError.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(UsuarioError());
        }
        else
        {
            using (var connection = new SqliteConnection(DBfile))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Usuarios (Usuario, NUMEROSRANDOMIZADOS, MEMORY, SIMON, COPIAYSIMETRIA, TAREANBACK, PUZZLE, SABUESO, KATAMINO, TANGRAM, COLMENAS, FLOWFREE, ATSELECTIVA) " + "VALUES('" + Usuario_InputField.text + "', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ', ' 1 ');"; //[INSERT INTO "INSERTAR DENTRO DE LA TABLA" Usuarios "DONDE QUIERES INSERTAR" (Usuario, NUMEROS_RANDOMIZADOS, MEMORY, SIMON, COPIA_Y_SIMETRIA, TAREA_N-BACK, PUZZLE, SABUESO, KATAMINO, TANGRAM, COLMENAS, FLOW_FREE, AT_SELECTIVA) "ESPECIFICAS DONDE, SON COLUMNAS DE LA TABLA" VALUES "LOS VALORES QUE QUIERES INSERTAR, SE INTRODUCEN EN EL ORDEN EN EL QUE HAS ESPECIFICADO LAS COLUMNAS"]
                    command.ExecuteNonQuery();
                    
                }

                connection.Close();
            }

            Usuario_InputField.text = "";
            StartCoroutine(UsuarioCreado());
        }
    }

    public IEnumerator UsuarioError() 
    {
        yield return new WaitForSeconds(1f);
        canvasError.SetActive(false);
    }
    public IEnumerator UsuarioCreado()
    {
        canvasCreado.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvasCreado.SetActive(false);

         //para que no haga falta recargar escena
        recarga.GetComponent<Sqlite_ListaUsuarios>().AlCrearUsuario();
        //SceneManager.LoadScene("ListaUsuarios");
    }
    #endregion
}
