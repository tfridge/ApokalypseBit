using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionManager))]
public class Unit : MonoBehaviour {

    /// <summary>
    /// Handles movement and actions of the unit as selected.
    /// </summary>
    private ActionManager myActions;
    /// <summary>
    /// Number of tiles this unit can move.
    /// </summary>
    [SerializeField]
    private int moveConstraint;
    /// <summary>
    /// Number of tiles away this unit can fire.
    /// </summary>
    [SerializeField]
    private int losConstraint;
    /// <summary>
    /// Status of this unit's selection status.
    /// </summary>
    [SerializeField]
    private UnitTraits.UnitSelectionStatus mySelectionStatus;
    /// <summary>
    /// Status of this unit's old selection status
    /// </summary>
    private UnitTraits.UnitSelectionStatus myOldSelectionStatus;
    /// <summary>
    /// Faction this unit represents;
    /// </summary>
    private Faction myFaction;
    /// <summary>
    /// Status of this unit.
    /// </summary>
    private UnitStatus myStatus;

    // Use this for initialization
    void Start ()
    {
        myActions = GetComponent<ActionManager>();
        myActions.setTileConstraints(moveConstraint, losConstraint);
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkSelectionStatus();
	}

    /// <summary>
    /// Called when status change is detected.
    /// </summary>
    private void updateActionSelection()
    {
        myActions.updateManagerSelection(mySelectionStatus);
    }

    /// <summary>
    /// Continuously checked to see if the unit's selection status has changed.
    /// </summary>
    public void checkSelectionStatus()
    {
        if(mySelectionStatus != myOldSelectionStatus)
        {
            myOldSelectionStatus = mySelectionStatus;
            updateActionSelection();
        }
    }

    public Faction getMyFaction()
    {
        return myFaction;
    }

    public UnitStatus getMyStatus()
    {
        return myStatus;
    }

    public void setCurTile(Tile newTile)
    {
        myActions.getTargetInfo().setCurrentTile(newTile);
    }

    /// <summary>
    /// Called when a move is conformed.
    /// </summary>
    private void moveThisUnit()
    {
        transform.position = myActions.moveUnitToTargetTile();
    }
}
