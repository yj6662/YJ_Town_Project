using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwalfNPC : BaseNPCController
{
    public override void Interact()
    {
        base.Interact();
        SceneLoader.Instance.LoadTheStackScene();
    }
}
