using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour {

    [SerializeField]
    private int unitCount;
    [SerializeField]
    private Unit[] units;
    [SerializeField]
    private int[] unitLengthSpawn;
    [SerializeField]
    private int[] unitWidthSpawn;
    [SerializeField]
    private int[] unitHeightSpawn;
    [SerializeField]
    private int unitTurnBreaks;
    [SerializeField]
    private WinCondition myCondition;
    private TileMap myMap;

    public void initializeBattleConditions(TileMap yourMap)
    {
        myMap = yourMap;
        if (unitSetup())
        {
            setUnitPositions();
        }
    }

    private void setUnitPositions()
    {
        for (int index = 0; index < units.GetLength(0); index++)
        {
            myMap.setUnitTile(units[index],unitLengthSpawn[index],unitWidthSpawn[index],unitHeightSpawn[index]);
        }
    }

    public void setTileMap(TileMap newMap)
    {
        myMap = newMap;
    }


    private bool unitSetup()
    {
        if (unitCount == units.GetLength(0) && unitCount == unitLengthSpawn.GetLength(0) && unitCount == unitWidthSpawn.GetLength(0) && unitCount == unitHeightSpawn.GetLength(0))
        { return true; }
        else
        { return false; }
    }


    private enum WinCondition { KillAll, Escape }
}
