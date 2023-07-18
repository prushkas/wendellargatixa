using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public TMPro.TextMeshProUGUI healtText;

    public int score;
    public TMPro.TextMeshProUGUI scoreText;

    public int totalScore;

    public static GameController instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UptadeScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void UpdateLives(int value)
    {
        healtText.text = "x" + value.ToString();
    }
}
