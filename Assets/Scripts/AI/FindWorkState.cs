using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWorkState : State
{
    public WorkState workState;
    public override State RunCurrentState(AI ai, AIManager manager)
    {
        if (!ai.hasWork )// add if work is avalibe and when not return roam/ wait state
        {
            if (!ai.path.hasPath)
            {
                Debug.Log("new path");
                ai.MoveTo(manager.GetFreeWorkStation().workStationPos); 
            }
            if (ai.path.reachedEndOfPath)
            {
                ai.hasWork = true;
                return workState;
            }
            else
            {
                return this;
            }
            
        }
        else
        {
            return this;
        }
    }
}
