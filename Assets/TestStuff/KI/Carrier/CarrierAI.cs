using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;
using Pathfinding;

public class CarrierAI : MonoBehaviour
{
    public AIPath path;
    [SerializeField] private AIDestinationSetter destinationSetter;
    private AIManager manager;

    public int currentHoldingAmount;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int withdrwalAmount;
    [SerializeField] private int depositAmount;
    [SerializeField] private int maxHoldingAmount;
    private IGatherable currentGatherable;
    private Node node;
    private MainStorage mainStorage;
    public ResourceType currentResourceType;

    public IGatherable CurrentGatherable
    {
        get => currentGatherable;
        set
        {
            currentGatherable = value;
            if (currentGatherable != null)
            {
                destinationSetter.target = value.GetTransform();
                //agent.SetDestination(value.GetPosition());
            }
        }
    }
    public int WithdrawalAmount { get => withdrwalAmount; private set => withdrwalAmount = value; }
    public int DepositAmount { get => depositAmount; private set => depositAmount = value; }
    public int MaxHoldingAmount { get => maxHoldingAmount; private set => maxHoldingAmount = value; }
    public bool HasGatherpoint { get => currentGatherable != null; }

    internal void GenerateGathererTree(MainStorage mainStorage)
    {
        this.mainStorage = mainStorage;
        StorageInfoLeaf infoLeaf = new StorageInfoLeaf(this, mainStorage);
        MoveToLeafCarrier moveToLeaf = new MoveToLeafCarrier(path);
        GatherLeafCarrier gatherLeaf = new GatherLeafCarrier(this);
        UnloadLeafCarrier unloadLeaf = new UnloadLeafCarrier(this, mainStorage);
        node = new Sequence(infoLeaf, moveToLeaf, gatherLeaf, moveToLeaf, unloadLeaf);
    }

    private void Awake()
    {
        if (!destinationSetter)
        {
            destinationSetter = GetComponent<AIDestinationSetter>();
        }
        GameResources.AddVillager(1, ChangeType.Current);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        node.Evaluate();
    }

    public void GenerateCarrierTree(MainStorage mainStorage)
    {
        this.mainStorage = mainStorage;
        StorageInfoLeaf infoLeaf = new StorageInfoLeaf(this, mainStorage);
        MoveToLeafCarrier moveToLeaf = new MoveToLeafCarrier(path);
        GatherLeafCarrier gatherLeaf = new GatherLeafCarrier(this);
        UnloadLeafCarrier unloadLeaf = new UnloadLeafCarrier(this,mainStorage);
        node = new Sequence(infoLeaf, moveToLeaf, gatherLeaf, moveToLeaf, unloadLeaf);
    }

    public void ReturnLastStorage()
    {
        destinationSetter.target = currentGatherable.GetTransform();
    }

    public void ReturnToMainStorage()
    {
        destinationSetter.target = mainStorage.transform;
    }
}