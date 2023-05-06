using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLeaf : Node
{
    private GatherAI controller;
    private Storage storage;
    private bool coroutineIsRunning;
    private bool finishedUnload;
    public UnloadLeaf(GatherAI controller, Storage storage)
    {
        this.controller = controller;
        this.storage = storage;
    }

    public override NodeState Evaluate()
    {
        if (!coroutineIsRunning)
        {
            if (finishedUnload)
            {
                finishedUnload = false;
                return NodeState.Success;
            }
            else
            {
                controller.StartCoroutine(UnloadResources());
            }
        }
        return NodeState.Running;
    }

    private IEnumerator UnloadResources()
    {
        coroutineIsRunning = true;
        int unloadedAmount;
        while (controller.currentHoldingAmount > 0)
        {
            unloadedAmount = storage.DepositResources(controller.DepositAmount);

            if (unloadedAmount < controller.DepositAmount)
            {
                break;
            }
            controller.currentHoldingAmount -= unloadedAmount;

            yield return new WaitForSeconds(1f);
            GameResources.AddResourceAmount(unloadedAmount, storage.GetResourceType());
        }
        finishedUnload = true;
        coroutineIsRunning = false;
    }
}
