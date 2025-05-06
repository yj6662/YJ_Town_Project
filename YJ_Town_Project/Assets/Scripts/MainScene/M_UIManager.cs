using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameStartPanel;

    public void Awake()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameStartPanel.activeSelf)
        {
            gameStartPanel.SetActive(false);
        }
    }

    public void OpenStartPanel()
    {
        gameStartPanel.SetActive(true);
    }
    public void ElfNPC_Text()
    {

    }
}
