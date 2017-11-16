using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapGenerator))]
public class TileMap : MonoBehaviour {

    private Tile[,,] myMap;
    private MapGenerator myGenerator;
    [SerializeField]
    private TurnManager myTurnManager;

	// Use this for initialization
	void Start () {
        myGenerator = GetComponent<MapGenerator>();
        myGenerator.InitializeMapGenerator(this);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void initializeMap(Vector3 result)
    {
        myMap = new Tile[(int)result.x, (int)result.y, (int)result.z];
    }

    public void addTile(Tile newTile)
    {
        int[] position = newTile.getPosition();
        myMap[position[0], position[1], position[2]] = newTile;
    }

    public Tile getTile(int[] positionRequest)
    {
        if(myMap[positionRequest[0],positionRequest[1],positionRequest[2]] != null)
        {
            return myMap[positionRequest[0], positionRequest[1], positionRequest[2]].getThisTile();
        }
        else
        {
            return null;
        }
    }

    public void printMyStuff()
    {
        Debug.Log(myMap.GetLength(0).ToString()+" "+ myMap.GetLength(1).ToString()+" "+ myMap.GetLength(2).ToString());
        Debug.Log(myMap.GetLength(0) * myMap.GetLength(1) * myMap.GetLength(2));
        for (int i = 0; i < myMap.GetLength(0); i++)
        {
            for (int j = 0; j < myMap.GetLength(1); j++)
            {
                for (int k = 0; k < myMap.GetLength(2); k++)
                {
                    if (myMap[i, j, k] != null)
                    {
                        Debug.Log(myMap[i, j, k].getPositionVector());
                    }
                }
            }
        }
    }


    public void updateTiles(UnitTraits.UnitSelectionStatus newStatus)
    {
        for (int i = 0; i < myMap.GetLength(0); i++)
        {
            for (int j = 0; j < myMap.GetLength(1); j++)
            {
                for (int k = 0; k < myMap.GetLength(2); k++)
                {
                    if (myMap[i, j, k] != null)
                    {
                        myMap[i, j, k].updateActionSelection(newStatus);
                    }
                }
            }
        }
    }

    public void setUnitTile(Unit unit, int length, int width, int height)
    {
        myMap[length, width, height].getThisTile().setUnit(unit);
    }
}
