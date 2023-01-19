using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColmenaSpawn : MonoBehaviour
{
    public GameObject colmena,add5;
    public static int Limitador;
    public int limites;
    public Text valor;
    public static bool parar=true;
    int random;
    void Start()
    {

        if (limites == 5&& parar ==true)
        {
            Instantiate(add5, new Vector3(gameObject.transform.position.x - 37.25f, gameObject.transform.position.y + 20, 0), Quaternion.identity);
            Instantiate(add5, new Vector3(gameObject.transform.position.x + 37.25f, gameObject.transform.position.y + 20, 0), Quaternion.identity);
            parar = false;
        }


        valor.transform.position=gameObject.transform.position;
        random = Random.Range(1, 6);
        valor.text = ""+ random; 

        GameObject Derecha, izquierda, AD, AI, ABD, ABI;

        if (Limitador < 5)
        {
            if (gameObject.tag != "AI" && gameObject.tag != "Izquierda" && gameObject.tag != "ABI")
            {
                Derecha = (Instantiate(colmena, new Vector3(gameObject.transform.position.x + 25, gameObject.transform.position.y, 0), Quaternion.identity)); //Derecha
                Derecha.tag = "Derecha";
            }
            
            if (gameObject.tag != "AD" && gameObject.tag != "Derecha" && gameObject.tag != "ABD")
            {
                izquierda=(Instantiate(colmena, new Vector3(gameObject.transform.position.x + -25, gameObject.transform.position.y, 0), Quaternion.identity)); //Izquierda
                izquierda.tag = "Izquierda";
            }

            if (gameObject.tag != "AI" && gameObject.tag != "Izquierda" && gameObject.tag != "ABI")
            {
                AD = (Instantiate(colmena, new Vector3(gameObject.transform.position.x + 12.5f, gameObject.transform.position.y + 20, 0), Quaternion.identity)); //Arriba Derecha
                AD.tag = "AD";
            }
                
            if(gameObject.tag != "AD" && gameObject.tag != "Derecha" && gameObject.tag != "ABD")
            {
                AI = (Instantiate(colmena, new Vector3(gameObject.transform.position.x + -12.5f, gameObject.transform.position.y + 20, 0), Quaternion.identity)); //Arriba Izquierda
                AI.tag = "AI";
            }

            if (gameObject.tag != "AI" && gameObject.tag != "Izquierda"&& gameObject.tag != "ABI")
            {
                ABD = (Instantiate(colmena, new Vector3(gameObject.transform.position.x + 12.5f, gameObject.transform.position.y + -20, 0), Quaternion.identity)); //Abajo Derecha
                ABD.tag = "ABD";
            }

            if (gameObject.tag != "AD"&& gameObject.tag != "Derecha"&&gameObject.tag != "ABD")
            {
                ABI = (Instantiate(colmena, new Vector3(gameObject.transform.position.x + -12.5f, gameObject.transform.position.y + -20, 0), Quaternion.identity)); //Abajo Izquierda
                ABI.tag = "ABI";
            }
                
        }
        Limitador++;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            Destroy(collision.gameObject);
        
       //-30 20
    }
    private void OnMouseDown()
    {
        random--;
        valor.text = "" + random;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
