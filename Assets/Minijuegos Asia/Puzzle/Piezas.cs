using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas : MonoBehaviour
{
    int Identificador;
    public bool Colisiones = false;

    public bool puedeMoverse = true;

    public bool BuenaPosi = false;
    Vector3 posicioninicial;
    bool tesaliste;
    public List<string> Propiedades = new List<string>();
    public bool Colisiona;
    public bool yaMovido = false;
   int twice = 0;
    bool respawned = false;

    public bool correcto = false;
    public bool enSitio = false;

    Vector2 Result;


    private void Start()
    {
        //random posicion seguramente cambiar
        if (PuzzleManager.dificultad_puzzle == 1)
        {
            gameObject.transform.position = new Vector3(Random.Range(-5f, -1f), Random.Range(3f, 0f), gameObject.transform.position.z);
            
        }
        if (PuzzleManager.dificultad_puzzle == 2)
        {
            gameObject.transform.position = new Vector3(Random.Range(-5, -1), Random.Range(2, -2), gameObject.transform.position.z);
        }
        if (PuzzleManager.dificultad_puzzle == 3)
        {
            //funciona pero no tiene sentido los parámetros
            gameObject.transform.position = new Vector3(Random.Range(-6, 0), Random.Range(3, -2), gameObject.transform.position.z);
        }
        posicioninicial = gameObject.transform.position;
        puedeMoverse = true;
    }
    private void OnMouseDown()
    {
        if (puedeMoverse)
        {
            enSitio = false;
            Colisiones = false;
            Vector2 currentMouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currentLocation = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Result = currentLocation - currentMouseLocation;
        }
    }

    private void OnMouseDrag()
    {
        if (puedeMoverse)
        {
            Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = currentTouchPos + Result;
        }
    }

    private void OnMouseUp()
    {
        if (puedeMoverse)
        {
            Colisiones = true;
            twice = 0;
            if (tesaliste == true)
            {
                Respawn(gameObject, gameObject);
                tesaliste = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (twice <=2)
        {
            if (collision.gameObject.tag == "Piezas" && collision.gameObject.GetComponent<Piezas>().enSitio && Colisiones == true)
            {
                collision.GetComponent<Piezas>().Respawn(collision.gameObject, gameObject);
                respawned = true;
            }
            if (collision.gameObject.tag == "posis" && respawned)
            {
                collision.GetComponent<Posiciones>().ocupada = false;
            }
            if (collision.gameObject.tag == "posis" && collision.GetComponent<Posiciones>().ocupada == false && !correcto)
            {
                if (Colisiones == true)
                {
                    transform.position = collision.gameObject.transform.position;
                    collision.GetComponent<Posiciones>().visitante = gameObject;
                    yaMovido = true;
                    enSitio = true;
                    collision.GetComponent<Posiciones>().Check(this.gameObject);
                }
            }
            if (collision.gameObject.tag == "Limite_puzzle")
            {
                tesaliste = true;
            }
            twice++;
        }      
    }
    private void OnBecameInvisible()
    {
        tesaliste = true;
        
    }
    
    public void Respawn(GameObject otraPieza, GameObject estaPieza)
    {
        if (otraPieza.GetComponent<Piezas>().correcto == false)
        {
            gameObject.transform.position = posicioninicial;
            gameObject.GetComponent<Piezas>().enSitio = false;
        }
        else
        {
            estaPieza.transform.position = estaPieza.GetComponent<Piezas>().posicioninicial;
            estaPieza.GetComponent<Piezas>().enSitio = false;
        }
    }
}
