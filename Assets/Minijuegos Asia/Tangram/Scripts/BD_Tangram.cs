using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD_Tangram : MonoBehaviour
{
    string tiempoFinal_tangram;
    // Update is called once per frame
    void Update()
    {
        if (SombrasTangram.piezaCompletada == true)
        {
            tiempoFinal_tangram = SombrasTangram.tiempo.ToString();
        }
    }
}
