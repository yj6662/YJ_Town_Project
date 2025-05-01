using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfNPC : BaseNPCController
{
    public override void Interact()
    {
        base.Interact();
        SceneLoader.Instance.LoadFlappyBirdScene();
    }
}
