using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaKatamino : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject PauseMenu;

    public Animator anim;
    public GameObject texto;
    public GameObject pieza;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false)
        {
            texto.SetActive(false);
            pieza.SetActive(false);
            GameIsPaused =! GameIsPaused;
            if (GameIsPaused == true)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }
       
    public void Resume()
    {
        StartCoroutine("resume_Anim");
    }

    public IEnumerator resume_Anim()
    {
        anim.Play("Anim_PauseOff"); //Animación de quitar Pausa
        yield return new WaitForSecondsRealtime(1f); //Tiempo de animación ¡¡¡¡¡WaitForSecondsREALTIME!!!!!
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        texto.SetActive(true);
        pieza.SetActive(true);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        anim.Play("Anim_PauseOn");
        texto.SetActive(false);
        pieza.SetActive(false);
    }

    public void SalirDelJuego()
    {
        Time.timeScale = 1f;

        feedbackmanager.tiempo = Grid.t_current / Grid.t_dificultad;

        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");
    }
}
