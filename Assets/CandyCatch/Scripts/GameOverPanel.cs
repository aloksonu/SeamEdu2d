using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CandyCatch
{
    public class GameOverPanel : MonoBehaviour
    {

        public Button buttonRestart;
        public Button buttonMenu;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void Restart()
        {
            SceneManager.LoadScene("CandyCatch");
        }

        public void Menu()
        {
            SceneManager.LoadScene("CandyMenu");
        }
    }
}
