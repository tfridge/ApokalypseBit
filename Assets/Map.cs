using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basic grid map of an area - used with other maps inside the map generator to put levels together.
/// </summary>
public class Map : MonoBehaviour {

    public int tileLength;
    public int tileWidth;
    public int tileHeight;
    public int length;
    public int width;
    public int heightOrigin;
    private Tile[,] tileMap;
    private Tile origin;
    private Tile gridEnd;
    public GameObject display;
    public Quaternion myRotation;
    private bool initialized;
    public BumpMap bumpMap;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Called to create the tile map.
    /// </summary>
    public void InitializeMap(MapTraits.GridRotation rotation, int tileLength, int tileWidth, int tileHeight)
    {
        if (!initialized)
        {
            setRotation(rotation);
            setGridPosition(tileLength, tileWidth, tileHeight);
            tileMap = new Tile[length, width];
            if (bumpMap != null)
            {
                bumpMap.initializeBumpMap();
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (bumpMap != null)
                    {
                        if (bumpMap.checkValidMap(length, width))
                        {
                            if (bumpMap.checkBump(i, j) != MapTraits.TileType.None)
                            {
                                tileMap[i, j] = Instantiate(display, new Vector3(i + tileLength, tileHeight, j + tileWidth), Quaternion.identity).AddComponent<Tile>();
                                tileMap[i, j].setPosition(i+tileLength, j+tileWidth, tileHeight);
                                tileMap[i, j].setDisplay(display,bumpMap.checkBump(i,j));
                                tileMap[i, j].transform.parent = transform;
                                setGridEnd(tileMap[i, j]);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            tileMap[i, j] = Instantiate(display, new Vector3(i + tileLength, tileHeight, j + tileWidth), Quaternion.identity).AddComponent<Tile>();
                            tileMap[i, j].setPosition(i + tileLength, j + tileWidth, tileHeight);
                            tileMap[i, j].setDisplay(display);
                            tileMap[i, j].transform.parent = transform;
                            setGridEnd(tileMap[i, j]);
                        }
                    }
                    else
                    {
                        tileMap[i, j] = Instantiate(display, new Vector3(i + tileLength, tileHeight, j + tileWidth), Quaternion.identity).AddComponent<Tile>();
                        tileMap[i, j].setPosition(i + tileLength, j + tileWidth, tileHeight);
                        tileMap[i, j].setDisplay(display);
                        tileMap[i, j].transform.parent = transform;
                        setGridEnd(tileMap[i, j]);
                    }
                }
            }
            setOrigin(tileMap[0, 0]);
            initialized = true;
            transform.rotation = myRotation;
        }
    }

    /// <summary>
    /// Called to adjust the total rotation of a map grid.
    /// </summary>
    private void setRotation(MapTraits.GridRotation nRotation)
    {
        switch (nRotation)
        {
            // Put the proper quaternions here!
        }
    }
    /// <summary>
    /// Sets the position of the grid map in world space.
    /// </summary>
    private void setGridPosition(int length, int width, int height)
    {
        tileLength = length;
        tileWidth = width;
        tileHeight = height;
        transform.position = new Vector3(length, width, height);
    }
    /// <summary>
    /// Sets the origin tile of this grid map.
    /// </summary>
    private void setOrigin(Tile origin)
    {
        this.origin = origin;
    }
    /// <summary>
    /// Returns the origin tile of this map.
    /// </summary>
    private Tile getOrigin()
    {
        return origin;
    }
    /// <summary>
    /// Sets the grid end of this map.
    /// </summary>
    private void setGridEnd(Tile end)
    {
        gridEnd = end;
    }
    /// <summary>
    /// Returns the grid end of this map.
    /// </summary>
    private Tile getGridEnd()
    {
        return gridEnd;
    }
}
