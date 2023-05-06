using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    private Dictionary<ResourceType, int> ResourceDic;
    // Start is called before the first frame update
    void Start()
    {
        ResourceDic = new Dictionary<ResourceType, int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddResource(int amount, ResourceType type)
    {
        ResourceDic.Add(type, amount);

    }
    public void RemoveResource(int amount, ResourceType type)
    {
        ResourceDic.Add(type, -amount);
    }
}
