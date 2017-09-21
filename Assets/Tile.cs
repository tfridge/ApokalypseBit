using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    /// <summary>
    /// Display of this unit when the grid map is showing.
    /// </summary>
    private GameObject display;
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
    [SerializeField]
    private MapTraits.TileType myType;
	
    /// <summary>
    /// Called upon map generation to place the tile relative to the map itself.
    /// </summary>
	public void setPosition(int length, int width, int height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Called to set the tile's display object. This is one of two variations, this one taking in an additional trait.
    /// </summary>
    public void setDisplay(GameObject display, MapTraits.TileType myType)
    {
        this.display = display;
        this.myType = myType;
    }
    /// <summary>
    /// Called to set the tile's display object. This is one of two variations, this one only taking in a single .
    /// </summary>
    public void setDisplay(GameObject display)
    {
        this.display = display;
    }
    /// <summary>
    /// Called to get this tile's position.
    /// </summary>
    /// <returns></returns>
    public int[] getPosition()
    {
        int[] myPosition = new int[3];
        myPosition[0] = length;
        myPosition[1] = width;
        myPosition[2] = height;
        return myPosition;
    }
}
