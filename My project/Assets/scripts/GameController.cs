using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public TMPro.TextMeshProUGUI healtText;
    public TMPro.TextMeshProUGUI mainLifesText;

    public int score;
    public TMPro.TextMeshProUGUI scoreText;

    public GameObject pauseObj;
    public GameObject gameOverObj;
    
    public int totalScore;

    public static GameController instance;

    private bool isPaused;
    
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
        PauseGame();
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
    
    public void UpdateMainLives(int value)
    {
        mainLifesText.text = "x" + value.ToString();
    }
    
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
