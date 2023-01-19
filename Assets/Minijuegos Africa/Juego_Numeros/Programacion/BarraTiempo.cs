using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraTiempo : MonoBehaviour
{

    public Image Barra;

    float TiempoMaximo;
    public static float TiempoRestante;  //Static y public 


    public Juego_Numeros Timer;

    // Start is called before the first frame update
    void Start()
    {

        Barra.GetComponent<Image>();
     
        switch (Juego_Numeros.Dif)
        {
            case 1:
                TiempoMaximo = 10;
                break;
            case 2:
                TiempoMaximo = 7;
                break;
            case 3:
                TiempoMaximo = 7;
                break;
            default:
                break;
        }

        TiempoRestante = TiempoMaximo;

    }

    // Update is called once per frame
    void Update()
    {

        if (Juego_Numeros.avocadowashere == true) //He creado un bool el cual cuando empieza la partida se active para q empiece a la vez q el juego. Y he quitado el while
        {
            if (TiempoRestante >= 0 && TiempoMaximo > 5)
            {
                TiempoRestante -= Time.deltaTime;
                Barra.fillAmount = TiempoRestante / TiempoMaximo;

                if (TiempoRestante < 0)
                {
                    TiempoRestante = TiempoMaximo;
                }

                if (Timer.SinTiempo < 0)
                {
                    TiempoMaximo = 0;
                    TiempoRestante = 0;
                }

            }

            
        }
      
    }


    




}
