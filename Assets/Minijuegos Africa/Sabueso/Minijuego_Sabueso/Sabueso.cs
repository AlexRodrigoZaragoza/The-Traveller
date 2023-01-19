using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sabueso : MonoBehaviour
{
    private AudioSource _audioSource;
    public static bool RompeR;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (RompeR == true)
        {
            Destroy(this.gameObject);
        }

    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Previa" || SceneManager.GetActiveScene().name == "Minijuego_Sabueso")
        {
            RompeR = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
