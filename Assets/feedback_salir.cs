using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class feedback_salir : MonoBehaviour
{
    public Animator tablet;
    public GameObject borrar;
    public GameObject tablets;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void continuar()
    {
        Seleccionar_Dificultad.fixtimer = true;
        borrar.SetActive(false);
        tablets.SetActive(true);
        tablet.SetBool("transicion_out ", true);
        Seleccionar_Dificultad.terminars = true;
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LevelDif");
    }
    public void salir()
    {
        SceneManager.LoadScene("EscenaInicial");
        
    }

}
