using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//BD
using System;
using System.Data;
using Mono.Data.Sqlite;


public class Sqlite_UsuarioInfo : MonoBehaviour
{
    #region Archivo base de datos
    string DBfile;
    #endregion

    public Text usuario;
    public Text Dificultad_NumerosRandomizados, Dificultad_Memory, Dificultad_Simon, Dificultad_CopiaYSimetria, Dificultad_TareaNBack, Dificultad_Puzzle, Dificultad_Sabueso, Dificultad_Katamino, Dificultad_Tangram, Dificultad_Colmenas, Dificultad_FlowFree, Dificultad_AtSelectiva;
    private int Facil = 1;
    private int Medio = 2;
    private int Dificil = 3;
    public Animator tablet;

    void Start()
    {
        DBfile = "URI=file:" + Application.dataPath + "/StreamingAssets/DataBase.db"; //Path to database.
        LeerBD();
        tablet.SetBool("abierta", true);
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
                        usuario.text = reader["Usuario"].ToString();
                        Debug.Log("Usuario: " + reader["ID"] + " " + reader["Usuario"] + "\n" + "NUMEROS RANDOMIZADOS: " + reader["NUMEROSRANDOMIZADOS"] + "\n" + "MEMORY: " + reader["MEMORY"] + "\n" + "SIMON: " + reader["SIMON"] + "\n" + "COPIA Y SIMETRIA: " + reader["COPIAYSIMETRIA"] + "\n" + "TAREA N-BACK: " + reader["TAREANBACK"] + "\n" + "PUZZLE: " + reader["PUZZLE"] + "\n" + "SABUESO: " + reader["SABUESO"] + "\n" + "KATAMINO: " + reader["KATAMINO"] + "\n" + "TANGRAM: " + reader["TANGRAM"] + "\n" + "COLMENAS: " + reader["COLMENAS"] + "\n" + "FLOW FREE: " + reader["FLOWFREE"] + "\n" + "AT SELECTIVA: " + reader["ATSELECTIVA"]);

                        #region NUMEROSRANDOMIZADOS Texto
                        if (reader["NUMEROSRANDOMIZADOS"].ToString() == Facil.ToString()) { Dificultad_NumerosRandomizados.text = "Fácil"; }
                        else if(reader["NUMEROSRANDOMIZADOS"].ToString() == Medio.ToString()) { Dificultad_NumerosRandomizados.text = "Medio"; }
                        else if(reader["NUMEROSRANDOMIZADOS"].ToString() == Dificil.ToString()) { Dificultad_NumerosRandomizados.text = "Difícil"; }
                        #endregion
                        #region MEMORY Texto
                        if (reader["MEMORY"].ToString() == Facil.ToString()) { Dificultad_Memory.text = "Fácil"; }
                        else if (reader["MEMORY"].ToString() == Medio.ToString()) { Dificultad_Memory.text = "Medio"; }
                        else if (reader["MEMORY"].ToString() == Dificil.ToString()) { Dificultad_Memory.text = "Difícil"; }
                        #endregion
                        #region SIMON Texto
                        if (reader["SIMON"].ToString() == Facil.ToString()) { Dificultad_Simon.text = "Fácil"; }
                        else if (reader["SIMON"].ToString() == Medio.ToString()) { Dificultad_Simon.text = "Medio"; }
                        else if (reader["SIMON"].ToString() == Dificil.ToString()) { Dificultad_Simon.text = "Difícil"; }
                        #endregion
                        #region COPIAYSIMETRIA Texto
                        if (reader["COPIAYSIMETRIA"].ToString() == Facil.ToString()) { Dificultad_CopiaYSimetria.text = "Fácil"; }
                        else if (reader["COPIAYSIMETRIA"].ToString() == Medio.ToString()) { Dificultad_CopiaYSimetria.text = "Medio"; }
                        else if (reader["COPIAYSIMETRIA"].ToString() == Dificil.ToString()) { Dificultad_CopiaYSimetria.text = "Difícil"; }
                        #endregion
                        #region TAREANBACK Texto
                        if (reader["TAREANBACK"].ToString() == Facil.ToString()) { Dificultad_TareaNBack.text = "Fácil"; }
                        else if (reader["TAREANBACK"].ToString() == Medio.ToString()) { Dificultad_TareaNBack.text = "Medio"; }
                        else if (reader["TAREANBACK"].ToString() == Dificil.ToString()) { Dificultad_TareaNBack.text = "Difícil"; }
                        #endregion
                        #region PUZZLE Texto
                        if (reader["PUZZLE"].ToString() == Facil.ToString()) { Dificultad_Puzzle.text = "Fácil"; }
                        else if (reader["PUZZLE"].ToString() == Medio.ToString()) { Dificultad_Puzzle.text = "Medio"; }
                        else if (reader["PUZZLE"].ToString() == Dificil.ToString()) { Dificultad_Puzzle.text = "Difícil"; }
                        #endregion
                        #region SABUESO Texto
                        if (reader["SABUESO"].ToString() == Facil.ToString()) { Dificultad_Sabueso.text = "Fácil"; }
                        else if (reader["SABUESO"].ToString() == Medio.ToString()) { Dificultad_Sabueso.text = "Medio"; }
                        else if (reader["SABUESO"].ToString() == Dificil.ToString()) { Dificultad_Sabueso.text = "Difícil"; }
                        #endregion
                        #region KATAMINO Texto
                        if (reader["KATAMINO"].ToString() == Facil.ToString()) { Dificultad_Katamino.text = "Fácil"; }
                        else if (reader["KATAMINO"].ToString() == Medio.ToString()) { Dificultad_Katamino.text = "Medio"; }
                        else if (reader["KATAMINO"].ToString() == Dificil.ToString()) { Dificultad_Katamino.text = "Difícil"; }
                        #endregion
                        #region TANGRAM Texto
                        if (reader["TANGRAM"].ToString() == Facil.ToString()) { Dificultad_Tangram.text = "Fácil"; }
                        else if (reader["TANGRAM"].ToString() == Medio.ToString()) { Dificultad_Tangram.text = "Medio"; }
                        else if (reader["TANGRAM"].ToString() == Dificil.ToString()) { Dificultad_Tangram.text = "Difícil"; }
                        #endregion
                        #region COLMENAS Texto
                        if (reader["COLMENAS"].ToString() == Facil.ToString()) { Dificultad_Colmenas.text = "Fácil"; }
                        else if (reader["COLMENAS"].ToString() == Medio.ToString()) { Dificultad_Colmenas.text = "Medio"; }
                        else if (reader["COLMENAS"].ToString() == Dificil.ToString()) { Dificultad_Colmenas.text = "Difícil"; }
                        #endregion
                        #region FLOWFREE Texto
                        if (reader["FLOWFREE"].ToString() == Facil.ToString()) { Dificultad_FlowFree.text = "Fácil"; }
                        else if (reader["FLOWFREE"].ToString() == Medio.ToString()) { Dificultad_FlowFree.text = "Medio"; }
                        else if (reader["FLOWFREE"].ToString() == Dificil.ToString()) { Dificultad_FlowFree.text = "Difícil"; }
                        #endregion
                        #region ATSELECTIVA Texto
                        if (reader["ATSELECTIVA"].ToString() == Facil.ToString()) { Dificultad_AtSelectiva.text = "Fácil"; }
                        else if (reader["ATSELECTIVA"].ToString() == Medio.ToString()) { Dificultad_AtSelectiva.text = "Medio"; }
                        else if (reader["ATSELECTIVA"].ToString() == Dificil.ToString()) { Dificultad_AtSelectiva.text = "Difícil"; }
                        #endregion
                    }
                    reader.Close(); //Termina de leer
                }
            }
            connection.Close();
        }
    }
    #region Botones Dificultad
    public void NUMEROSRANDOMIZADOSFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET NUMEROSRANDOMIZADOS ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void NUMEROSRANDOMIZADOSMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET NUMEROSRANDOMIZADOS ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void NUMEROSRANDOMIZADOSDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET NUMEROSRANDOMIZADOS ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void MEMORYFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET MEMORY ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void MEMORYMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET MEMORY ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void MEMORYDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET MEMORY ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SIMONFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SIMON ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SIMONMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SIMON ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SIMONDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SIMON ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COPIAYSIMETRIAFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COPIAYSIMETRIA ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COPIAYSIMETRIAMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COPIAYSIMETRIA ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COPIAYSIMETRIADificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COPIAYSIMETRIA ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TAREANBACKFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TAREANBACK ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TAREANBACKMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TAREANBACK ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TAREANBACKDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TAREANBACK ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void PUZZLEFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET PUZZLE ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void PUZZLEMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET PUZZLE ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void PUZZLEDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET PUZZLE ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SABUESOFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SABUESO ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SABUESOMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SABUESO ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void SABUESODificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET SABUESO ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void KATAMINOFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET KATAMINO ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void KATAMINOMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET KATAMINO ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void KATAMINODificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET KATAMINO ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TANGRAMFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TANGRAM ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TANGRAMMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TANGRAM ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void TANGRAMDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET TANGRAM ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COLMENASFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COLMENAS ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COLMENASMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COLMENAS ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void COLMENASDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET COLMENAS ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void FLOWFREEFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET FLOWFREE ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void FLOWFREEMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET FLOWFREE ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void FLOWFREEDificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET FLOWFREE ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void ATSELECTIVAFacil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET ATSELECTIVA ='1' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void ATSELECTIVAMedio()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET ATSELECTIVA ='2' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    public void ATSELECTIVADificil()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Usuarios SET ATSELECTIVA ='3' WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            LeerBD();
        }
    }
    #endregion

    public void BorrarUsuario()
    {
        using (var connection = new SqliteConnection(DBfile))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Usuarios WHERE ID == " + UserActive.instance._id;
                command.ExecuteNonQuery();

            }
            connection.Close();
            SceneManager.LoadScene("ListaUsuarios");
        }
    }
}
