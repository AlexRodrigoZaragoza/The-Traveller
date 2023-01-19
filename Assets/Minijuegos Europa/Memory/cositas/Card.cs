using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int cardpair;
    public Image imagen;
    
    public GameObject distribuidor;
    public bool activo = false;
    public static bool canPress = true; 
    
    void Start()
    {
        imagen = gameObject.GetComponent<Image>();
    }
    public void Click()
    {
            if (canPress == true)
            { 
                if (activo == false)
                {
                    distribuidor.GetComponent<CardChoose>().HacerClick();
                    StartCoroutine("GirarCarta");
                    distribuidor.GetComponent<CardChoose>().cartas_giradas.Add(cardpair);

                    activo = true;
                }
            if (distribuidor.GetComponent<CardChoose>().cartas_giradas.Count >= 2) //gira 2 cartas
            {
                distribuidor.GetComponent<CardChoose>().StartCoroutine("Comprobar");
            }
        }

    }

    public IEnumerator GirarCarta()
    {
        imagen.sprite = distribuidor.GetComponent<CardChoose>().images[cardpair];
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator NoGirarCarta()
    {
        imagen.sprite = distribuidor.GetComponent<CardChoose>().images[0];
        activo = false;
        yield return new WaitForSeconds(0.1f);
    }
}
