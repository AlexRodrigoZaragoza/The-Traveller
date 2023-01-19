using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaLinea : MonoBehaviour
{
    public GameObject linePrefab1, linePrefab2;
    private GameObject currentLine;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> fingerPositions = new List<Vector2>();




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
    }

    void CreateLine()
    {
        if (gameObject.tag == ("Rojo_inicio"))
        {
            // Llamamos a CreateLine una sola vez cuando empezamos a dibujar para crear currentLine. currentLine se visualizará porque tendrán un lineRenderer y tendrá colisión porque tendrá un edgeCollider
            currentLine = Instantiate(linePrefab1, Vector3.zero, Quaternion.identity);
            lineRenderer = currentLine.GetComponent<LineRenderer>();
            edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
            fingerPositions.Clear();
            // Como lineRenderer es una línea, necesitamos añadir dos puntos a fingerPositions para poder dibujarla sin errores
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Dibujamos una línea compuesta de dos puntos
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[1]);
            edgeCollider.points = fingerPositions.ToArray();
        }

        else if (gameObject.tag == ("Azul_inicio"))
        {
            // Llamamos a CreateLine una sola vez cuando empezamos a dibujar para crear currentLine. currentLine se visualizará porque tendrán un lineRenderer y tendrá colisión porque tendrá un edgeCollider
            currentLine = Instantiate(linePrefab2, Vector3.zero, Quaternion.identity);
            lineRenderer = currentLine.GetComponent<LineRenderer>();
            edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
            fingerPositions.Clear();
            // Como lineRenderer es una línea, necesitamos añadir dos puntos a fingerPositions para poder dibujarla sin errores
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Dibujamos una línea compuesta de dos puntos
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[1]);
            edgeCollider.points = fingerPositions.ToArray();

        }


    }


    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        // Convertimos el List de posiciones por las que ha ido pasando el dedo en la línea que vamos a ver
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        // Convertimos el List de posiciones por las que ha ido pasando el dedo en los puntos del edge collider
        edgeCollider.points = fingerPositions.ToArray();
    }
}


