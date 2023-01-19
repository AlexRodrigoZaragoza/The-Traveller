using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroys : MonoBehaviour
{
    public GameObject[] colmena;
    int randoms;
    // Start is called before the first frame update
    void Start()
    {
        colmena= GameObject.FindGameObjectsWithTag("prueba");

       for(int i = 0; i < 5; i++)
        {
            Destroy(colmena[Random.Range(0, colmena.Length)]);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
