using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinNPC : BaseNPCController
{
    [SerializeField] private GameObject goblinTextPanel;
    [SerializeField] private GameObject goblinText;
    [SerializeField] private GameObject goblinYesButton;
    [SerializeField] private GameObject goblinNoButton;
    [SerializeField] private GameObject shopPanel;

    public override void Interact()
    {
        base.Interact();
        goblinTextPanel.SetActive(true);
        goblinText.SetActive(true);
        goblinYesButton.SetActive(true);
        goblinNoButton.SetActive(true);
    }
    public void OnYesButtonClicked()
    {
        goblinText.SetActive(false);
        goblinYesButton.SetActive(false);
        goblinNoButton.SetActive(false);
        Debug.Log("Yes button clicked");
        goblinTextPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void OnNoButtonClicked()
    {
        goblinText.SetActive(false);
        goblinYesButton.SetActive(false);
        goblinNoButton.SetActive(false);
        Debug.Log("No button clicked");
        goblinTextPanel.SetActive(false);
    }
}
