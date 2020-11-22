using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //스코어 매니져 싱글톤 만들기
    public static ScoreManager Instance;

    private void Awake() => Instance = this;
    //private void Awake() =>TEST();
    //private void Awake()
    //{
    //    Instance = this;
    //TEST();
    //}
    // Start is called before the first frame update

    public Text ScoreTxt;
    public Text HighScoreTxt;
    public TextMeshProUGUI textTxt;
    int score = 0;
    int highScore = 0;
    void Start()
    {
        //하이스코어 불러오기
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreTxt.text = "HighScore : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            HighScoreTxt.text = "HighScore : " + highScore;
        }
    }

    public void AddScore()
    {
        score++;
        ScoreTxt.text = "Score : " + score;
        
    }
    public void AddBossScore()
    {
        score += 20;
        ScoreTxt.text = "Score : " + score;
    }
}