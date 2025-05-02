using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager gameManager;
    private S_UIManager uiManager;
    public int bestScore = 0;
    public int currentScore = 0;
    public int bestCombo = 0;
    public int currentCombo = 0;

    private const string S_BestScoreKey = "BestScore";
    private const string S_BestComboKey = "BestCombo";

    public static S_GameManager Instance
    {
        get { return gameManager; }
    }
    public S_UIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<S_UIManager>();

        bestScore = PlayerPrefs.GetInt(S_BestScoreKey, 0);
        bestCombo = PlayerPrefs.GetInt(S_BestComboKey, 0);
        Time.timeScale = 0f;
    }

    private void Start()
    {
        uiManager.S_UpdateScore(0);
        uiManager.S_UpdateCombo(0);
    }
    public void S_GameOver()
    {
        Debug.Log("Game Over");
        S_CheckBestScore();
        S_CheckBestCombo();
        Time.timeScale = 0f;
        uiManager.S_GameOver();
    }

    public void S_StartGame()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            currentScore = 0;
            currentCombo = 0;
            uiManager.S_StartGame();
            uiManager.S_UpdateScore(0);
            uiManager.S_UpdateCombo(0);
        }
    }
    public void S_RestartGame()
    {
        SceneLoader.Instance.LoadTheStackScene();
    }
    public void S_ExitGame()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadMainScene();
    }

    public void S_AddScore(int score)
    {
        currentScore++;
        uiManager.S_UpdateScore(currentScore);
        S_CheckBestScore();
        currentCombo++;
        uiManager.S_UpdateCombo(currentCombo);
        S_CheckBestCombo();
    }
    public void S_ResetCombo()
    {
        currentCombo = 0;
        uiManager.S_UpdateCombo(currentCombo);
    }

    private void S_CheckBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(S_BestScoreKey, bestScore);
            uiManager.S_UpdateBestScore(bestScore);
        }
    }
    private void S_CheckBestCombo()
    {
        if (currentCombo > bestCombo)
        {
            bestCombo = currentCombo;
            PlayerPrefs.SetInt(S_BestComboKey, bestCombo);
            uiManager.S_UpdateBestCombo(bestCombo);
        }
    }
}