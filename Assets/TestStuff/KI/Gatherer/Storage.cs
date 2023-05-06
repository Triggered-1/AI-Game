using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour, IGatherable
{
    [SerializeField] private float range;
    [SerializeField] private GatherAI gathererPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int maxCapacity;
    [SerializeField] private int activeNPCs;
    [SerializeField] private ResourceType storageType;
    public int StoredAmount;
    private int nextNode;
    public List<IGatherable> Nodes;
    private GatherAI gatherAI;

    public LayerMask resourceLayer;
    const int firstResLayer = 256;

    public int MaxCapacity { get => maxCapacity; private set => maxCapacity = value; }

    private void Awake()
    {
        MainStorage.GoldStorages.Add(this);

    }

    // Start is called before the first frame update
    void Start()
    {
        Nodes = new List<IGatherable>();
        GetNodePositions();
        SpawnNpc();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNpc()
    {
        GatherAI currentAI = Instantiate(gathererPrefab, spawnPositions[0].position, Quaternion.identity);
        currentAI.GenerateGathererTree(this);
        activeNPCs++;
    }

    public IGatherable GetNextNode()
    {
        if (nextNode < Nodes.Count)
        {
            return Nodes[nextNode++];
        }
        return null;
    }

    public void GetNodePositions()
    {
        nextNode = 0;
        Collider2D[] nodePositons = Physics2D.OverlapCircleAll(transform.position, range, resourceLayer);
        Debug.Log(nodePositons.Length);
        foreach (Collider2D node in nodePositons)
        {
            Nodes.Add(node.gameObject.GetComponent<IGatherable>());
        }
    }

    public int DepositResources(int depositAmount)
    {
        int freeStorageSpace = maxCapacity - StoredAmount;
        if (freeStorageSpace < depositAmount)
        {
            StoredAmount += freeStorageSpace;
            return freeStorageSpace;
        }
        StoredAmount += depositAmount;
        return depositAmount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public int Gather(int minigPower, out bool storageEmpty)
    {
        if (StoredAmount > 0)
        {
            if (StoredAmount > minigPower)
            {
                StoredAmount -= minigPower;
                storageEmpty = false;
                return minigPower;
            }
            else
            {
                int remaining = StoredAmount;
                StoredAmount = 0;
                storageEmpty = true;
                return remaining;
            }
        }
        storageEmpty = true;
        return 0;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }
    public bool HasResources()
    {
        return StoredAmount > 0;
    }

    public ResourceType GetResourceType()
    {
        return storageType;
    }
}
