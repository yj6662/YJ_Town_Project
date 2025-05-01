using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_GameManager : MonoBehaviour
{
    static F_GameManager gameManager;
    F_UIManager uiManager;
    private int bestScore = 0;
    private int currentScore = 0;

    private const string BestScoreKey = "BestScore";
    public string mainSceneName = "MainScene";

    public F_UIManager UIManager
    {
        get { return uiManager; }
    }
    public static F_GameManager Instance
    {
        get { return gameManager; }
    }


    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<F_UIManager>();

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.gameStartPanel.SetActive(true);
        Time.timeScale = 0f;

    }
    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        CheckBestScore();
        uiManager.SetRestart();
    }
    public void StartGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            currentScore = 0;
            uiManager.gameStartPanel.gameObject.SetActive(false);
            uiManager.scoreText.gameObject.SetActive(true);
            uiManager.UpdateScore(0);
        }
    }
    public void RestartGame()
    {
        SceneLoader.Instance.LoadFlappyBirdScene();
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadMainScene();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

    public void CheckBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);

            Debug.Log("New Best Score: " + bestScore);

            if(uiManager != null)
            {
                uiManager.UpdateBestScore(bestScore);
            }
        }
        else
        {
            uiManager.UpdateBestScore(bestScore);
        }

    }
}