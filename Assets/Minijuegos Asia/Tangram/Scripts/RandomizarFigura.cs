using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizarFigura : MonoBehaviour
{
    //--------------------LISTAS QUE GUARDAN TODAS LAS FIGURAS--------------------//
    public List<GameObject> figurasFacil;
    public List<GameObject> figurasNormal;
    public List<GameObject> figurasDificil;
    //--------------------VARIABLES PARA RANDOMIZAR LA FIGURA--------------------//
    public static bool figuraRandomizada;
    public static bool juegoTerminado;
    int randomizarFigura;
    

    // Update is called once per frame
    void Update()
    {
        if (figuraRandomizada == false)
        {
            juegoTerminado = false;
            if (Dificultades.facil == true)
            {
                randomizarFigura = Random.Range(0, figurasFacil.Count);

                figurasFacil[randomizarFigura].SetActive(true);
                figuraRandomizada = true;
            }

            if (Dificultades.normal == true)
            {
                randomizarFigura = Random.Range(0, figurasNormal.Count);

                figurasNormal[randomizarFigura].SetActive(true);
                figuraRandomizada = true;
            }

            if (Dificultades.dificil == true)
            {
                randomizarFigura = Random.Range(0, figurasDificil.Count);

                figurasDificil[randomizarFigura].SetActive(true);
                figuraRandomizada = true;
            }
        }
        if (juegoTerminado == true)
        {
            figurasFacil[randomizarFigura].SetActive(false);
        }
    }
}
