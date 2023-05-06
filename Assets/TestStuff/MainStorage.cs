using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainStorage : MonoBehaviour
{
    [Expandable]
    public static List<Storage> GoldStorages = new List<Storage>();
    [Expandable]
    public Dictionary<ResourceType, int> curentResources;

    [SerializeField] private CarrierAI carrierPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int maxResourceCapacity;
    private int nextStorage;
    private int activeNPCs;

    // Start is called before the first frame update
    void Start()
    {
        curentResources = new Dictionary<ResourceType, int>();
        SpawnNpc();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNpc()
    {
        CarrierAI currentAI = Instantiate(carrierPrefab, spawnPositions[0].position, Quaternion.identity);
        currentAI.GenerateGathererTree(this);
        activeNPCs++;
    }

    public void GetStoragePositions()
    {

    }

    public IGatherable GetNextStorage()
    {
        if (nextStorage >= GoldStorages.Count)
        {
            nextStorage = 0;
        }

        return GoldStorages[nextStorage++];
    }

    public int DepositResources(int depositAmount, ResourceType resourceType)
    {
        if (!curentResources.ContainsKey(resourceType))
        {
            curentResources.Add(resourceType, 0);
        }
        int freeStorageSpace = maxResourceCapacity - curentResources[resourceType];
        if (freeStorageSpace < depositAmount)
        {
            curentResources[resourceType] += freeStorageSpace;
            return freeStorageSpace;
        }
        curentResources[resourceType] += depositAmount;
        return depositAmount;
    }

    public int Gather(int withdrawalAmount, ResourceType resourceType, out bool resourceEmpty)
    {
        if (curentResources[resourceType] > 0)
        {
            if (curentResources[resourceType] > withdrawalAmount)
            {
                curentResources[resourceType] -= withdrawalAmount;
                resourceEmpty = false;
                return withdrawalAmount;
            }
            else
            {
                int remaining = curentResources[resourceType];
                curentResources[resourceType] = 0;
                resourceEmpty = true;
                return remaining;
            }
        }
        resourceEmpty = true;
        return 0;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
