using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager2 : MonoBehaviour {

    private TileConstraints myConstraints;
    [SerializeField]
    private Material validDisplay;
    [SerializeField]
    private TargetInfo myTarget;
    private Battlefield myBattlefield;
    [SerializeField]
    private Tile currentTile;
    [SerializeField]
    private Tile targetTile;

	// Use this for initialization
	void Start ()
    {
        myBattlefield = GetComponentInParent<Battlefield>();
        myTarget = new TargetInfo();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Called to activate the action manager.
    public void updateManagerSelection(UnitTraits.UnitSelectionStatus newStatus)
    {
        myBattlefield.setSelectionStatus(newStatus);
        switch (newStatus)
        {
            case UnitTraits.UnitSelectionStatus.NotSelected:
                break;
            case UnitTraits.UnitSelectionStatus.Movement:
                myTarget.setCurrentTile(currentTile);
                myTarget.setTargetTile(targetTile);
                checkForValidMove();
                break;
            case UnitTraits.UnitSelectionStatus.LoS:
                checkForValidLoS();
                break;
        }
    }

    /// <summary>
    /// Called when moving from one position to another.
    /// </summary>
    public Vector3 moveUnitToTargetTile()
    {
        myTarget.setCurrentTile(myTarget.getTargetTile());
        return myTarget.getCurrentTile().getPositionVector();
    }

    /// <summary>
    /// Called to perform an action on the targeted tile.
    /// </summary>
    public void actOnTargetTile()
    {

    }

    /// <summary>
    /// Called to search for a valid location to move to.
    /// </summary>
    public void checkForValidMove()
    {
        myTarget.getCurrentTile().checkValidTiles(myConstraints.getMoveConstraint(), validDisplay, MapTraits.TileMoveCheck.Unit);
    }

    /// <summary>
    /// called to search for a valid tile for a LoS action.  
    /// </summary>
    public void checkForValidLoS()
    {
       myTarget.getCurrentTile().checkValidTiles(myConstraints.getLosConstraint(), validDisplay, MapTraits.TileMoveCheck.Unit);
    }

    /// <summary>
    /// Used for holding this unit's tile constraints.
    /// </summary>
    private struct TileConstraints
    {
        private int moveConstraint;
        private int loSConstraint;

        public void setMoveConstraint(int count) {moveConstraint = count;}
        public void setLosConstraint(int count) {loSConstraint = count;}
        public int getMoveConstraint() {return moveConstraint;}
        public int getLosConstraint() { return loSConstraint; }
    }

    public void setTileConstraints(int move, int los)
    {
        myConstraints.setMoveConstraint(move);
        myConstraints.setLosConstraint(los);
    }

    /// <summary>
    /// Used to handle information target.
    /// </summary>
    public struct TargetInfo
    {
        private Tile currentTile;
        private Tile targetTile;

        public void setCurrentTile(Tile cur) { currentTile = cur; }
        public void setTargetTile(Tile tar) { targetTile = tar; }
        public Tile getCurrentTile() { return currentTile; }
        public Tile getTargetTile() { return targetTile; }
    }

    /// <summary>
    /// Called from the Unit to update the number of tiles.
    /// </summary>
    public void setUnitConstraints(int move, int los)
    {
        myConstraints.setMoveConstraint(move);
        myConstraints.setLosConstraint(los);
    }

    public TargetInfo getTargetInfo()
    {
        return myTarget;
    }
}
