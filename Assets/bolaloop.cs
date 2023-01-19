using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bolaloop : MonoBehaviour
{
    private AudioSource _audioSource;
    public static bool romper;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (romper == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            romper = true;

        }

    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "ListaUsuarios"|| SceneManager.GetActiveScene().name == "UsuarioInfo"|| SceneManager.GetActiveScene().name == "SelectGameMode")
        {
            romper = false;
        }
        else
        {
            romper = false;
            Destroy(this.gameObject);
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
