using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion_Nubes : MonoBehaviour
{
    public float velocidad = 10;
    
    void Update()
    {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - (Time.deltaTime * velocidad), gameObject.transform.position.y, gameObject.transform.position.z);  
    }
}
