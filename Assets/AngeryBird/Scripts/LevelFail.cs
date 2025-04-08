using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFail : MonoBehaviour
{
    Button retryButton;
    Button menuPanelButton;
    void Start()
    {
        retryButton.onClick.AddListener(RetryLevel);
        menuPanelButton.onClick.AddListener(MenuPanel);
    }

    void RetryLevel()
    {

    }
    void MenuPanel()
    {

    }

}
