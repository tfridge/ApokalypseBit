using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class MapGenerator : MonoBehaviour
{

    private TileMap myMap;
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
    public int[] widths;
    /// <summary>
    /// Used to set the initial widths of map grids.
    /// </summary>
    public int[] lengths;
    /// <summary>
    /// Used to set the initial heights of map grids. 
    /// </summary>
    public int[] heights;
    /// <summary>
    /// Called to initialize when generation is complete.
    /// </summary>

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

    }

    private void Update()
    {
        // Not Needed!
    }

    public Vector3 generateTileMapConstraints()
    {
        int maxWidth = myGrids[0].getWidth() + widths[0];
        int maxLength = myGrids[0].getLength() + lengths[0];
        int maxHeight = myGrids[0].getHeight() + heights[0];
        for (int i = 0; i < lengths.GetLength(0); i++)
        {
            if (maxWidth < myGrids[i].getWidth() + widths[i])
            {
                maxWidth = myGrids[i].getWidth() + widths[i];
            }
        }
        for (int i = 0; i < widths.GetLength(0); i++)
        {
            if (maxLength < myGrids[i].getLength() + lengths[i])
            {
                maxLength = myGrids[i].getLength() + lengths[i];
            }
        }
        for (int i = 0; i < heights.GetLength(0); i++)
        {
            if (maxHeight < myGrids[i].getHeight() + heights[i])
            {
                maxHeight = myGrids[i].getHeight() + heights[i];
            }
        }
        return new Vector3(maxWidth + 1, maxLength + 1, maxHeight + 1);
    }

    public void InitializeMapGenerator(TileMap parent)
    {
        myMap = parent;
        parent.initializeMap(generateTileMapConstraints());
        if (initialGridCount > 0 && initialGridCount < myGrids.GetLength(0))
        {
            for (int i = 0; i < initialGridCount; i++)
            {
                getMap(i).InitializeMap(myRotations[i], widths[i], lengths[i], heights[i], this, myMap);
            }
        }
        else
        {
            for (int i = 0; i < myGrids.GetLength(0); i++)
            {
                getMap(i).InitializeMap(myRotations[i], widths[i], lengths[i], heights[i], this, myMap);
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

    public TileMap getTileMap()
    {
        return myMap;
    }
}
