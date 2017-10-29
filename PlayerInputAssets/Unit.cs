using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitStatus))]
public class Unit : MonoBehaviour {

    private UnitStatus myStatus;

    private void Start()
    {
        myStatus = GetComponent<UnitStatus>();
        myStatus.initializeUnitAbilities();
    }

    /// <summary>
    /// Called to retrieve the status of this unit.
    /// </summary>
    public UnitStatus getMyStatus()
    {
        return myStatus;
    }
}
