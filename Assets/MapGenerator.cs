using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    /// <summary>
    /// Collection of all map grids in this generator. Maps need to be placed in proper order.
    /// </summary>
    public Map[] myGrids;
    /// <summary>
    /// Used for stopping some map grids from appearing.
    /// </summary>
    public int initialGridCount;
    /// <summary>
    /// Used to set the initial rotation of map grids.
    /// </summary>
    public MapTraits.GridRotation[] myRotations;
    /// <summary>
    /// Used to set the initial pitches of map grids.
    /// </summary>
    public MapTraits.GridPitch[] myPitches;
    /// <summary>
    /// Used to set the initial lengths of map grids.
    /// </summary>
    public int[] lengths;
    /// <summary>
    /// Used to set the initial widths of map grids.
    /// </summary>
    public int[] widths;
    /// <summary>
    /// Used to set the initial heights of map grids. 
    /// </summary>
    public int[] heights;

	// Use this for initialization
	void Start () {
        InitializeMapGenerator();
	}

    public void InitializeMapGenerator()
    {
        if (initialGridCount < 0 && initialGridCount < myGrids.GetLength(0))
        {
            for (int i = 0; i < initialGridCount; i++)
            {
                getMap(i).InitializeMap(myRotations[i], lengths[i], widths[i], heights[i]);
            }
        }
        else
        {
            for (int i = 0; i < myGrids.GetLength(0); i++)
            {
                getMap(i).InitializeMap(myRotations[i], lengths[i], widths[i], heights[i]);
            }
        }
    }
	
    /// <summary>
    /// Used to retreive a map grid.
    /// </summary>
	private Map getMap(int index)
    {
        return myGrids[index];
    }
}
