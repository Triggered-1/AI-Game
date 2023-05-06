using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
    public abstract NodeState Evaluate();
}
public enum NodeState
{
    Running, Success, Failure,
}
