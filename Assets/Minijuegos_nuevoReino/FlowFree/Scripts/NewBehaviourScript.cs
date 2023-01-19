using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private LineRenderer linea; //No se la diferencia entre protected o private, si da problemas, se cambia.
    private Vector3 Direction;
    private Vector3 Position;
    private bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        linea = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            changeDirection(1f, 0f);
            Debug.Log("Derecha");
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            changeDirection(-1f, 0);
            Debug.Log("Izquierda");
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            changeDirection(0f, 1f);
            Debug.Log("Arriba");
        }

        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            changeDirection(0f, -1f);
            Debug.Log("Abajo");
        }

        else
            Pressed = false;

        Position += Direction * 20f * Time.deltaTime;

        linea.SetPosition(linea.positionCount - 1, Position);


    }

    private void changeDirection(float x, float z)
    {
        if (!Pressed)
        {
            linea.positionCount++;
            Direction.x = x;
            Direction.z = z;
            Pressed = true;
        }

    }
}
