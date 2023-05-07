using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGatherable
{
    public int Gather(int gatherPower,out bool resourceDestroyed);

    public Vector3 GetPosition();

    public Transform GetTransform();

    public bool HasResources();

    public ResourceType GetResourceType();
}
