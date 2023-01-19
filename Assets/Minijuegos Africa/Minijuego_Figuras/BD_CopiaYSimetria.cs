using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD_CopiaYSimetria : MonoBehaviour
{
    public static string Tiempo_tardado;

    public static void datos()
    {
        Tiempo_tardado = "" + lr_LineController.tiempo;
    }
}
