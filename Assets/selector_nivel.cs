using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selector_nivel : MonoBehaviour
{
    public GameObject visor;
    Vector3 target;
    Vector3 inicial;
    public bool abrirmenu=false;
    public static string juego;
    public GameObject boton_jugar;

    public GameObject GO_Options;
    public GameObject boton_abrir;

    private void Start()
    {
        inicial = new Vector3(visor.transform.position.x, visor.transform.position.y);
        target = new Vector3(Screen.width/2, visor.transform.position.y);
        if (Seleccionar_Dificultad.infiniteMode == true)
        {
            visor.SetActive(false);
        }
        else {
            visor.SetActive(true);
        }
    }
    private void Update()
    {
        if (abrirmenu == true)
        {
            visor.transform.position = Vector2.MoveTowards(visor.transform.position, target, Time.deltaTime * 700);
        }
        else
        {
            visor.transform.position = Vector2.MoveTowards(visor.transform.position, inicial, Time.deltaTime * 700);
        }
        
        if (visor.transform.position == inicial)
        {
            boton_abrir.GetComponent<Animator>().Play("AbrirVisor_Parpadeo");
        }
        else if (visor.transform.position == target)
        {
            boton_abrir.GetComponent<Animator>().Play("VisorAbierto");
        }
        else 
        {
            boton_abrir.GetComponent<Animator>().Play("Idle");
        }
    }
    public void tablet()
    {
        if (abrirmenu == false)
        {
            abrirmenu = true;
        }
        else
        {
            abrirmenu = false;

        }
    }

    public void simon()
    {
        if (visor.transform.position == target)
        {
            juego ="jeje";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }

    }
    public void numeros()
    {
        if (visor.transform.position == target)
        {
            juego = "numeros";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }
    public void memory()
    {
        if (visor.transform.position == target)
        {
            juego = "aa";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void tarean()
    {
        if (visor.transform.position == target)
        {
            juego = "Facil";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void copia()
    {
        if (visor.transform.position == target)
        {
            juego = "Minijuego_Figuras";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void sabueso()
    {
        if (visor.transform.position == target)
        {
            juego = "Minijuego_Sabueso";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void puzzle()
    {
        if (visor.transform.position == target)
        {
            juego = "Puzzle";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void tangram()
    {
        if (visor.transform.position == target)
        {
            juego = "MinijuegoTangram";
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void katamino()
    {
        if (visor.transform.position == target)
        {
            switch (Dificultad.difKata)
            {
                case 1:
                    juego = "Katamino1";
                    break;
                case 2:
                    juego = "Katamino2";
                        break;
                case 3:
                    juego = "Katamino3";
                        break;
            }
            boton_jugar.SetActive(true);
            abrirmenu = false;

        }
    }

    public void Options()
    {
        GO_Options.SetActive(true);
    }

    public void exitOptions()
    {
        GO_Options.SetActive(false);
    }

    public void jugar()
    {
        SceneManager.LoadScene(juego);
    }

    public void siguiente()
    {
        SceneManager.LoadScene("IntermedioMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
