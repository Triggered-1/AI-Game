using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
    public State currentState;
    public bool hasWork;
    public AIPath path;
    [SerializeField] private AIDestinationSetter destinationSetter;
    private AIManager manager;
    void Start()
    {
        manager = AIManager.Instance;
        path = FindObjectOfType<AIPath>();
    }

    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(this, manager);
        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }
    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }

    public void MoveTo(Transform destination)
    {
        destinationSetter.target = destination;
    }
}
