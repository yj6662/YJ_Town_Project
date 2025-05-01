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

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
    public void LoadFlappyBirdScene()
    {
        SceneManager.LoadScene(flappyBirdScene);
    }
    public void LoadTopDownShootingScene()
    {
        SceneManager.LoadScene(topDownShootingScene);
    }
    public void LoadTheStackScene()
    {
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
