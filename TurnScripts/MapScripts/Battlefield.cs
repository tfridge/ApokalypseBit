using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurnManager))]
public class Battlefield : MonoBehaviour {

    /// <summary>
    /// Status of this unit's selection status.
    /// </summary>
    private UnitTraits.UnitSelectionStatus mySelectionStatus;
    private UnitTraits.UnitSelectionStatus oldSelectionStatus;
    private MapGenerator myGenerator;
    private TileMap myMap;
    private TurnManager myManager;

    // Use this for initialization
    void Start () {
        myGenerator = GetComponentInChildren<MapGenerator>();
        myMap = myGenerator.getTileMap();
        myManager = GetComponent<TurnManager>();
        myManager.setMyTileMap(myMap);
        myManager.initializeConditions();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Called to check the (grid) selection status of the general battlefield.
    /// </summary>
    public UnitTraits.UnitSelectionStatus getActionSelection()
    {
        return mySelectionStatus;
    }

    /// <summary>
    /// Called to change the (grid) selection status of the general battlefield.
    /// </summary>
    public void setSelectionStatus(UnitTraits.UnitSelectionStatus mySelectionStatus)
    {
        this.mySelectionStatus = mySelectionStatus;
        myMap.updateTiles(mySelectionStatus);
    }

    private void checkSelectionStatus()
    {
        if(mySelectionStatus != oldSelectionStatus)
        {
            oldSelectionStatus = mySelectionStatus;
        }
    }
}
