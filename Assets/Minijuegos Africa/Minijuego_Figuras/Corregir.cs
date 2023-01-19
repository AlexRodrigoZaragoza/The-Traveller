using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corregir : MonoBehaviour
{
    public static int comprobation;
    public void Corregir_()
    {
        lr_Trazado.Puntos.Clear();
        lr_Trazado.Puntos2.Clear();
        lr_LineController.comprobar_ = lr_LineController.comprobar2_;
    }
}
