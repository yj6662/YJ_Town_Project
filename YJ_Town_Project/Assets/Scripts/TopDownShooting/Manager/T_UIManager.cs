using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject waveText;
    [SerializeField] private GameObject hpSlider;

    public static T_UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameStartPanel.SetActive(true);
        ChangePlayerHP(10,10);
    }

    public void T_StartGame()
    {
        gameStartPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scoreText.SetActive(true);
        waveText.SetActive(true);
        hpSlider.SetActive(true);
    }
    public void T_GameOver()
    {
        gameStartPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        waveText.SetActive(false);
        hpSlider.SetActive(false);
    }
    public void T_RestartGame()
    {
        gameOverPanel.SetActive(false);
        scoreText.SetActive(true);
        waveText.SetActive(true);
    }
    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        hpSlider.GetComponent<Slider>().maxValue = maxHP;
        hpSlider.GetComponent<Slider>().value = currentHP;
        hpSlider.GetComponentInChildren<TextMeshProUGUI>().text = currentHP + "/" + maxHP;
    }
    public void UpdateWaveIndex()
    {
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave: " + T_GameManager.instance.currentWaveIndex;

    }
    public void UpdateScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + T_GameManager.instance.currentEnemyCount;
    }

    void Update()
    {
        
    }
}
