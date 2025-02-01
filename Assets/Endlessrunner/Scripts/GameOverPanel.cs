using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMenu;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        buttonRestart.onClick.AddListener(RestartGame);
        buttonMenu.onClick.AddListener(Menu);
        audioManager = AudioManager.instance;
    }
    private void OnDestroy()
    {
        buttonRestart.onClick.RemoveAllListeners();
        buttonMenu.onClick.RemoveAllListeners();
    }
    public void RestartGame()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        SceneManager.LoadScene("EndRunner");
    }
    public void Menu()
    {
        audioManager.PlaySFX(audioManager.buttonClickClip);
        SceneManager.LoadScene("EndRunnerMenu");
    }
}
