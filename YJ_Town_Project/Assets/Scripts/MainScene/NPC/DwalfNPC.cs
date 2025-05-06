using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwalfNPC : BaseNPCController
{
    [SerializeField] private GameObject dwalfTextPanel;
    [SerializeField] private GameObject dwalfText;
    [SerializeField] private GameObject dwalfYesButton;
    [SerializeField] private GameObject dwalfNoButton;
    [SerializeField] private SceneLoader sceneLoader;

    public override void Interact()
    {
        base.Interact();
        dwalfTextPanel.SetActive(true);
        dwalfText.SetActive(true);
        dwalfYesButton.SetActive(true);
        dwalfNoButton.SetActive(true);
    }
    public void OnYesButtonClicked()
    {
        dwalfText.SetActive(false);
        dwalfYesButton.SetActive(false);
        dwalfNoButton.SetActive(false);
        Debug.Log("Yes button clicked");
        sceneLoader.LoadTheStackScene();
        dwalfTextPanel.SetActive(false);
    }
    public void OnNoButtonClicked()
    {
        dwalfText.SetActive(false);
        dwalfYesButton.SetActive(false);
        dwalfNoButton.SetActive(false);
        Debug.Log("No button clicked");
        dwalfTextPanel.SetActive(false);
    }
}
