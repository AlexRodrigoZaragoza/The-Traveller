using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RectSpawn : MonoBehaviour
{

    public RectTransform rt;


    public GameObject[] Numeros = new GameObject[9];
    public GameObject[] AbecedarioEntero = new GameObject[27];
    public GameObject[] Vocales = new GameObject[5];

    //private Vector3[] positions = new Vector3[3];
    private List<Vector3> positions = new List<Vector3>();



    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region DificultadFacil
    public void SpawnDeObjetosBuenos()
    {
        positions.Clear();

        for (int i = 0; i < 3; i++)
        {
            int aleatorio = Random.Range(0, Numeros.Length);

            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            /*while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;*/

            GameObject x = Instantiate(Numeros[aleatorio], random_p, Quaternion.identity);
            //positions[0] = x.transform.position;
            positions.Add(x.transform.position);

            Destroy(x, 10f);

        }

    }

    public void SpawnObjectMalo()
    {
        positions.Clear();

        for (int i = 0; i < 4; i++)
        {
            int aleatorio = Random.Range(0, AbecedarioEntero.Length);
            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;


            GameObject y = Instantiate(AbecedarioEntero[aleatorio], random_p, Quaternion.identity);
            //positions[i] = y.transform.position;
            positions.Add(y.transform.position);

            Destroy(y, 10f);

        }

    }

    #endregion

    #region DificultadNormal
    public void SpawnDeObjetosBuenosNormal()
    {
        positions.Clear();

        for (int i = 0; i < 3; i++)
        {
            int aleatorio = Random.Range(0, Vocales.Length);

            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            /*while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;*/

            GameObject x = Instantiate(Vocales[aleatorio], random_p, Quaternion.identity);
            //positions[0] = x.transform.position;
            positions.Add(x.transform.position);
            Destroy(x, 7f);
        }

    }

    public void SpawnObjectMalosNormal()
    {
        positions.Clear();

        for (int i = 0; i < 5; i++)
        {
            int aleatorio = Random.Range(0, Numeros.Length);
            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;


            GameObject y = Instantiate(Numeros[aleatorio], random_p, Quaternion.identity);
            //positions[i] = y.transform.position;
            positions.Add(y.transform.position);
            Destroy(y, 7f);
        }
    }

    #endregion

    #region DificultadDificil

    public void SpawnDeObjetosBuenosDificil()
    {
        positions.Clear();

        for (int i = 0; i < 2; i++)
        {
            int aleatorio = Random.Range(0, AbecedarioEntero.Length);

            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            /*while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;*/

            GameObject x = Instantiate(AbecedarioEntero[aleatorio], random_p, Quaternion.identity);
            //positions[0] = x.transform.position;
            positions.Add(x.transform.position);
            Destroy(x, 7f);
        }

    }

    public void SpawnObjectMalosDificil()
    {
        positions.Clear();

        for (int i = 0; i < 9; i++)
        {
            int aleatorio = Random.Range(0, Numeros.Length);
            Vector3 random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;

            while (!PosicionBuena(random_p))
                random_p = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax), 0) + rt.transform.position;


            GameObject y = Instantiate(Numeros[aleatorio], random_p, Quaternion.identity);
            //positions[i] = y.transform.position;
            positions.Add(y.transform.position);
            Destroy(y, 7f);
        }
    }

    #endregion




    private bool PosicionBuena(Vector3 newP)
    {
        bool posicion_buena = true;

        for (int i = 0; i < positions.Count; i++)
        {

            if (Vector3.Distance(newP, positions[i]) < 250)
                return false;
        }

        return posicion_buena;

    }


}
