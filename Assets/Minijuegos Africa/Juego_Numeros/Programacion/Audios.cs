using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{

    [SerializeField] AudioClip[] sonidos;

    AudioSource controlAudio;
    // Start is called before the first frame update
    void Start()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeleccionAudio(int indice)
    {
        controlAudio.PlayOneShot(sonidos[indice]);
    }
}
