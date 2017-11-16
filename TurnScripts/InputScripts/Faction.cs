using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Faction : ScriptableObject {

    [SerializeField]
    private Unit[] myUnits;

    public Unit[] getUnits()
    {
        return myUnits;
    }

    private void checkUnitStatus()
    {

    }


}
