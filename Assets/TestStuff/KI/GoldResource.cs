using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldResource : MonoBehaviour , IGatherable
{
    [SerializeField] private int maxResources;
    [SerializeField] private int availableResources;

    // Start is called before the first frame update
    void Start()
    {
        availableResources = maxResources;
    }
    
    public int Gather(int miningPower,out bool resourceDestroyed)
    {
        availableResources -= miningPower;
        if (availableResources <= 0)
        {
            Destroy(this.gameObject);
            resourceDestroyed = true;
            return miningPower + availableResources;
        }
        resourceDestroyed = false;
        return miningPower;
    }
    //todo check when mined if nulling works
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
        throw new System.NotImplementedException();
    }

    public ResourceType GetResourceType()
    {
        throw new System.NotImplementedException();
    }
}
