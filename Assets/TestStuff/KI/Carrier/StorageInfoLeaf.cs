using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInfoLeaf : Node
{
    private CarrierAI controller;
    private MainStorage storage;

    public StorageInfoLeaf(CarrierAI controller, MainStorage storage)
    {
        this.controller = controller;
        this.storage = storage;
    }

    public override NodeState Evaluate()
    {
        if (controller.HasGatherpoint && controller.CurrentGatherable.HasResources())
        {
            controller.ReturnLastStorage();
            return NodeState.Success;
        }
        IGatherable gatherpoint = storage.GetNextStorage();
        if (gatherpoint != null && gatherpoint.HasResources())
        {
            controller.currentResourceType = gatherpoint.GetResourceType();
            controller.CurrentGatherable = gatherpoint;
            return NodeState.Success;
        }
        return NodeState.Failure;
    }
}
