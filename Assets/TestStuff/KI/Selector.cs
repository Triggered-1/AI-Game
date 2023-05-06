using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    private int activeNode;
    private Node[] nodes;

    public Selector(params Node[] nodes)
    {
        this.nodes = nodes;
        activeNode = 0;
    }
    public override NodeState Evaluate()
    {

        switch (nodes[activeNode].Evaluate())
        {
            case NodeState.Running:
                return NodeState.Running;
            case NodeState.Success:
                activeNode = 0;
                return NodeState.Success;
            case NodeState.Failure:
                activeNode++;
                break;
            default:
                break;
        }
        if (activeNode >= nodes.Length)
        {
            activeNode = 0;
            return NodeState.Failure;
        }
        return NodeState.Running;
    }
}
