using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Info : MonoBehaviour
{
    public string myColor = "none";
    public GameObject man;
    static bool firstDot = true;
    public bool done = false;
    public bool changed = false;
    public static float rango;

    /*
    public float ancholinea;
    public float depth = 5;
    private Vector3? lineastart = null;


    Color c1 = Color.red;
    Color c2 = Color.blue;
    Color c3 = Color.yellow;
    Color c4 = Color.black;
    Color c5 = Color.green;
    */

    void Start()
    {
        //Camera.main.GetComponent<Camera>();

        man = GameObject.Find("Manager");

        if (gameObject.tag == "Azul_inicio" || gameObject.tag == "Azul_final")
        {
            myColor = "Azul";
        }
        else if (gameObject.tag == "Verde_inicio" || gameObject.tag == "Verde_final")
        {
            myColor = "Verde";
        }
        else if (gameObject.tag == "Rojo_inicio" || gameObject.tag == "Rojo_final")
        {
            myColor = "Rojo";
        }
        else if (gameObject.tag == "Amarillo_inicio" || gameObject.tag == "Amarillo_final")
        {
            myColor = "Amarillo";
        }
        else if (gameObject.tag == "Negro_inicio" || gameObject.tag == "Negro_final")
        {
            myColor = "Negro";
        }

        ReloadColors();
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButton(0) && !done)
        {
            if (myColor == "none" && firstDot)
            {
                //no hace na, pero para que no salte error
            }
            else if (myColor != "none" && firstDot)
            {
                CircleManager.changeColor = myColor;
                firstDot = false;
                CircleManager.posis.Add(this.gameObject);
                done = true;
            }
            else if (Vector3.Distance(CircleManager.posis[CircleManager.posis.Count - 1].transform.position, this.gameObject.transform.position) <= rango && !firstDot)  //si el punto está a 3.5f, se puede unir
            {
                Debug.Log((Vector3.Distance(CircleManager.posis[CircleManager.posis.Count - 1].transform.position, this.gameObject.transform.position)));

                if (myColor == "none")
                {
                    myColor = CircleManager.changeColor;
                    changed = true;
                }
                CircleManager.posis.Add(this.gameObject);
                done = true;
            }
            ReloadColors();
        }
    }

    private void OnMouseUp()
    {

        firstDot = true;
        CircleManager.changeColor = "none";

        if (CircleManager.posis.Count > 0)
        {
            Debug.Log(CircleManager.posis.Count);

            if (CircleManager.posis[0].tag == myColor + "_final" && CircleManager.posis[CircleManager.posis.Count - 1].tag == myColor + "_inicio" ||
                CircleManager.posis[0].tag == myColor + "_inicio" && CircleManager.posis[CircleManager.posis.Count - 1].tag == myColor + "_final")
            {
                //bloquear color (BIEN)
                Debug.Log("bueno");
                CircleManager.numColors++;
                man.GetComponent<CircleManager>().Check();
            }
            else
            {
                CircleManager.ResetList();
                Debug.Log("me reseteo");
            }
            CircleManager.posis.Clear();
        }
    }

    public void ReloadColors()
    {
        //cambiar color a myColor
        if (myColor == "none")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (myColor == "Azul")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (myColor == "Verde")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (myColor == "Rojo")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (myColor == "Amarillo")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (myColor == "Negro")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }

    }

   

}
