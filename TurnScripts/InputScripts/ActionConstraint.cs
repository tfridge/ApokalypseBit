using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the state of a given Unit Ability. Created at runtime and adjusted from UnitStatus.
/// </summary>
public class ActionConstraint {

    private string name;
    private int movement;
    private int los;
    private AbilityTraits.LoSType losType;
    private AbilityTraits.AreaOfEffect effects;
    private bool active;

	public ActionConstraint(string name, int movement, int los, AbilityTraits.LoSType losType, AbilityTraits.AreaOfEffect effects)
    {
        this.name = name;
        this.movement = movement;
        this.los = los;
        this.losType = losType;
        this.effects = effects;
        active = false;
    }

    public string getMyName() { return name; }

    public void setMyName(string name) { this.name = name; }

    /// <summary>
    /// Returns the movement constraint of this given unit ability.
    /// </summary>
    public int getMyMovement() { return movement; }

    /// <summary>
    /// Returns the los range constraint of this given unit ability.
    /// </summary>
    public int getMyLoS() { return los; }

    /// <summary>
    /// Returns the LOS type of this given unit ability.
    /// </summary>
    public AbilityTraits.LoSType getMyLosType() { return losType; }

    /// <summary>
    /// Returns the AOE type of this given unit ability.
    /// </summary>
    public AbilityTraits.AreaOfEffect getMyAoEType() { return effects; }

    /// <summary>
    /// Returns the active state of this given unit ability.
    /// </summary>
    public bool getMyActiveStatus() { return active; }


    /// <summary>
    /// Sets the constraint of this given unit ability.
    /// </summary>
    public void setMyMovement(int movement) { this.movement = movement; }

    /// <summary>
    /// constraint of this given unit ability.
    /// </summary>
    public void setMyLoS(int los) { this.los = los; }

    /// <summary>
    /// Sets the of this given unit ability.
    /// </summary>
    public void setMyLosType(AbilityTraits.LoSType losType) { this.losType = losType; }

    /// <summary>
    /// Sets the AOE  of this given unit ability.
    /// </summary>
    public void setMyAoEType(AbilityTraits.AreaOfEffect effects)  { this.effects = effects; }

    /// <summary>
    /// Sets the active state of this given unit ability.
    /// </summary>
    public void setMyActiveStatus(bool active) { this.active = active; }
}
