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
        if (uiManager != null)
        {
            uiManager.gameStartPanel.SetActive(true);
        }
        Time.timeScale = 0f;

    }
    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 0f)
            {
                uiManager.gameStartPanel.SetActive(false);
                StartGame();
            }
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;

        Debug.Log("Game Over");
        CheckBestScore();
        uiManager.SetRestart();
    }
    private void StartGame()
    {
        Time.timeScale = 1f;
        currentScore = 0;
        uiManager.UpdateScore(currentScore);
        uiManager.UpdateBestScore(bestScore);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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