using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ganar_Puntos : MonoBehaviour
{

    public static int puntos, puntosfinal;
    public Text puntosText, puntosFinal;
    public RectSpawn Spawn, rt;
    public Juego_Numeros Corrutinas;
    public Menu_Pausa Pause;
    Audios Sonidos;


    Color m_MouseOverColor = Color.blue;
    Color m_OriginalColor;
    SpriteRenderer m_SpriteRenderer;




    //[] Text PuntosText;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_OriginalColor = m_SpriteRenderer.material.color;
        puntos = 0;
        puntosfinal = 0;
        //puntosText = GameObject.FindGameObjectWithTag("Puntuacion").GetComponent<Text>();
        Sonidos = FindObjectOfType<Audios>();
    }


    private void OnMouseDown()
    {

        if (gameObject.tag == "Buenos")
        {
            Sonidos.SeleccionAudio(2);
            Juego_Numeros.Acierta();
            Juego_Numeros.counterFacil++;

        }

        if (gameObject.tag == "Malo")
        {
            Sonidos.SeleccionAudio(1);
            Juego_Numeros.Falla();
        }

        Destroy(this.gameObject);

    }

    private void OnMouseOver()
    {

        m_SpriteRenderer.material.color = m_MouseOverColor;

    }

    void OnMouseExit()
    {
        m_SpriteRenderer.material.color = m_OriginalColor;

    }




}

