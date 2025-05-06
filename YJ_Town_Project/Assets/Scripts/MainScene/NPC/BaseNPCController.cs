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
        if (collider2D.CompareTag("MainPlayer"))
        {
            isPlayerInRange = true;
            Debug.Log("�÷��̾� ����");
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("MainPlayer"))
        {
            isPlayerInRange = false;
            Debug.Log("�÷��̾� ���� ��Ż");
        }
    }

    protected virtual void Update()
    {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
            {
                Debug.Log("NPC�� ��ȣ�ۿ�");
                Interact();
            }
    }

    public virtual void Interact()
    {
        Debug.Log("NPC�� ��ȣ�ۿ�");
    }
}
