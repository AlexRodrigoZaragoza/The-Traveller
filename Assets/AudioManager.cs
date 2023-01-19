using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer myAudioMixer;
    float _multiplier = 30;
    public GameObject Settings;
    public GameObject NubesFondo;
    public GameObject NubesCerca;

    private void Start()
    {
        float BGMvol = 0f;
        myAudioMixer.GetFloat("BGMVol", out BGMvol);
        BGMvol = PlayerPrefs.GetFloat("BGMVol", 1);
        myAudioMixer.SetFloat("BGMVol", Mathf.Log10(BGMvol) * _multiplier);

        float SFXvol = 0f;
        myAudioMixer.GetFloat("SFXVol", out SFXvol);
        SFXvol = PlayerPrefs.GetFloat("SFXVol", 1);
        myAudioMixer.SetFloat("SFXVol", Mathf.Log10(SFXvol) * _multiplier);
    }

    private void Update()
    {

    }

    public void OpenSettings()
    {
        StartCoroutine("OpenningSettings");
    }

    IEnumerator OpenningSettings()
    {
        yield return new WaitForSeconds(1.5f);
        NubesFondo.SetActive(false);
        NubesCerca.SetActive(false);
        Settings.SetActive(true);
    }

    public void CloseSettings()
    {
        NubesFondo.SetActive(true);
        NubesCerca.SetActive(true);
        Settings.SetActive(false);
    }
}
