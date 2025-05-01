using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPCController : MonoBehaviour
{
    protected bool isPlayerInRange = false;

    protected virtual void Awake()
    {
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("플레이어 접근");
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("플레이어 범위 이탈");
        }
    }

    protected virtual void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("NPC와 상호작용");
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("NPC와 상호작용");
    }
}
