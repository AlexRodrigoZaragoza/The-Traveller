using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Encaja;
    public bool EncajaArr;
    public bool EncajaAba;
    public bool EncajaDer;
    public bool EncajaIzq;
    public GameObject padre;
    private void OnMouseDown()
    {
        EncajaAba = true;
        EncajaArr = true;
        EncajaDer = true;
        EncajaIzq = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (padre.GetComponent<Piezas>().Colisiones==true)
        {

            padre.GetComponent<Piezas>().Colisiona = true;



            /*if (gameObject.tag == "Punta_Arr")
            {

                if (collision.gameObject.tag == "Hueco_Aba"&& collision.gameObject.tag == "Piezas")
                {
                    //EncajaArr = true;
                }
                else if (collision.gameObject.tag == "Piezas"&& collision.gameObject.tag != "Hueco_Aba")
                {
                    //EncajaArr = false;
                }

            }
            if (gameObject.tag == "Punta_Der")
            {

                if (collision.gameObject.tag == "Hueco_Izq"&&collision.gameObject.tag == "Piezas")
                {
                    //EncajaDer = true;
                }
                else if (collision.gameObject.tag == "Piezas" && collision.gameObject.tag != "Hueco_Izq")
                {
                    //EncajaDer = false;
                }

            }
            if (gameObject.tag == "Punta_Izq")
            {

                if (collision.gameObject.tag == "Hueco_Der" && collision.gameObject.tag == "Piezas")
                {
                   // EncajaIzq = true;
                }
                else if (collision.gameObject.tag == "Piezas" && collision.gameObject.tag != "Hueco_Der")
                {
                    //EncajaIzq = false;
                }

            }
            if (gameObject.tag == "Punta_Aba")
            {

                if (collision.gameObject.tag == "Hueco_Arr" && collision.gameObject.tag == "Piezas")
                {
                    //EncajaAba = true;
                }
                else if (collision.gameObject.tag == "Piezas" && collision.gameObject.tag != "Hueco_Arr")
                {
                   //EncajaAba = false;
                }

            }
            if (EncajaAba != true || EncajaArr != true || EncajaDer != true || EncajaIzq != true)
            {
                //Encaja = false;
                //Debug.Log("no quepo profe");
            }
            else
            {
                //Encaja = true;
            }
            //Debug.Log(Encaja+"Encaja");
            */
        }

       
    }
    
}
