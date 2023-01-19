using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Objetos : MonoBehaviour
{
    public float RadioCirculo = 1;
    public GameObject[] Targets = new GameObject[3];
    public GameObject prefab_pelota;
    public GameObject prefab_cuadrado;
    public Sprite[] Malos = new Sprite[27];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjectBueno() //NIVEL FACIL
    {
        for (int i = 0; i <  1; i++)
        {                 
                Vector2 randomPos = Random.insideUnitCircle * RadioCirculo;
                int aleatorio = Random.Range(0, 3);
                GameObject x = Instantiate(Targets[aleatorio], randomPos, Quaternion.identity);
                Destroy(x, 3f);                     
        }

    }

    public void SpawnObjectMalo() // NIVEL FACIL
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * RadioCirculo;
            int aleatorio = Random.Range(0, 2);
            Sprite y = Instantiate(Malos[aleatorio], randomPos, Quaternion.identity);
            Destroy(y, 3f);
        }
    }
}
