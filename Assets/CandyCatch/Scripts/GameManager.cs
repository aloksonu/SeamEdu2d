using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;


namespace CandyCatch
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public TextMeshProUGUI tmpScore;
        public TextMeshProUGUI tmpLives;
        //public GameObject gameOverPanel;
        public CanvasGroup _cgGameOver;
        private int score;
        private int lives;

        private bool gameOver;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            lives = 3;
            gameOver = false;
            tmpScore.text = score.ToString();
            tmpLives.text = lives.ToString();
            _cgGameOver.DOFade(0, 0f);
            _cgGameOver.interactable = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void IncrementScore()
        {
            if (!gameOver)
            {
                score++;
                tmpScore.text = score.ToString();
            }
        }

        public void DecreaseLife()
        {

            if (lives > 0)
            {
                lives--;
                tmpLives.text = lives.ToString();
            }
            else
            {
                gameOver = true;
                GameOver();
            }

        }

        public void GameOver()
        {
            PlayerController.instance.canMove = false;
            CandySpawner.instance.StopSpawanCandies();
            //gameOverPanel.SetActive(true);

            _cgGameOver.DOFade(1, 0.2f).OnComplete(() =>
            {
                _cgGameOver.interactable = true;
            });
        }
    }
}
