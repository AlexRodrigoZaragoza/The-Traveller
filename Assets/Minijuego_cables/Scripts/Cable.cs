using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cable : MonoBehaviour
{
    public Vector2 PosInicial;
    public LineRenderer LineR;

    public Vector3 PuntoFinal = new Vector3(-3.0f,3.0f,0.0f);
    public Vector3 PuntoInicial = new Vector3(6.0f, 0.0f, 0.0f);

    public Color DefaultColor;
    public Color ColorResaltado;
    
    private Collider2D  collider2D;

    public bool isDown = false;
    public bool Active = false;

    private static int lastPoint = 0;
    private static List<Vector3> adjPoints = new List<Vector3>();

    private static List<Vector3> Puntos = new List<Vector3>();


    void Start()
    {
        
            collider2D = GetComponent<Collider2D>();
        
        //LineR = GetComponent<LineRenderer>();
        LineR.positionCount = 0;
       // LineRenderer.Reset();
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))//sólo se debe permitir esto tres veces
        {
            Debug.Log("Espacio presionado");
            LineR.positionCount = 0;

           
            collider2D.enabled = true;
            Puntos.Clear();

          //Puntos= 0;
        }

        
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Boton")
        {
        
            PosInicial = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Puntos.Add(new Vector3(Mathf.Round(PosInicial.x * 10.0f) * 0.1f, Mathf.Round(PosInicial.y * 10.0f) * 0.1f, 0f));

            if (Vector3.Distance(Puntos[Puntos.Count - 1], Puntos[lastPoint]) <= 3.5f)
            {
                adjPoints.Add(Puntos[Puntos.Count - 1]);
                LineR.positionCount += 1;
                collider2D.enabled = false;
            }
            else
                Puntos.RemoveAt(Puntos.Count - 1);
            
            lastPoint = Puntos.Count - 1;

            for (int i = 0; i < adjPoints.Count; i++)
                LineR.SetPosition(i, adjPoints[i]);
/*
           if (adjPoints[/ultimapos/]=PuntoFinal) //Con esto busco comparar el "punto final" con el último punto en el que se ha hecho click, y deje de pintar pero la línea se mantenga.
            {
             Debug.Log("COMPLETADO");
            }
*/
        }
    }
}


