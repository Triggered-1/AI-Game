using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Pathfinding;

public class GatherAI : MonoBehaviour
{
    public AIPath path;
    [SerializeField] private AIDestinationSetter destinationSetter;
    private AIManager manager;

    public int currentHoldingAmount;
    [SerializeField] private int miningPower;
    [SerializeField] private int depositAmount;
    [SerializeField] private int maxHoldingAmount;
    private IGatherable currentGatherable;
    private Node node;
    private Storage storage;

    public IGatherable CurrentGatherable
    {
        get => currentGatherable;
        set
        {
            currentGatherable = value;
            if (currentGatherable != null)
            {
                destinationSetter.target = value.GetTransform();
            }
        }
    }
    public int MiningPower { get => miningPower; private set => miningPower = value; }
    public int DepositAmount { get => depositAmount; private set => depositAmount = value; }
    public int MaxHoldingAmount { get => maxHoldingAmount; private set => maxHoldingAmount = value; }
    public bool HasGatherpoint { get => currentGatherable != null; }

    private void Awake()
    {
        if (!destinationSetter)
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
        }
        GameResources.AddVillager(1, ChangeType.Current);
    }

    // Update is called once per frame
    void Update()
    {
        node.Evaluate();
    }

    public void GenerateGathererTree(Storage storage)
    {
        this.storage = storage;
        GetInfoLeaf infoLeaf = new GetInfoLeaf(this, storage);
        MoveToLeafCarrier moveToLeaf = new MoveToLeafCarrier(path);
        GatherLeaf gatherLeaf = new GatherLeaf(this);
        UnloadLeaf unloadLeaf = new UnloadLeaf(this, storage);
        node = new Sequence(infoLeaf, moveToLeaf, gatherLeaf, moveToLeaf, unloadLeaf);
    }

    public void ReturnLastGahterpoint()
    {
        //agent.SetDestination(currentGatherable.GetPosition());
        destinationSetter.target = currentGatherable.GetTransform();
    }

    public void ReturnToStorage()
    {
        destinationSetter.target = storage.transform;
        //agent.SetDestination(storage.transform.position);
    }
}