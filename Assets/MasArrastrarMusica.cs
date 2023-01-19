using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasArrastrarMusica : MonoBehaviour
{
    private AudioSource _audioSource;
    public static bool romper;
    public static bool usado;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);
        if (usado)
        {
            Destroy(this.gameObject);
        }

        usado = true;
        _audioSource = GetComponent<AudioSource>();
        if (romper == true)
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
        if (SceneManager.GetActiveScene().name == "ListaUsuarios" || SceneManager.GetActiveScene().name == "UsuarioInfo" || SceneManager.GetActiveScene().name == "SelectGameMode" || SceneManager.GetActiveScene().name == "LevelDif")
        {
            romper = false;
        }
        else
        {
            usado = false;
            Destroy(this.gameObject);
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
