using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : Singleton<AIManager>
{
    private List<WorkStation> workStations = new List<WorkStation>();
    private List<AI> currentNPCs = new List<AI>();
    [SerializeField] private GameObject NpcPrefab;
    [SerializeField] Transform housePos;
    [SerializeField] private WorkStation workStation;
    private List<WorkStation> freeWorkStations = new List<WorkStation>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnNPC(housePos);
        AddWorkStation(workStation);
    }

    public void SpawnNPC(Transform spawnPos)
    {
       currentNPCs.Add(Instantiate(NpcPrefab, spawnPos.position, Quaternion.identity).GetComponent<AI>());
    }

    public void AddWorkStation(WorkStation newStation)
    {
        workStations.Add(newStation);
    }
    public bool WorkIsAvailable()
    {
        if (true)
        {
            return false;
        }
    }
    public WorkStation GetFreeWorkStation()
    {
        for (int i = 0; i < workStations.Count; i++)
        {
            if (!workStations[i].isOccupied)
            {
                workStations[i].isOccupied = true;
                return workStations[i];
            }
        }
        return null;
    }
}