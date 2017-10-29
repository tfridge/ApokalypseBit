using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    [SerializeField]
    private Faction[] myFactions;
    [SerializeField]
    private Conditions myConditions;
    private Unit activeUnit;
    [SerializeField]
    private TileMap myMap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    private void checkMyStatuses()
    {

    }

    public void setActiveUnit(Unit unit)
    {
        activeUnit = unit;
        adjustToActiveUnit();
    }

    public void adjustToActiveUnit()
    {
        transform.position = activeUnit.transform.position;
    }

    public void initializeUnitPositions()
    {
        Transform[] playerSpawns = myConditions.getPlayerSpawn();
        Unit[] playerUnits = myFactions[0].getUnits();
        for (int i = 0; i < playerSpawns.GetLength(0); i++)
        {
            int[] newPosition = new int[3];
            newPosition[0] = (int)playerSpawns[i].transform.position.x;
            newPosition[1] = (int)playerSpawns[i].transform.position.z;
            newPosition[2] = (int)playerSpawns[i].transform.position.y;
            Tile newTile = myMap.getTile(newPosition);
            if (newTile != null)
            {
                newTile.setUnit(playerUnits[i]);
            }
        }
        Transform[] enemySpawns = myConditions.getEnemySpawn();
        Unit[] enemyUnits = myFactions[1].getUnits();
        for (int i = 0; i < enemySpawns.GetLength(0); i++)
        {
            int[] newPosition = new int[3];
            newPosition[0] = (int)enemySpawns[i].transform.position.x;
            newPosition[1] = (int)enemySpawns[i].transform.position.z;
            newPosition[2] = (int)enemySpawns[i].transform.position.y;
            Tile newTile = myMap.getTile(newPosition);
            if (newTile != null)
            {
                newTile.setUnit(enemyUnits[i]);
            }
        }
    }
}
