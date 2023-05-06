using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLeafCarrier : Node
{
    private CarrierAI controller;
    private bool coroutineIsRunning;
    private bool finishedGather;

    public GatherLeafCarrier(CarrierAI controller)
    {
        this.controller = controller;
        coroutineIsRunning = false;
        finishedGather = false;
    }

    public override NodeState Evaluate()
    {
        if (!coroutineIsRunning)
        {
            if (finishedGather)
            {
                finishedGather = false;
                controller.ReturnToMainStorage();
                return NodeState.Success;
            }
            else
            {
                controller.StartCoroutine(GatherResource());
            }
        }
        return NodeState.Running;
    }

    private IEnumerator GatherResource()
    {
        coroutineIsRunning = true;
        int minedAmount;
        while (controller.currentHoldingAmount < controller.MaxHoldingAmount)
        {
            int remainingRoom = controller.MaxHoldingAmount - controller.currentHoldingAmount;
            if (remainingRoom < controller.WithdrawalAmount)
            {
                minedAmount = controller.CurrentGatherable.Gather(remainingRoom, out bool resourceDestroyed);
                controller.currentHoldingAmount += minedAmount;
                if (resourceDestroyed)
                {
                    controller.CurrentGatherable = null;
                    break;
                }
            }
            else
            {
                minedAmount = controller.CurrentGatherable.Gather(controller.WithdrawalAmount, out bool resourceDestroyed);
                controller.currentHoldingAmount += minedAmount;
                if (resourceDestroyed)
                {
                    controller.CurrentGatherable = null;
                    break;
                }
            }

            yield return new WaitForSeconds(1f);
        }
        finishedGather = true;
        coroutineIsRunning = false;
    }
}