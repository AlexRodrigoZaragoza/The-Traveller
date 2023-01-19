using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambios : MonoBehaviour
{
    public List<Escenas> Scenes = new List<Escenas>();
    public List<Escenas> RemovedScenes = new List<Escenas>();

    static int Suma;
    int Randome;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        Scenes.Add(new Escenas("jeje", Suma));
        Scenes.Add(new Escenas("numeros", Suma));
        Scenes.Add(new Escenas("Minijuego_Figuras", Suma));
        Scenes.Add(new Escenas("Facil", Suma));
        Scenes.Add(new Escenas("Minijuego_Sabueso", Suma));
        Scenes.Add(new Escenas("memory_escena", Suma));
        Scenes.Add(new Escenas("puzzle_escena", Suma));
        Scenes.Add(new Escenas("MinijuegoTangram", Suma));
        Scenes.Add(new Escenas("Katamino", Suma));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            CambiarEscena();

        }
    }

    void CambiarEscena()
    {
        Randome = Random.Range(0, Scenes.Count);

        Debug.Log(Scenes[Randome].Escena);
        Scenes[Randome].numVecesUsado++;    //Por si acaso para antes de terminar el ciclo (y necesita la info)

        RemovedScenes.Add(Scenes[Randome]);
        Scenes.RemoveAt(Randome);

        if (Scenes.Count <= 0)
        {
            Recharge();
        }
    }

    void Recharge()
    {
        while (RemovedScenes.Count > 0)
        {
            Scenes.Add(RemovedScenes[0]);
            RemovedScenes.RemoveAt(0);
        }

        Debug.Log("Recargando... " + Suma);
    }

    public void FinallyDestroy() //para destruir al terminar la run y volver al menú
    {
        Destroy(gameObject);
    }

    public void CambiarEscenaDeVerdad()
    {
        SceneManager.LoadScene("Otra");
    }
}
