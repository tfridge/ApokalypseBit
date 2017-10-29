using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    /// <summary>
    /// Tile map this tile belongs to.
    /// </summary>
    private TileMap myTileMap;
    /// <summary>
    /// Parent unit of this tile.
    /// </summary>
    private Map myMap;
    /// <summary>
    /// Display of this unit when the grid map is showing.
    /// </summary>
    [SerializeField]
    private Material display;
    /// <summary>
    /// Display of this unit when selected by an outside function.
    /// </summary>
    [SerializeField]
    private Material tempDisplay;
    /// <summary>
    /// This grid's X position relative to the map's origin point.
    /// </summary>
    [SerializeField]
    private int width;
    /// <summary>
    /// This grid's Z position relative to the map's origin point.
    /// </summary>
    [SerializeField]
    private int length;
    /// <summary>
    /// This grid's Y position relative to the map's origin point.
    /// </summary>
    [SerializeField]
    private int height;
    /// <summary>
    /// The purpose of this grid tile.
    /// </summary>
    private MapTraits.TileType myType;
    /// <summary>
    /// The status of this tile during an action check.
    /// </summary>
    [SerializeField]
    private MapTraits.TileCheck myCheck;
    /// <summary>
    /// The status of this tile to detect an action taking place.
    /// </summary>
    private MapTraits.TileStatus myStatus;
    /// <summary>
    /// The unit occupying this tile.
    /// </summary>
    [SerializeField]
    private Unit curUnit;
    /// <summary>
    /// Adjusts the vertical placement of objects in this tile. Essentially a percentage.
    /// </summary>
    [Range(0, 100)]
    [SerializeField]
    private float verticalOffset;
    /// <summary>
    /// Adjusts the horizontal placement of objects in this tile. Essentially a percentage.
    /// </summary>
    [Range(0, 100)]
    [SerializeField]
    private float horizontalOffset;
    /// <summary>
    /// Status of this unit's selection status.
    /// </summary>
    private UnitTraits.UnitSelectionStatus mySelectionStatus;
    /// <summary>
    /// Status of this unit's old selection status
    /// </summary>
    private UnitTraits.UnitSelectionStatus myOldSelectionStatus;
    /// <summary>
    /// Reference to the battlefield of 
    /// </summary>
    private Battlefield myBattlefield;
    /// <summary>
    /// Tile check direction of a tile.
    /// </summary>
    private MapTraits.TileMoveCheck myDirection;
    /// <summary>
    /// The offset of this object.
    /// </summary>
    private GameObject myOffset;

    public MapTraits.ValidTile isValid;

    public MapTraits.ValidTile getTileValid()
    {
        return isValid;
    }

    public void setTileValid(MapTraits.ValidTile valid)
    {
        isValid = valid;
    }

    private void Start()
    {
        myOldSelectionStatus = UnitTraits.UnitSelectionStatus.NotSelected;
        myOffset = new GameObject();
        myOffset.transform.parent = transform;
        myOffset.transform.localPosition = new Vector3(.15f, .0f, .15f);
    }

    private void Update()
    {

    }

    /// <summary>
    /// Called when a change in selection status is detected.
    /// </summary>
    public void updateActionSelection(UnitTraits.UnitSelectionStatus status)
    {
        switch (status)
        {
            case UnitTraits.UnitSelectionStatus.NotSelected:
                if (myCheck != MapTraits.TileCheck.NotChecked)
                {
                    clearTempDisplay();
                }
                break;
            case UnitTraits.UnitSelectionStatus.Movement:
                if (myCheck != MapTraits.TileCheck.NotChecked)
                {
                    clearTempDisplay();
                }
                break;
            case UnitTraits.UnitSelectionStatus.LoS:
                if (myCheck != MapTraits.TileCheck.NotChecked)
                {
                    clearTempDisplay();
                }
                break;
        }

    }

    /// <summary>
    /// Called upon map generation to place the tile relative to the map itself, including a reference to the parent map.
    /// </summary>
    public void setPosition(int width, int length, int height, Map map)
    {
        this.length = length;
        this.width = width;
        this.height = height;
        myMap = map;
        myTileMap = myMap.getMyTileMap();
        myBattlefield = myMap.GetComponentInParent<Battlefield>();
    }

    /// <summary>
    /// Called to retrieve this tile's display.
    /// </summary>
    public Material getDisplay()
    {
        return display;
    }

    /// <summary>
    /// Called to set the tile's display object. This is one of two variations, this one taking in an additional trait.
    /// </summary>
    public void setDisplay(Material display, MapTraits.TileType myType)
    {
        this.display = display;
        this.myType = myType;
        updateDisplay();
    }

    /// <summary>
    /// Called to set the tile's display object. This is one of two variations, this one only taking in a single variable.
    /// </summary>
    public void setDisplay(Material display)
    {
        this.display = display;
        updateDisplay();
    }

    /// <summary>
    /// Called to change a unit's display temporarily.
    /// </summary>
    public void setTempDisplay(Material temp)
    {
        tempDisplay = display;
        display = temp;
        updateDisplay();
    }

    /// <summary>
    /// Called to end this unit's temp display.
    /// </summary>
    public void clearTempDisplay()
    {
        display = tempDisplay;
        setTileCheck(MapTraits.TileCheck.NotChecked);
        setTileValid(MapTraits.ValidTile.NotValid);
        updateDisplay();
    }

    private void updateDisplay()
    {
        GetComponent<MeshRenderer>().material = display;
    }

    /// <summary>
    /// Called to get this tile's position.
    /// </summary>
    public int[] getPosition()
    {
        int[] myPosition = new int[3];
        myPosition[0] = width;
        myPosition[1] = length;
        myPosition[2] = height;
        return myPosition;
    }

    public Vector3 getPositionVector()
    {
        Vector3 myPosition = new Vector3();
        myPosition[0] = width;
        myPosition[1] = length;
        myPosition[2] = height;
        return myPosition;
    }

    private void setTileCheck(MapTraits.TileCheck check)
    {
        myCheck = check;
    }

    public MapTraits.TileType getMyType()
    {
        return myType;
    }

    public Map getMyParentMap()
    {
        return myMap;
    }

    public Tile getThisTile()
    {
        return this;
    }

    public void setUnit(Unit newUnit)
    {
        curUnit = newUnit;
        curUnit.setCurTile(this);
    }

    public void clearUnit()
    {
        curUnit = null;
    }

    /// <summary>
    /// Called initially from an action manager. Activates the tile to be viable for selection, then pings adjacent tiles if available. 
    /// </summary>
    public void checkValidTiles(int constraint, Material tempDisplay, MapTraits.TileMoveCheck direction)
    {
        myDirection = direction;
        if (constraint < 1 || myCheck == MapTraits.TileCheck.Checked)
        {
            return;
        }
        setTempDisplay(tempDisplay);
        setTileCheck(MapTraits.TileCheck.Checked);
        setTileValid(MapTraits.ValidTile.Valid);
        int[] newPos = newPosition(getPosition(), MapTraits.TileMoveCheck.North);
        Tile request = myTileMap.getTile(newPos);
        if (request != null)
        {
            request.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.North);
        }
        int[] newPos1 = newPosition(getPosition(), MapTraits.TileMoveCheck.East);
        Tile request1 = myTileMap.getTile(newPos1);
        if (request1 != null)
        {
            request1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.East);
        }
        int[] newPos2 = newPosition(getPosition(), MapTraits.TileMoveCheck.South);
        Tile request2 = myTileMap.getTile(newPos2);
        if (request2 != null)
        {
            request2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.South);
        }
        int[] newPos3 = newPosition(getPosition(), MapTraits.TileMoveCheck.West);
        Tile request3 = myTileMap.getTile(newPos3);
        if (request3 != null)
        {
            request3.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.West);
        }
    }

    private int[] newPosition(int[] oldPosition, MapTraits.TileMoveCheck direction)
    {
        int[] newPos = new int[3];
        int[] position = getPosition();
        switch (direction)
        {
            case MapTraits.TileMoveCheck.North:
                int north = position[0] + 1;
                newPos[0] = north;
                newPos[1] = position[1];
                newPos[2] = position[2];
                break;
            case MapTraits.TileMoveCheck.South:
                int south = position[0] - 1;
                newPos[0] = south;
                newPos[1] = position[1];
                newPos[2] = position[2];
                break;
            case MapTraits.TileMoveCheck.East:
                int east = position[1] + 1;
                newPos[0] = position[0];
                newPos[1] = east;
                newPos[2] = position[2];
                break;
            case MapTraits.TileMoveCheck.West:
                int west = position[1] - 1;
                newPos[0] = position[0];
                newPos[1] = west;
                newPos[2] = position[2];
                break;
        }
        return newPos;
    }

    public Transform getOffset()
    {
        return myOffset.transform;
    }
}
