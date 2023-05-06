using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    [SerializeField] private WorkStationType workStationType;
    public Transform workStationPos;
    public bool isOccupied;
}
