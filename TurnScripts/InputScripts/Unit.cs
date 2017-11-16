using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStatus))]
public class Unit : MonoBehaviour {

    /// <summary>
    /// Status of this unit's selection status.
    /// </summary>
    private UnitTraits.UnitSelectionStatus mySelectionStatus;
    /// <summary>
    /// Status of this unit's old selection status
    /// </summary>
    private UnitTraits.UnitSelectionStatus myOldSelectionStatus;
    /// <summary>
    /// Faction this unit represents;
    /// </summary>
    [SerializeField]
    private Faction myFaction;
    /// <summary>
    /// Status of this unit.
    /// </summary>
    private UnitStatus myStatus;

    // Use this for initialization
    void Start ()
    {

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

    /// <summary>
    /// Called to set the position of this unit. THIS WILL BE CHANGED TO SET THE EVENTUAL POSITION, RIGHT NOW JUMPS THERE.
    /// </summary>
    public void setTargetPostion(Transform transform)
    {
        this.transform.position = transform.position;
    }
    
}
