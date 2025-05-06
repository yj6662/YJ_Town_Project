using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance = null;
    public string mainSceneName = "MainScene";
    public string flappyBirdScene = "FlappyBird";
    public string topDownShootingScene = "TopDownShooting";
    public string theStackScene = "TheStack";


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != mainSceneName)
            return;

        var player = GameObject.FindWithTag("MainPlayer")?.transform;
        if (player == null)
        {
            return;
        }
        player.position = GameManager.instance.lastPosition;
        player.rotation = GameManager.instance.lastRotation;
    }
    public void LoadFlappyBirdScene()
    {
        var player = GameObject.FindWithTag("MainPlayer")?.transform;
        if (player != null)
        {
            GameManager.instance.lastPosition = player.position;
            GameManager.instance.lastRotation = player.rotation;
        }
        SceneManager.LoadScene(flappyBirdScene);
    }
    public void LoadTopDownShootingScene()
    {
        var player = GameObject.FindWithTag("MainPlayer")?.transform;
        if (player != null)
        {
            GameManager.instance.lastPosition = player.position;
            GameManager.instance.lastRotation = player.rotation;
        }
        SceneManager.LoadScene(topDownShootingScene);
    }
    public void LoadTheStackScene()
    {
        var player = GameObject.FindWithTag("MainPlayer")?.transform;
        if (player != null)
        {
            GameManager.instance.lastPosition = player.position;
            GameManager.instance.lastRotation = player.rotation;
        }
        SceneManager.LoadScene(theStackScene);
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
