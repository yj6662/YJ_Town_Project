using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (target== null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        transform.position = pos;
    }
}
