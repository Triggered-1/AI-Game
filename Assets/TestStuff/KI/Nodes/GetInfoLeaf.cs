using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInfoLeaf : Node
{
    private GatherAI controller;
    private Storage storage;


    public GetInfoLeaf(GatherAI controller, Storage storage)
    {
        this.controller = controller;
        this.storage = storage;

    }

    public override NodeState Evaluate()
    {
        if (controller.HasGatherpoint)
        {
            controller.ReturnLastGahterpoint();
            return NodeState.Success;
        }
        IGatherable gatherpoint = storage.GetNextNode();
        if (gatherpoint != null)
        {
            controller.CurrentGatherable = gatherpoint;
            return NodeState.Success;
        }
        return NodeState.Failure;
    }
}
