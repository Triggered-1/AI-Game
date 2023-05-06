using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLeafCarrier : Node
{
    private CarrierAI controller;
    private MainStorage storage;
    private bool coroutineIsRunning;
    private bool finishedUnload;
    public UnloadLeafCarrier(CarrierAI controller, MainStorage storage)
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
            unloadedAmount = storage.DepositResources(controller.DepositAmount, controller.currentResourceType);

            if (unloadedAmount < controller.DepositAmount)
            {
                break;
            }
            controller.currentHoldingAmount -= unloadedAmount;

            yield return new WaitForSeconds(1f);
        }
        finishedUnload = true;
        coroutineIsRunning = false;
    }
}
