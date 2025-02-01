using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer myMixter;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button buttonBack;
    public GameObject MenuPanelGO;
    public GameObject SettingPanelGO;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        buttonBack.onClick.AddListener(ButtonBack);
        // Load saved volume value (optional)
        //float savedmusicVolume = PlayerPrefs.GetFloat("music");
       // float savedSFXVolume = PlayerPrefs.GetFloat("SFX");
       // musicSlider.value = savedmusicVolume;
       // sfxSlider.value = savedSFXVolume;

        SetMusicVolume();
        SetSFXVolume();
    }

    private void OnDestroy()
    {
        buttonBack.onClick.RemoveAllListeners();
    }
    private void ButtonBack()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        MenuPanelGO.SetActive(true);
        SettingPanelGO.SetActive(false);
    }

    public void SetMusicVolume()
    {
        float volume = Mathf.Log10(musicSlider.value) * 20;//musicSlider.value;
        myMixter.SetFloat("music", volume);
        PlayerPrefs.SetFloat("music", volume);
    }

    public void SetSFXVolume()
    {
        float volume = Mathf.Log10(sfxSlider.value) * 20; //sfxSlider.value;
        myMixter.SetFloat("SFX", volume);
        // Save volume setting
        PlayerPrefs.SetFloat("SFX", volume);
    }
}
