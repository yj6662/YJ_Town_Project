using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestComboText;
    public void Awake()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
        comboText.gameObject.SetActive(false);
    }

    public void S_StartGame()
    {
        gameStartPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        comboText.gameObject.SetActive(true);

    }
    public void S_GameOver()
    {
        gameStartPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        comboText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        bestComboText.gameObject.SetActive(true);
        S_UpdateFinalScore(S_GameManager.Instance.currentScore);
        S_UpdateBestScore(S_GameManager.Instance.bestScore);
        S_UpdateBestCombo(S_GameManager.Instance.bestCombo);
    }
    public void S_RestartGame()
    {
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        comboText.gameObject.SetActive(true);
    }
    public void S_UpdateScore(int score)
    {
        scoreText.text =  score.ToString();
    }
    public void S_UpdateBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }
    public void S_UpdateCombo(int combo)
    {
        comboText.text = combo.ToString();
    }
    public void S_UpdateBestCombo(int bestCombo)
    {
        bestComboText.text = bestCombo.ToString();
    }
    public void S_UpdateFinalScore(int score)
    {
        finalScoreText.text = score.ToString();
    }

}
