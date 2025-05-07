using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_GameManager : MonoBehaviour
{
    public static T_GameManager instance;
    private T_UIManager uiManager;
    public static bool isFirstLoading = true;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    public int currentWaveIndex = 0;
    public int currentEnemyCount = 0;

    private T_EnemyManager enemyManager;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<T_UIManager>();
        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<T_EnemyManager>();
        enemyManager.Init(this);
    }

    private void Start()
    {
    }

    public void StartGame()
    {
        uiManager.T_StartGame();
        uiManager.UpdateWaveIndex();
        uiManager.UpdateScore(0);
        StartNextWave();
    }

    public void StartNextWave()
    {
        currentWaveIndex += 1;
        uiManager.UpdateWaveIndex();
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        enemyManager.StopWave();
        uiManager.T_GameOver();
    }

    public void RestartGame()
    {
        SceneLoader.Instance.LoadTopDownShootingScene();
    }

    public void ExitGame() 
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadMainScene();
    }

    public void UpdateScore(int score)
    {
        currentEnemyCount += score;
        uiManager.UpdateScore(currentEnemyCount);
    }
}
