using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void checkValidTiles(int constraint, Material tempDisplay, MapTraits.TileMoveCheck direction)
    //{
    //    myDirection = direction;
    //    if (constraint < 1 || myCheck == MapTraits.TileCheck.Checked)
    //    {
    //        return;
    //    }
    //    setTempDisplay(tempDisplay);
    //    setTileCheck(MapTraits.TileCheck.Checked);
    //    setTileValid(MapTraits.ValidTile.Valid);
    //    switch (direction)
    //    {
    //        case MapTraits.TileMoveCheck.Unit:
    //            int[] newPos = newPosition(getPosition(), MapTraits.TileMoveCheck.North);
    //            Tile request = myTileMap.getTile(newPos);
    //            if (request != null)
    //            {
    //                request.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.North);
    //            }
    //            int[] newPos1 = newPosition(getPosition(), MapTraits.TileMoveCheck.East);
    //            Tile request1 = myTileMap.getTile(newPos1);
    //            if (request1 != null)
    //            {
    //                request1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.East);
    //            }
    //            int[] newPos2 = newPosition(getPosition(), MapTraits.TileMoveCheck.South);
    //            Tile request2 = myTileMap.getTile(newPos2);
    //            if (request2 != null)
    //            {
    //                request2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.South);
    //            }
    //            int[] newPos3 = newPosition(getPosition(), MapTraits.TileMoveCheck.West);
    //            Tile request3 = myTileMap.getTile(newPos3);
    //            if (request3 != null)
    //            {
    //                request3.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.West);
    //            }
    //            break;
    //        case MapTraits.TileMoveCheck.North:
    //            int[] newPosN = newPosition(getPosition(), MapTraits.TileMoveCheck.North);
    //            Tile requestN = myTileMap.getTile(newPosN);
    //            if (requestN != null)
    //            {
    //                requestN.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.North);
    //            }
    //            int[] newPosE1 = newPosition(getPosition(), MapTraits.TileMoveCheck.East);
    //            Tile requestE1 = myTileMap.getTile(newPosE1);
    //            if (requestE1 != null)
    //            {
    //                requestE1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.East);
    //            }
    //            int[] newPosW2 = newPosition(getPosition(), MapTraits.TileMoveCheck.West);
    //            Tile requestW2 = myTileMap.getTile(newPosW2);
    //            if (requestW2 != null)
    //            {
    //                requestW2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.West);
    //            }
    //            break;
    //        case MapTraits.TileMoveCheck.South:
    //            int[] newPosS = newPosition(getPosition(), MapTraits.TileMoveCheck.South);
    //            Tile requestS = myTileMap.getTile(newPosS);
    //            if (requestS != null)
    //            {
    //                requestS.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.South);
    //            }
    //            int[] newPosW1 = newPosition(getPosition(), MapTraits.TileMoveCheck.West);
    //            Tile requestW1 = myTileMap.getTile(newPosW1);
    //            if (requestW1 != null)
    //            {
    //                requestW1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.West);
    //            }
    //            int[] newPosE2 = newPosition(getPosition(), MapTraits.TileMoveCheck.East);
    //            Tile requestE2 = myTileMap.getTile(newPosE2);
    //            if (requestE2 != null)
    //            {
    //                requestE2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.East);
    //            }
    //            break;
    //        case MapTraits.TileMoveCheck.East:
    //            int[] newPosE = newPosition(getPosition(), MapTraits.TileMoveCheck.East);
    //            Tile requestE = myTileMap.getTile(newPosE);
    //            if (requestE != null)
    //            {
    //                requestE.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.East);
    //            }
    //            int[] newPosS1 = newPosition(getPosition(), MapTraits.TileMoveCheck.South);
    //            Tile requestS1 = myTileMap.getTile(newPosS1);
    //            if (requestS1 != null)
    //            {
    //                requestS1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.South);
    //            }
    //            int[] newPosN2 = newPosition(getPosition(), MapTraits.TileMoveCheck.North);
    //            Tile requestN2 = myTileMap.getTile(newPosN2);
    //            if (requestN2 != null)
    //            {
    //                requestN2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.North);
    //            }
    //            break;
    //        case MapTraits.TileMoveCheck.West:
    //            int[] newPosW = newPosition(getPosition(), MapTraits.TileMoveCheck.West);
    //            Tile requestW = myTileMap.getTile(newPosW);
    //            if (requestW != null)
    //            {
    //                requestW.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.West);
    //            }
    //            int[] newPosN1 = newPosition(getPosition(), MapTraits.TileMoveCheck.North);
    //            Tile requestN1 = myTileMap.getTile(newPosN1);
    //            if (requestN1 != null)
    //            {
    //                requestN1.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.North);
    //            }
    //            int[] newPosS2 = newPosition(getPosition(), MapTraits.TileMoveCheck.South);
    //            Tile requestS2 = myTileMap.getTile(newPosS2);
    //            if (requestS2 != null)
    //            {
    //                requestS2.checkValidTiles(constraint - 1, tempDisplay, MapTraits.TileMoveCheck.South);
    //            }
    //            break;
    //    }
    }
