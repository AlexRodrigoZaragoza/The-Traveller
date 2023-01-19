using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musica_numeros : MonoBehaviour
{
    private AudioSource _audioSource;
    public static bool romper_numeros;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (romper_numeros == true)
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
        if (SceneManager.GetActiveScene().name!="numeros")
        {
            Destroy(this.gameObject);
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
