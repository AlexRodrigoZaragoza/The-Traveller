using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class FinEscena : MonoBehaviour
{
    public Animator anim;
    public void _CambiarEscena()
    {
        StartCoroutine("CambiandoEscena");
    }

    IEnumerator CambiandoEscena()
    {
        anim.SetTrigger("Play");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("ListaUsuarios");
    }

    public void CerrarJuego()
    {
        StartCoroutine("CerrandoJuego");
    }

    IEnumerator CerrandoJuego()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
