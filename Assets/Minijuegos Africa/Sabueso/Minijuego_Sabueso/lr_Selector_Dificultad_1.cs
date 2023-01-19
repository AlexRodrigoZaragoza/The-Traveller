using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lr_Selector_Dificultad_1 : MonoBehaviour
{
 


    public int NumPuntos;
   public static bool Facil = false;
   public static bool Medio = false;
   public static bool Dificil = false;
    public GameObject[] JuegoF = new GameObject[9];
    public GameObject[] JuegoM = new GameObject[16];
    public GameObject[] JuegoD = new GameObject[25];
   

    

    

    private void Start()
    {
        NumPuntos = 0;
        CrearLineas();
    }

    void Update()
    {
      

    }

 
    public void CrearLineas()
    {
        // Genera el numero de puntos posibles

        if (Facil == true)
        {
           
            NumPuntos = Random.Range(2, 9);
           
        }

        else if (Medio == true)
        {
            
            NumPuntos = Random.Range(9, 16);
        }

        else if (Dificil == true)
        {
            
            NumPuntos = Random.Range(16, 25);
        }

        else
        {
            Debug.Log("NumPuntos no selecionada");
        }

    }
}
