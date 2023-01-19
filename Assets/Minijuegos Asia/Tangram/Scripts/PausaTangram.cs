using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaTangram : MonoBehaviour
{

    public bool GameIsPaused = false;
    public Animator anim;

    public GameObject PauseMenu;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Settings.isOn == false)
        {
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
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        anim.Play("Anim_PauseOn");

    }

    public void SalirDelJuego()
    {
        Time.timeScale = 1f;
        RandomizarFigura.juegoTerminado = true;
        feedbackmanager.tiempo = SombrasTangram.tiempo/ SombrasTangram.tiempoTotal;
        feedbackmanager.win = false;
        feedbackmanager.lose = true;
        SceneManager.LoadScene("Feedback_Escena");
    }
}
