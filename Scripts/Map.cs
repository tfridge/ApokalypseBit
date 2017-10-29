using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basic grid map of an area - used with other maps inside the map generator to put levels together.
/// </summary>
public class Map : MonoBehaviour
{

    public int tileWidth;
    public int tileLength;
    public int tileHeight;
    public int length;
    public int width;
    public int heightOrigin;
    private Tile[,] tileMap;
    private Tile origin;
    private Tile gridEnd;
    public Material display;
    public GameObject rendered;
    public Quaternion myRotation;
    private bool initialized;
    public BumpMap bumpMap;
    private MapGenerator myParent;
    private TileMap myTileMap;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Called to create the tile map.
    /// </summary>
    public void InitializeMap(MapTraits.GridRotation rotation, int tileWidth, int tileLength, int tileHeight, MapGenerator parent, TileMap newMap)
    {
        if (!initialized)
        {
            myParent = parent;
            myTileMap = newMap;
            setRotation(rotation);
            setGridPosition(tileWidth, tileLength, tileHeight);
            tileMap = new Tile[width, length];
            int count = -1;
            if (bumpMap != null)
            {
                bumpMap.initializeBumpMap();
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    count++;
                    if (bumpMap != null)
                    {
                        if (bumpMap.checkValidMap(width, length))
                        {
                            if (bumpMap.checkBump(i, j) != MapTraits.TileType.None)
                            {
                                tileMap[i, j] = Instantiate(rendered, new Vector3(i + tileWidth, tileHeight, j + tileLength), Quaternion.identity).AddComponent<Tile>();
                                tileMap[i, j].name = count.ToString();
                                tileMap[i, j].setPosition(i + tileWidth, j + tileLength, tileHeight, this);
                                tileMap[i, j].setDisplay(display, bumpMap.checkBump(i, j));
                                newMap.addTile(tileMap[i, j]);
                                tileMap[i, j].transform.parent = transform;
                                setGridEnd(tileMap[i, j]);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            tileMap[i, j] = Instantiate(rendered, new Vector3(i + tileWidth, tileHeight, j + tileLength), Quaternion.identity).AddComponent<Tile>();
                            tileMap[i, j].name = count.ToString();
                            tileMap[i, j].setPosition(i + tileWidth, j + tileLength, tileHeight, this);
                            tileMap[i, j].setDisplay(display);
                            newMap.addTile(tileMap[i, j]);
                            tileMap[i, j].transform.parent = transform;
                            setGridEnd(tileMap[i, j]);
                        }
                    }
                    else
                    {
                        tileMap[i, j] = Instantiate(rendered, new Vector3(i + tileWidth, tileHeight, j + tileLength), Quaternion.identity).AddComponent<Tile>();
                        tileMap[i, j].name = count.ToString();
                        tileMap[i, j].setPosition(i + tileWidth, j + tileLength, tileHeight, this);
                        tileMap[i, j].setDisplay(display);
                        newMap.addTile(tileMap[i, j]);
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
    /// Called to set the parent unit of this map unit.
    /// </summary>
    public MapGenerator getParent()
    {
        return myParent;
    }

    /// <summary>
    /// Called to adjust the total rotation of a map grid.
    /// </summary>
    private void setRotation(MapTraits.GridRotation nRotation)
    {
        //switch (nRotation)
        //{
        //    // Put the proper quaternions here!
        //}
    }
    /// <summary>
    /// Sets the position of the grid map in world space.
    /// </summary>
    private void setGridPosition(int width, int length, int height)
    {
        tileWidth = width;
        tileLength = length;
        tileHeight = height;
        transform.position = new Vector3(width, length, height);
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

    public TileMap getMyTileMap()
    {
        return myTileMap;
    }

    public int getLength() { return length; }
    public int getWidth() { return width; }
    public int getHeight() { return tileHeight; }
}
