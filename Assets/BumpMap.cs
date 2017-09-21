using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to eliminate tiles (where units can move) in a normal grid map.
/// </summary>
public class BumpMap : MonoBehaviour {

    /// <summary>
    /// Divide by multiples of this number to edit left and right.
    /// </summary>
    public int bumpLength;
    /// <summary>
    /// Divide by multiples of this number to edit up and down.
    /// </summary>
    public int bumpWidth;
    /// <summary>
    /// Divide by width for columns, divide by length for rows.
    /// </summary>
    public MapTraits.TileType[] bumpDepth;
    /// <summary>
    /// Used to check the status of bumpDepth
    /// </summary>
    private MapTraits.TileType[,] bumpCheck;
    /// <summary>
    /// Called to eliminate available map tiles for a map.
    /// </summary>
    public MapTraits.TileType checkBump(int length, int width)
    {
        return bumpCheck[width,length];
    }
    /// <summary>
    /// Called to validate if the bump map matches its assigned map.
    /// </summary>
    public bool checkValidMap(int length, int width)
    {
        if(bumpLength == length && bumpWidth == width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void initializeBumpMap()
    {
        bumpCheck = new MapTraits.TileType[bumpWidth, bumpLength];
        assignBumpCheck();
    }

    private void Start()
    {

    }

    private void assignBumpCheck()
    {
        int count = 0;
        for (int bumpW = 0; bumpW < bumpWidth; bumpW++)
        {
            for(int bumpL = 0; bumpL < bumpLength; bumpL++)
            {
                //bumpCheck[bumpW, bumpL] = bumpDepth[count];
                count++;
            }
        }
    }

    /// TO DO: CREATE VALIDITY TESTS!
}
