using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfNPC : BaseNPCController
{
    [SerializeField] private GameObject elfTextPanel;
    [SerializeField] private GameObject elfText;
    [SerializeField] private GameObject elfYesButton;
    [SerializeField] private GameObject elfNoButton;
    [SerializeField] private SceneLoader sceneLoader;

    public override void Interact()
    {
        base.Interact();
        elfTextPanel.SetActive(true);
        elfText.SetActive(true);
        elfYesButton.SetActive(true);
        elfNoButton.SetActive(true);
    }
    public void OnYesButtonClicked()
    {
        elfText.SetActive(false);
        elfYesButton.SetActive(false);
        elfNoButton.SetActive(false);
        Debug.Log("Yes button clicked");
        sceneLoader.LoadFlappyBirdScene();
        elfTextPanel.SetActive(false);
    }
    public void OnNoButtonClicked()
    {
        elfText.SetActive(false);
        elfYesButton.SetActive(false);
        elfNoButton.SetActive(false);
        Debug.Log("No button clicked");
        elfTextPanel.SetActive(false);
    }
}
