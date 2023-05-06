using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    protected Node node;

    public Inverter(Node node)
    {
        this.node = node;
    }
    public override NodeState Evaluate()
    {

        return (node.Evaluate()) switch
        {
            NodeState.Success => NodeState.Failure,
            NodeState.Failure => NodeState.Success,
            _ => NodeState.Running,
        };
    }
}
