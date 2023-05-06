using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    private int activeNode;
    private Node[] nodes;

    public Sequence(params Node[] nodes)
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
                activeNode++;
                break;
            case NodeState.Failure:
                activeNode = 0;
                return NodeState.Failure;
            default:
                break;
        }
        if (activeNode >= nodes.Length)
        {
            activeNode = 0;
            return NodeState.Success;
        }
        return NodeState.Running;
    }
}
