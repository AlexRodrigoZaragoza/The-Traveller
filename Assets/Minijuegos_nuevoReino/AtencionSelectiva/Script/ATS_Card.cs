using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATS_Card : MonoBehaviour
{
    //Variables cambiar TODA la imagen de forma random
    public string Background;
    public string Figure;
    public int numFigures;

    //Variable para cambiar la imagen de las figuras (el fondo es el propio gameobject)
    public Image myFigures;

    public GameObject Distributor;

    public bool Correct = false;
    public bool CantClick = false;

    public void SendInfo()
    {
        if (!CantClick)
        {
            Distributor.GetComponent<DistributeCards>().CheckCorrect(gameObject);
        }
    }

    public void ButtonClicked()
    {
        if (Correct)
        {
            StartCoroutine(GoodButton());
        }
        else
        {
            StartCoroutine(BadButton());
        }
    }
    IEnumerator GoodButton()
    {
        CantClick = true;
        gameObject.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator BadButton()
    {
        gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Image>().color = Color.white;

    }
}
