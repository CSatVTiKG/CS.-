using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    
    static public int currentScore = 0;
    public int highScore=0;
    public Text scoreGT;
    private GameObject scoreGO;

    private void Start()
    {

        scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";

        if (PlayerPrefs.HasKey("HighScore")) { 
        highScore = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", highScore);
    }

    private void Update()
    {
        scoreGT.text = "Current Score: " + currentScore.ToString();

        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + highScore.ToString();

        if(highScore < currentScore)
        {
            highScore = currentScore;
        }

        if(highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }
}
