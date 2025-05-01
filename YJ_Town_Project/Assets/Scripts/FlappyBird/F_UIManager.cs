using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class F_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreTextUI;
    public GameObject gameStartPanel;

    public void Start()
    {
        scoreText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        bestScoreTextUI.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        gameStartPanel.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        bestScoreTextUI.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int bestscore)
    {
        bestScoreText.text = bestscore.ToString();
    }
}
