using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelNPC : BaseNPCController
{
    [SerializeField] private GameObject angelTextPanel;
    [SerializeField] private GameObject angelText;
    [SerializeField] private GameObject angelYesButton;
    [SerializeField] private GameObject angelNoButton;
    [SerializeField] private SceneLoader sceneLoader;

    public override void Interact()
    {
        base.Interact();
        angelTextPanel.SetActive(true);
        angelText.SetActive(true);
        angelYesButton.SetActive(true);
        angelNoButton.SetActive(true);
    }
    public void OnYesButtonClicked()
    {
        angelText.SetActive(false);
        angelYesButton.SetActive(false);
        angelNoButton.SetActive(false);
        Debug.Log("Yes button clicked");
        sceneLoader.LoadTopDownShootingScene();
        angelTextPanel.SetActive(false);
    }
    public void OnNoButtonClicked()
    {
        angelText.SetActive(false);
        angelYesButton.SetActive(false);
        angelNoButton.SetActive(false);
        Debug.Log("No button clicked");
        angelTextPanel.SetActive(false);
    }
}
