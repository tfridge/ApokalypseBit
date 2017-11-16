using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTraits : ScriptableObject
{

    public enum TileShape { Square, Hexagon, Triangle }

    public GameObject squareDisplay;
    public GameObject hexDisplay;
    public GameObject triangleDisplay;

    public GameObject getGridDisplay(TileShape shape)
    {
        switch (shape)
        {
            case TileShape.Square:
                return squareDisplay;
            case TileShape.Hexagon:
                return hexDisplay;
            case TileShape.Triangle:
                return triangleDisplay;
        }
        return null;
    }
    /// <summary>
    /// Used to direct a grid map's general direction.
    /// </summary>
    public enum GridRotation { North, South, East, West, Up, Down }
    /// <summary>
    /// Used to direct a grid map's general pitch.
    /// </summary>
    public enum GridPitch { Flat, Slight, Moderate, Steep }
    /// <summary>
    /// Used to direct a tile's purpose.
    /// </summary>
    public enum TileType { Valid, None, Cover, BreakableCover }
    /// <summary>
    /// Used to direct how map grids connect to each other.
    /// </summary>
    public enum GridConnector { None, Tube, Direct }
    /// <summary>
    /// Used to handle the displaying of tiles.
    /// </summary>
    public enum TileCheck { NotChecked, Checked, Selected }
    /// <summary>
    /// Used to handle what tiles display when they're being checked.
    /// </summary>
    public enum TileStatus { Neutral, Checking }
    /// <summary>
    /// Used to make the check tile function more efficient.
    /// </summary>
    public enum TileMoveCheck { North, South, East, West, Unit }
    /// <summary>
    /// 
    /// </summary>
    public enum ValidTile { NotValid, Valid }
}
