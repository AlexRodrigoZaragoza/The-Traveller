using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static bool facil;
    public static bool normal;
    public static bool dificil;
    public static bool juegoIniciado = false;
    public GameObject[] canvasDificultades = new GameObject[3];
    public GameObject[] textIntroDificultades = new GameObject[3];

    private void Update()
    {
        if (juegoIniciado == true)
        {
            juegoIniciado = false;
            if (facil == true)
                StartCoroutine(Facil());
            if (normal == true)
                StartCoroutine(Normal());
            if (dificil == true)
                StartCoroutine(Dificil());
        }
    }

    public IEnumerator Facil()
    {
        textIntroDificultades[0].SetActive(true);

        yield return new WaitForSeconds(2.0f);

        canvasDificultades[0].SetActive(true);
        StopAllCoroutines();
    }
    public IEnumerator Normal()
    {
        textIntroDificultades[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        canvasDificultades[1].gameObject.SetActive(true);
    }
    public IEnumerator Dificil()
    {
        textIntroDificultades[2].gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        canvasDificultades[2].gameObject.SetActive(true);
    }
}
