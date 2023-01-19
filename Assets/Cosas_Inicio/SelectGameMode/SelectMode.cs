using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    public Animator tablet;
    public void Start()
    {
        tablet.SetBool("abierta", true);

    }
    public void Historia()
    {
        Seleccionar_Dificultad.infiniteMode = true;
        Seleccionar_Dificultad.normalMode = false;
        SceneManager.LoadScene("LevelDif");
    }

    public void FreePlay()
    {
        Seleccionar_Dificultad.infiniteMode = false;
        Seleccionar_Dificultad.normalMode = true;
        Seleccionar_Dificultad.fixtimer = false;
        SceneManager.LoadScene("LevelDif");

    }

}
