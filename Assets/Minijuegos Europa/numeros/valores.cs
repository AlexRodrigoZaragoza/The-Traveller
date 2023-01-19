using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class valores : MonoBehaviour
{
    public  int valor;
    public GameObject manager;
    public Sprite oro;
    public Sprite cobre;
    public Sprite plata;
    Image imagen;
    public static bool acertare, perdere;
    // Start is called before the first frame update
    void Start()
    {
        imagen = gameObject.GetComponent<Image>();

        int moneda = Random.Range(0, 3);
        switch (moneda)
        {
            case 0:
                
                imagen.sprite = oro;
                break;
            case 1:
                imagen.sprite = cobre;
                break;
            case 2:
                imagen.sprite = plata;
                break;
        }
            
    }
    public void al_clicar()
    {
        if (numeros.parateh == false)
        {
            musica_numeros.romper_numeros = true;

            if (valor == numeros.elegido)
            {
                numeros.numero_aciertos++;
                numeros.acertar++;
                acertare = true;
            }
            else
            {
                if (numeros.numero_aciertos > 0)
                {
                    numeros.numero_aciertos--;

                }
                numeros.acertar++;
                perdere = true;
            }
        }
        
    }

}
