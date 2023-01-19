using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dificultad : MonoBehaviour
{
    public GameObject Simon, randoms, memory, tarea, copia, sabueso, puzzles, tangram, katamino;
    bool closeSimon = false;
    bool closeRandom = false;
    bool closeMemory = false;
    bool closeTarea = false;
    bool closeCopia = false;
    bool closeSabueso = false;
    bool closePuzzle = false;
    bool closeTangram = false;
    bool closeKatamino = false;
    public static int difKata;



    #region Simon

    public void simon()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closeSimon == false)
        {
            Simon.SetActive(true);
            closeSimon = true;

        }
        else //ya se cierra
        {
            Simon.SetActive(false);
            closeSimon = false;
        }

    }

    public void simonfacil()
    {
        Secuencia.dificultad = 1;
        //SceneManager.LoadScene("jeje");
        //Perdon por el nombre xd, se puede cambiar luego
    }

    public void simonmedio()
    {
        Secuencia.dificultad = 2;
        //SceneManager.LoadScene("jeje");
    }

    public void simondificil()
    {
        if (Random.Range(0, 4) == 1)
        {
            Secuencia.dificultad = 4;
        }
        else
        {
            Secuencia.dificultad = 3;

        }
        //SceneManager.LoadScene("jeje");
        
    }

    #endregion

    #region Random
    public void random()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre

        if (closeRandom == false)
        {
            randoms.SetActive(true);
            closeRandom = true;

        }

        else //ya se cierra
        {
            randoms.SetActive(false);
            closeRandom = false;
        }

    }

    public void randomfacil()
    {
        numeros.dificultad = 9;
        //SceneManager.LoadScene("numeros");

    }
    public void randommedio()
    {
        
        numeros.dificultad = 30;
        //SceneManager.LoadScene("numeros");

    }
    public void randomdificil()
    {
        numeros.dificultad = 99;
        //SceneManager.LoadScene("numeros");

    }
    #endregion

    #region Memory

    public void Memory()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closeMemory == false)
        {
            memory.SetActive(true);
            closeMemory = true;

        }
        else //ya se cierra
        {
            memory.SetActive(false);
            closeMemory = false;
        }


    }

    public void memoryfacil()
    {
        CardChoose.myDiff = CardChoose.difficulty.easy;
        //SceneManager.LoadScene("aa");
        //Perdon por el nombre xd, se puede cambiar luego
    }

    public void memorymedio()
    {
        CardChoose.myDiff = CardChoose.difficulty.medium;
        //SceneManager.LoadScene("aa");
    }

    public void memorydificil()
    {

        CardChoose.myDiff = CardChoose.difficulty.hard;
        //SceneManager.LoadScene("aa");

    }
    #endregion

    #region Tarea n_Back

    public void Tareanback()
    {

            //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
            if (closeTarea == false)
            {
                tarea.SetActive(true);
                closeTarea = true;

            }
            else //ya se cierra
            {
                tarea.SetActive(false);
                closeTarea = false;
            }       
    }


    public void TareaFacil()
    {
        Juego_Numeros.Dif = 1;       
        //SceneManager.LoadScene("Facil");       
    }

    public void TareaNormal()
    {
        Juego_Numeros.Dif = 2;
        //SceneManager.LoadScene("Facil");
    }

    public void TareaDificil()
    {
        Juego_Numeros.Dif = 3;
        //SceneManager.LoadScene("Facil");
    }


    #endregion

    #region Copia y Simetria

    public void CopiaYSimetria()
    {

            //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
            if (closeCopia == false)
            {
                copia.SetActive(true);
                closeCopia = true;

            }
            else //ya se cierra
            {
                copia.SetActive(false);
                closeCopia = false;
            }
        
        
    }

    public void CopiaFacil()
    {
        lr_Selector_Dificultad.Dificultad = 1;

        //SceneManager.LoadScene("Minijuego_Figuras");
    }

    public void CopiaNormal()
    {
        lr_Selector_Dificultad.Dificultad = 2;

        //SceneManager.LoadScene("Minijuego_Figuras");
    }

    public void CopiaDificil()
    {
        lr_Selector_Dificultad.Dificultad = 3;

        //SceneManager.LoadScene("Minijuego_Figuras");
    }

    #endregion

    #region Sabueso

    public void Sabueso()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closeSabueso == false)
        {
            sabueso.SetActive(true);
            closeSabueso = true;

        }
        else //ya se cierra
        {
            sabueso.SetActive(false);
            closeSabueso = false;
        }
    }

    public void SabuesoFacil()
    {
        lr_Selector_Dificultad_1.Facil=true;
        //SceneManager.LoadScene("Minijuego_Sabueso");
    }

    public void SabuesoNormal()
    {
        lr_Selector_Dificultad_1.Medio = true;
        //SceneManager.LoadScene("Minijuego_Sabueso");
    }

    public void SabuesoDificil()
    {
        lr_Selector_Dificultad_1.Dificil = true;
        //SceneManager.LoadScene("Minijuego_Sabueso");

    }

    #endregion

    #region Puzzle

    public void puzzle()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closePuzzle == false)
        {
            puzzles.SetActive(true);
            closePuzzle = true;

        }
        else //ya se cierra
        {
            puzzles.SetActive(false);
            closePuzzle = false;
        }

    }

    public void puzzlefacil()
    {
        PuzzleManager.dificultad_puzzle = 1;
        //SceneManager.LoadScene("Puzzle");
    }

    public void puzzlemedio()
    {
        PuzzleManager.dificultad_puzzle = 2;
        //SceneManager.LoadScene("Puzzle");
    }

    public void puzzledificil()
    {

        PuzzleManager.dificultad_puzzle = 3;
        
        
        //SceneManager.LoadScene("Puzzle");

    }


    #endregion

    #region Tangram

    public void Tangram()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closeTangram == false)
        {
            tangram.SetActive(true);
            closeTangram = true;

        }
        else //ya se cierra
        {
            tangram.SetActive(false);
            closeTangram = false;
        }

    }

    public void TangramFacil()
    { 
        
        Dificultades.facil = true;
        Dificultades.normal = false;
        Dificultades.dificil = false;
        Dificultades.juegoIniciado = true;
        //SceneManager.LoadScene("MinijuegoTangram");
    }

    public void TangramNormal()
    {
        Dificultades.normal = true;
        Dificultades.facil = false;
        Dificultades.dificil = false;
        Dificultades.juegoIniciado = true;
        //SceneManager.LoadScene("MinijuegoTangram");
    }

    public void TangramDificil()
    {
        Dificultades.dificil = true;
        Dificultades.normal = false;
        Dificultades.facil = false;
        Dificultades.juegoIniciado = true;
        //SceneManager.LoadScene("MinijuegoTangram");
    }


    #endregion

    #region Katamino

    public void Katamino()
    {
        //Esto es para que se abra el esplegable de dificultad, pero molaría hacer que al volver a clicar se cierre
        if (closeKatamino == false)
        {
            katamino.SetActive(true);
            closeKatamino = true;

        }
        else //ya se cierra
        {
            katamino.SetActive(false);
            closeKatamino = false;
        }

    }

    public void kataminofacil()
    {
        //PONER LA DIFICULTAD
        difKata = 1;
    }

    public void kataminomedio()
    {
        //PONER LA DIFICULTAD
        difKata = 2;
    }

    public void kataminodificil()
    {
        //PONER LA DIFICULTAD
        difKata = 3;

    }


    #endregion



    public void jugar()
    {
        SceneManager.LoadScene("LevelDif");
    }

    public void Salir()
    {

        SceneManager.LoadScene("EscenaInicial"); //Aquí va la base de datos de jorge

    }

}
