using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dificultades : MonoBehaviour
{
    //--------------------BOOLEANAS PARA DIFICULTADES--------------------//
    public static bool facil;
    public static bool normal;
    public static bool dificil;

    public static bool juegoIniciado = false;

    //--------------------VARIABLES DE UI--------------------//
    public GameObject[] canvasDificultades = new GameObject[3];
    public GameObject[] textIntroDificultades = new GameObject[3];
    public Text[] textTiempo = new Text[3];
    public GameObject textoInstrucciones;
    public GameObject canvasWin;
    public Text crono;
    public Canvas canvasInstrucciones;
    public AudioSource pieceSelectedSound;
    private void Start()
    {
        canvasInstrucciones.enabled = true;
        canvasWin.SetActive(false);
    }
    private void Update()
    {
        //--------------------CARGA DE INSTRUCCIONES SEGUN LA DIFICULTAD--------------------//
        textTiempo[0].text = SombrasTangram.tiempo + "s";
        textTiempo[1].text = SombrasTangram.tiempo + "s";
        textTiempo[2].text = SombrasTangram.tiempo + "s";
        if (juegoIniciado ==true)
        {
            SombrasTangram.piezaCompletada = false;
            RandomizarFigura.figuraRandomizada = false;
            canvasWin.SetActive(false);
            juegoIniciado = false;
            if (facil == true)
                Facil();
            if (normal == true)
                Normal();
            if (dificil == true)
                Dificil();
        }
        //--------------------CARGA DE RESULTADOS FINALES--------------------//
        if (SombrasTangram.piezaCompletada == true)
        {
            crono.text = ""+SombrasTangram.tiempo;
            canvasWin.SetActive(true);
            canvasDificultades[0].SetActive(false);
            canvasDificultades[1].SetActive(false);
            canvasDificultades[2].SetActive(false);

        }
    }

    public void Facil()
     {
        textIntroDificultades[2].SetActive(true);
        textoInstrucciones.SetActive(true);
     }
     public void Normal()
     {
        textIntroDificultades[2].gameObject.SetActive(true);
        textoInstrucciones.SetActive(true);
     }
     public void Dificil()
     {
        textoInstrucciones.SetActive(true);
        textIntroDificultades[2].gameObject.SetActive(true);
     }
    //--------------------FUNCION QUE SE EJECUTA AL PULSAR EL BOTON DE INICIAR--------------------//
    public void IniciarJuego()
    {
        pieceSelectedSound.Play();
        SombrasTangram.tiempo = 0;
        textoInstrucciones.SetActive(false);
        canvasInstrucciones.enabled = false;
        if (facil == true)
        {
            textIntroDificultades[2].SetActive(false);
            canvasDificultades[0].SetActive(true);
        }
        if (normal == true)
        {
            textIntroDificultades[2].SetActive(false);
            canvasDificultades[1].gameObject.SetActive(true);
        }
        if (dificil == true)
        {
            textIntroDificultades[2].SetActive(false);
            canvasDificultades[2].gameObject.SetActive(true);
        }
        
        
    }

    public void VolverEscenaPrincipal()
    {
        RandomizarFigura.juegoTerminado = true;
        SceneManager.LoadScene("LevelDif");
    }
}
