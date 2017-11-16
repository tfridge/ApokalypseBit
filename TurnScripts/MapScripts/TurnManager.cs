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

    public void initializeConditions()
    {
        myConditions.initializeBattleConditions(myMap);
    }

    public void setMyTileMap(TileMap yourMap) { myMap = yourMap; }
}
