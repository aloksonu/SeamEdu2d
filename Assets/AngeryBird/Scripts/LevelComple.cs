using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComple : MonoBehaviour
{
    private Button nextLevelButton;
    private Button menuPanelButton;

    void Start()
    {
        nextLevelButton.onClick.AddListener(NextLevel);
        menuPanelButton.onClick.AddListener(MenuPanel);
    }


    void NextLevel()
    {

    }
    void MenuPanel()
    {

    }
}
