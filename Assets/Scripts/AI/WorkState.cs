using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkState : State
{
    public override State RunCurrentState(AI aI, AIManager manager)
    {
        Debug.Log("isWorking");
        return null;
    }
}
