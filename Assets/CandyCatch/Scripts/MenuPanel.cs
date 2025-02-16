using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CandyCatch
{
    public class MenuPanel : MonoBehaviour
    {
        public Button buttonPlay;
        public Button buttonExit;
        // Start is called before the first frame update
        void Start()
        {
            buttonPlay.onClick.AddListener(Play);
            buttonExit.onClick.AddListener(Exit);
        }
        private void OnDestroy()
        {
            buttonPlay.onClick.RemoveAllListeners();
            buttonExit.onClick.RemoveAllListeners();
        }
        public void Play()
        {
            SceneManager.LoadScene("CandyCatch");
        }

        public void Exit()
        {
         Application.Quit();
        }

    }
}
