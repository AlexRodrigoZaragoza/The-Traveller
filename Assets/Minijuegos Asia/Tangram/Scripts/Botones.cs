using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public Button Comprobar;
    public Button Resetear;
    

    // Update is called once per frame
    void Update()
    {
        if (SombrasTangram.piezaCompletada == true)
        {
            Comprobar.interactable = false;
            Resetear.interactable = false;
        }  
    }
}
