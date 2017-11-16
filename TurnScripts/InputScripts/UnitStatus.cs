using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
[RequireComponent(typeof(UnitAbility))]
public class UnitStatus : MonoBehaviour {

    private Tile currentTile;
    private UnitAbility[] myAbilities;
    private ActionConstraint[] myConstraints;
    private ActionConstraint overrideConstraint;
    private UnitHealth myHealth;

    ///
    /// The following methods are used to generate and handle the constraint/ability lists.
    ///

    /// <summary>
    /// Called when a unit status is initialized.
    /// </summary>
	public void initializeUnitAbilities()
    {
        myHealth = GetComponent<UnitHealth>();
        UnitAbility[] newAbilities = GetComponents<UnitAbility>();
        myAbilities = new UnitAbility[newAbilities.GetLength(0)];
        foreach (UnitAbility ability in newAbilities)
        {
            myAbilities[ability.getMyAbilityIndex()] = ability;
            Debug.Log(ability.getMyAbilityIndex());
        }
    }

    /// <summary>
    /// Called to get a unit's unit abilities.
    /// </summary>
    public UnitAbility[] getMyAbilities()
    {
        return myAbilities;
    }

    /// <summary>
    /// Called to retrieve the health of this unit.
    /// </summary>
    public int getMyHealth()
    {
        return myHealth.getMyHealth();
    }

    /// <summary>
    /// Called to damage a unit.
    /// </summary>
    public void damageUnit(int damage)
    {
        myHealth.damageUnit(damage);
    }

    /// <summary>
    /// Called to heal a unit.
    /// </summary>
    public void healUnit(int heal)
    {
        myHealth.healUnit(heal);
    }

    /// <summary>
    /// Called to override a unit's status.
    /// </summary>
    public void setOverrideConstraint(ActionConstraint overrideC)
    {
        overrideConstraint = overrideC;
    }

    /// <summary>
    /// Called to clear a unit's status override.
    /// </summary>
    public void clearOverrideConstraint()
    {
        overrideConstraint = null;
    }
}
