using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles setting data for units - extended for player- and AI-specific variations. 
/// Does not pay attention to the inputs themselves - just what is given to it.
/// </summary>
public class UnitInputManager : MonoBehaviour
{
    private UnitStatus currentUnitStatus;
    private Unit currentUnit;
    private Unit tempUnit;







    ///
    /// The following scripts handle the state of this manager's units and its related status.
    ///

    /// <summary>
    /// Called when setting this manager's current unit.
    /// </summary>
    public void setNewUnit(Unit newUnit)
    {
        currentUnit = newUnit;
        updateCurrentStatus();
    }

    /// <summary>
    /// Called when setting a temporary unit.
    /// </summary>
    public void setTempUnit(Unit newTempUnit)
    {
        tempUnit = currentUnit;
        currentUnit = newTempUnit;
        updateCurrentStatus();
    }

    /// <summary>
    /// Called when a temp unit is no longer needed.
    /// </summary>
    public void clearTempUnit()
    {
        currentUnit = tempUnit;
        updateCurrentStatus();
    }

    /// <summary>
    /// Called to set the status of the manager.
    /// </summary>
    private void updateCurrentStatus()
    {
        currentUnitStatus = currentUnit.getMyStatus();
    }
}