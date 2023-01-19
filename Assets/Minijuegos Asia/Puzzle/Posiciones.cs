using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posiciones : MonoBehaviour
{
    public GameObject manager;

    public bool ocupada=false;
    bool unaVez = true;

    public GameObject visitante;
    // Start is called before the first frame update

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == visitante)
        {
            ocupada = false;
            collision.GetComponent<Piezas>().BuenaPosi = false;          
        }
        collision.GetComponent<Piezas>().yaMovido = false;
    }

    public void Check(GameObject pieza)
    {
        ocupada = true;

        if (pieza.name == "Pieza_" + gameObject.name && unaVez)
        {
            manager.GetComponent<PuzzleManager>().puntos++;
            manager.GetComponent<PuzzleManager>().texto.text = "" + manager.GetComponent<PuzzleManager>().puntos;
            pieza.GetComponent<Piezas>().puedeMoverse = false;
            pieza.GetComponent<Piezas>().correcto = true;
            if (manager.GetComponent<PuzzleManager>().puntos == 9)
            {
                //Debug.Log("espera 9");
            }
            unaVez = false;
        }
       
    }
}
