using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour {

    [SerializeField]
    private Transform[] playerSpawnPoints;
    [SerializeField]
    private Transform[] enemySpawnPoints;
    [SerializeField]
    private WinCondition myCondition;

    public Transform[] getPlayerSpawn()
    {
        return playerSpawnPoints;
    }

    public Transform[] getEnemySpawn()
    {
        return enemySpawnPoints;
    }





    private enum WinCondition { KillAll, Escape }
}
