using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_GameManager : MonoBehaviour
{
    public static F_GameManager gameManager;
    private F_UIManager uiManager;

    private int bestScore = 0;
    private int currentScore = 0;

    private const string F_BestScoreKey = "BestScore";

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

        bestScore = PlayerPrefs.GetInt(F_BestScoreKey, 0);
        uiManager.gameStartPanel.SetActive(true);
        Time.timeScale = 0f;

    }
    private void Start()
    {
        uiManager.F_UpdateScore(0);
    }
    public void F_GameOver()
    {
        Debug.Log("Game Over");
        F_CheckBestScore();
        uiManager.F_SetRestart();
    }
    public void F_StartGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            currentScore = 0;
            uiManager.gameStartPanel.gameObject.SetActive(false);
            uiManager.scoreText.gameObject.SetActive(true);
            uiManager.F_UpdateScore(0);
        }
    }
    public void F_RestartGame()
    {
        F_StartGame();
    }

    public void F_ExitGame()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadMainScene();
    }

    public void F_AddScore(int score)
    {
        currentScore += score;
        uiManager.F_UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

    public void F_CheckBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(F_BestScoreKey, bestScore);

            Debug.Log("New Best Score: " + bestScore);

            if(uiManager != null)
            {
                uiManager.F_UpdateBestScore(bestScore);
            }
        }
        else
        {
            uiManager.F_UpdateBestScore(bestScore);
        }

    }
}