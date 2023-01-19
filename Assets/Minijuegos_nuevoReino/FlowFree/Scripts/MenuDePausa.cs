using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{

    public static bool GameIsPaused = false;


    public GameObject PauseMenu;//Bloqueador;

    public Animator anim;

    //Juego_Numeros Dificultades;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

    }

    public void MenuPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        //Bloqueador.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        anim.Play("Anim_PauseOff");
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        //Bloqueador.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        anim.Play("Anim_PauseOn");

    }

    public void SalirDelJuego()
    {
        Time.timeScale = 1f;
        feedbackmanager.tiempo = CircleManager.tiempototal / CircleManager.tiempo;
        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");

    }
}
