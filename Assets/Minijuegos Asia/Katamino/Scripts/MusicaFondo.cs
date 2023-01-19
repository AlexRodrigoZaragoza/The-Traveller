using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    private AudioSource _audioSource;
    public static bool romperkata;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (romperkata == true)
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
        if (SceneManager.GetActiveScene().name == "InicioKatamino" || SceneManager.GetActiveScene().name == "Katamino1" || SceneManager.GetActiveScene().name == "Katamino2" || SceneManager.GetActiveScene().name == "Katamino3")
        {
            romperkata = false;
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
