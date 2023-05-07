using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private TileBase highlightTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap buildingTilemap;
    [SerializeField] private Tilemap tempTilemap;
    [SerializeField] private Building build;

    public Vector3Int playerPos;
    private Vector3Int highlightedTilePos;
    private bool highlighted;
    public bool isBuilding;

    private void Update()
    {
        if (isBuilding)
        {
            HighlightTile(build.buildingSprite);

            if (Input.GetMouseButtonDown(0))
            {
                if (highlighted)
                {
                    Build(highlightedTilePos, build);
                    Debug.Log(highlightedTilePos);
                    //DestroyTile(highlightedTilePos);

                }
            }
        }
    }

    public void SetBuildBool()
    {
        isBuilding = true;
    }

    private Vector3Int GetMouseOnGridPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = mainTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;

        return mouseCellPos;
    }
    private void HighlightTile(TileBase tile)
    {
        Vector3Int mouseGridPos = GetMouseOnGridPos();
        if (highlightedTilePos != mouseGridPos)
        {
            tempTilemap.SetTile(highlightedTilePos, null);

            if (InRange(playerPos, mouseGridPos, new Vector3Int(50, 50, 50)))
            {
                tempTilemap.SetTile(mouseGridPos, tile);
                highlightedTilePos = mouseGridPos;
                highlighted = true;
            }
            else
            {
                highlighted = false;
            }
        }
    }

    private bool InRange(Vector3Int posA, Vector3Int posB, Vector3Int range)
    {
        Vector3Int dinstance = posA - posB;
        if (Math.Abs(dinstance.x) >= range.x || Math.Abs(dinstance.y) >= range.y)
        {
            return false;
        }
        return true;
    }

    private void Build(Vector3Int pos, Building itemToBuild)
    {

        tempTilemap.SetTile(pos, null);
        highlighted = false;
        //build obj
        if (!buildingTilemap.HasTile(pos))
        {
            Debug.Log("Placed");
            GameObject newobj = Instantiate(itemToBuild.prefab, pos, Quaternion.identity);
            buildingTilemap.SetTile(pos, itemToBuild.buildingSprite);
            isBuilding = false;
            if (itemToBuild.buildingType == BuildingType.House) GameResources.AddVillager(2, ChangeType.Max);
            Debug.Log(newobj.transform.position);
        }
        else
        {
            Debug.Log("Cant Build");
        }
    }
    private void DestroyTile(Vector3Int pos)
    {
        tempTilemap.SetTile(pos, null);
        buildingTilemap.SetTile(pos, null);
        highlighted = false;

        //RuleTileWIthData tile = mainTilemap.GetTile<RuleTileWIthData>(pos);
        //mainTilemap.SetTile(pos, null);

        //Vector3 Position = mainTilemap.GetCellCenterWorld(pos);
    }
}
