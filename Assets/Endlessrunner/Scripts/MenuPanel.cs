using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonExit;
    public Button buttonSetting;
    public GameObject MenuPanelGO;
    public GameObject SettingPanelGO;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        buttonPlay.onClick.AddListener(Play);
        buttonExit.onClick.AddListener(Exit);
        buttonSetting.onClick.AddListener(Setting);
    }
    private void OnDestroy()
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonExit.onClick.RemoveAllListeners();
        buttonSetting.onClick.RemoveAllListeners();
    }

    private void Play()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        SceneManager.LoadScene("EndRunner");  
    }
    private void Exit()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        Application.Quit();
    }
    private void Setting()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        SettingPanelGO.SetActive(true);
        MenuPanelGO.SetActive(false);
    }
}
