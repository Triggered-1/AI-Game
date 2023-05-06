//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GatherState : State
//{
//    public GatherState(GatherAI controller)
//    {
//        this.controller = controller;
//        coroutineIsRunning = false;
//        finishedGather = false;
//    }
//    private GatherAI controller;
//    private bool coroutineIsRunning;
//    private bool finishedGather;
//    public override State RunCurrentState(AI aI, AIManager manager)
//    {


//        public NodeState Evaluate()
//        {
//            if (!coroutineIsRunning)
//            {
//                if (finishedGather)
//                {
//                    finishedGather = false;
//                    controller.ReturnToStorage();
//                    return NodeState.Success;
//                }
//                else
//                {
//                    controller.StartCoroutine(GatherResource());
//                }
//            }
//            return NodeState.Running;
//        }

//        private IEnumerator GatherResource()
//        {
//            coroutineIsRunning = true;
//            int minedAmount;
//            while (controller.currentHoldingAmount < controller.MaxHoldingAmount)
//            {
//                int remainingRoom = controller.MaxHoldingAmount - controller.currentHoldingAmount;
//                if (remainingRoom < controller.MiningPower)
//                {
//                    minedAmount = controller.CurrentGatherable.Gather(remainingRoom, out bool resourceDestroyed);
//                    controller.currentHoldingAmount += minedAmount;
//                    if (resourceDestroyed)
//                    {
//                        controller.CurrentGatherable = null;
//                        break;
//                    }
//                }
//                else
//                {
//                    minedAmount = controller.CurrentGatherable.Gather(controller.MiningPower, out bool resourceDestroyed);
//                    controller.currentHoldingAmount += minedAmount;
//                    if (resourceDestroyed)
//                    {
//                        controller.CurrentGatherable = null;
//                        break;
//                    }
//                }

//                yield return new WaitForSeconds(1f);
//            }
//            finishedGather = true;
//            coroutineIsRunning = false;
//        }
//        return null;
//    } 
//}
