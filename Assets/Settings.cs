using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    public Toggle fullScreen, vSync;

    public List<ResItem> resolutions = new List<ResItem>();
    private static int selectedRes;

    public TMP_Text resolutionLabel;

    [SerializeField] AudioMixer myAudioMixer;

    public TMP_Text musicLabel, sfxLabel;

    public Slider musicSlider, sfxSlider;

    public static bool isOn;

    [SerializeField] float _multiplier = 30f;
   
    private void Start()
    {
        fullScreen.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vSync.isOn = false;
        }
        else
        {
            vSync.isOn = true;
        }

        bool foundRes = false;

        for(int i = 0; i<resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedRes = i;

                UpdateResLabel();
            }
        }
        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedRes = resolutions.Count - 1;

            UpdateResLabel();
        }

        float BGMvol = 0f;
        myAudioMixer.GetFloat("BGMVol", out BGMvol);
        musicSlider.value = PlayerPrefs.GetFloat("BGMVol", 1);
        myAudioMixer.SetFloat("BGMVol", Mathf.Log10(musicSlider.value) * _multiplier);

        float SFXvol = 0f;
        myAudioMixer.GetFloat("SFXVol", out SFXvol);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol", 1);
        myAudioMixer.SetFloat("SFXVol", Mathf.Log10(sfxSlider.value) * _multiplier);

        musicLabel.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();

        QualitySettings.SetQualityLevel(5);
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOn)
        {
            CloseSettings();
        }
    }

    public void DecreaseRes()
    {
        selectedRes--;
        if (selectedRes < 0)
        {
            selectedRes = 0;
        }

        UpdateResLabel();
    }
    public void IncreaseRes()
    {
        selectedRes++;
        if (selectedRes > resolutions.Count - 1)
        {
            selectedRes = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        if (vSync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullScreen.isOn);
    }
    public void SetBGMVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
        myAudioMixer.SetFloat("BGMVol", Mathf.Log10(musicSlider.value) * _multiplier);
        PlayerPrefs.SetFloat("BGMVol", musicSlider.value);
    }
    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();
        myAudioMixer.SetFloat("SFXVol", Mathf.Log10(sfxSlider.value) * _multiplier);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true);
        isOn = true;
        Debug.Log("Estoy ON");
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
        isOn = false;
    }



    [System.Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
    }


}
