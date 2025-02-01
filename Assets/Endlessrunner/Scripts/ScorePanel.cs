using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScorePanel : MonoBehaviour
{
    public static ScorePanel instance;
    public TextMeshProUGUI tmpScore;
    private int score;

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
        tmpScore.text = score.ToString();
    }


    public void UpdateScore(int _score)
    {
        score += _score;
        tmpScore.text = score.ToString();
    }

}
