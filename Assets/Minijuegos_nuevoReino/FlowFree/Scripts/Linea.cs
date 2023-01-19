using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
/*

    public float ancholinea;
    public float depth = 5;
    private Vector3? lineastart = null;

    Color c1 = Color.red;
    Color c2 = Color.blue;
    Color c3 = Color.yellow;
    Color c4 = Color.black;
    Color c5 = Color.green;




    private void Start()
    {
        Camera.main.GetComponent<Camera>();

    }

    private void Update()
    {


    }

    public Vector3? GetMouseCameraPoint()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * depth;
    }


    public void OnMouseDown()
    {
        if (gameObject.tag == "Azul_inicio" || gameObject.tag == "Azul_final" || gameObject.tag == "Rojo_inicio" || gameObject.tag == "Rojo_final" || gameObject.tag == "Negro_inicio" || gameObject.tag == "Negro_final" || gameObject.tag == "Verde_inicio" || gameObject.tag == "Verde_final" || gameObject.tag == "Amarillo_inicio" || gameObject.tag == "Amarillo_final")
        {
            lineastart = GetMouseCameraPoint();

        }

    }

    public void OnMouseUp()
    {
        if (gameObject.tag == "Azul_inicio" || gameObject.tag == "Azul_final")
        {
            if (!lineastart.HasValue)
            {
                return;
            }
            var lineEndPoint = GetMouseCameraPoint();           //HASTA DONDE SE CREA LA LINEA
            var gameObject = new GameObject();                  //CREAMOS LA LINEA
            var lineRenderer = gameObject.AddComponent<LineRenderer>();         //AÑADIMOS EL COMPONENTE DEL LINERENDERER

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));       //CAMBIAR EL MATERIAL



            lineRenderer.SetColors(c2, c2);             //COLOR DEL MATERIAL QUE QUEREMOS
            lineRenderer.numCapVertices = 10;


            lineRenderer.SetPositions(new Vector3[] { lineastart.Value, lineEndPoint.Value });

        }

        if (gameObject.tag == "Rojo_inicio" || gameObject.tag == "Rojo_final")
        {
            if (!lineastart.HasValue)
            {
                return;
            }
            var lineEndPoint = GetMouseCameraPoint();           //HASTA DONDE SE CREA LA LINEA
            var gameObject = new GameObject();                  //CREAMOS LA LINEA
            var lineRenderer = gameObject.AddComponent<LineRenderer>();         //AÑADIMOS EL COMPONENTE DEL LINERENDERER

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));       //CAMBIAR EL MATERIAL



            lineRenderer.SetColors(c1, c1);             //COLOR DEL MATERIAL QUE QUEREMOS
            lineRenderer.numCapVertices = 10;


            lineRenderer.SetPositions(new Vector3[] { lineastart.Value, lineEndPoint.Value });

        }

        if (gameObject.tag == "Negro_inicio" || gameObject.tag == "Negro_final")
        {
            if (!lineastart.HasValue)
            {
                return;
            }
            var lineEndPoint = GetMouseCameraPoint();           //HASTA DONDE SE CREA LA LINEA
            var gameObject = new GameObject();                  //CREAMOS LA LINEA
            var lineRenderer = gameObject.AddComponent<LineRenderer>();         //AÑADIMOS EL COMPONENTE DEL LINERENDERER

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));       //CAMBIAR EL MATERIAL



            lineRenderer.SetColors(c4, c4);             //COLOR DEL MATERIAL QUE QUEREMOS
            lineRenderer.numCapVertices = 10;


            lineRenderer.SetPositions(new Vector3[] { lineastart.Value, lineEndPoint.Value });

        }

        if (gameObject.tag == "Verde_inicio" || gameObject.tag == "Verde_final")
        {
            if (!lineastart.HasValue)
            {
                return;
            }
            var lineEndPoint = GetMouseCameraPoint();           //HASTA DONDE SE CREA LA LINEA
            var gameObject = new GameObject();                  //CREAMOS LA LINEA
            var lineRenderer = gameObject.AddComponent<LineRenderer>();         //AÑADIMOS EL COMPONENTE DEL LINERENDERER

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));       //CAMBIAR EL MATERIAL



            lineRenderer.SetColors(c5, c5);             //COLOR DEL MATERIAL QUE QUEREMOS
            lineRenderer.numCapVertices = 10;


            lineRenderer.SetPositions(new Vector3[] { lineastart.Value, lineEndPoint.Value });

        }

        if (gameObject.tag == "Amarillo_inicio" || gameObject.tag == "Amarillo_final")
        {
            if (!lineastart.HasValue)
            {
                return;
            }
            var lineEndPoint = GetMouseCameraPoint();           //HASTA DONDE SE CREA LA LINEA
            var gameObject = new GameObject();                  //CREAMOS LA LINEA
            var lineRenderer = gameObject.AddComponent<LineRenderer>();         //AÑADIMOS EL COMPONENTE DEL LINERENDERER

            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));       //CAMBIAR EL MATERIAL



            lineRenderer.SetColors(c3, c3);             //COLOR DEL MATERIAL QUE QUEREMOS
            lineRenderer.numCapVertices = 10;


            lineRenderer.SetPositions(new Vector3[] { lineastart.Value, lineEndPoint.Value });

        }

    }

    */
}
