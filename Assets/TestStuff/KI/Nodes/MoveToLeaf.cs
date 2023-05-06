using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Pathfinding;

public class MoveToLeafCarrier : Node
{
    private AIPath path;

    public MoveToLeafCarrier(AIPath path)
    {
        this.path = path;
    }

    public override NodeState Evaluate()
    {
        if (!path.hasPath)
        {
            Debug.Log("failed");
            return NodeState.Failure;
        }
        if (!path.pathPending)
        {
            if (path.remainingDistance <= path.endReachedDistance)
            {
                if (path.reachedEndOfPath)
                {
                    Debug.Log("path finished");
                    return NodeState.Success;
                }
            }
        }
        Debug.Log("running");
        return NodeState.Running;
    }
}