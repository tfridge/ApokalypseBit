using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour {

    private Tile currentTile;
    private LinkedList<ActionConstraint> myConstraints;
    private LinkedList<UnitAbility> myAbilities;
    private LinkedList<AbilityUI> myUI;

    ///
    /// The following methods are used to generate and handle the constraint/ability lists.
    ///

    /// <summary>
    /// Called when a unit status is initialized.
    /// </summary>
	public void initializeUnitAbilities()
    {
        myConstraints = new LinkedList<ActionConstraint>();
        myAbilities = new LinkedList<UnitAbility>();
        myUI = new LinkedList<AbilityUI>();
        foreach(UnitAbility ability in GetComponents<UnitAbility>())
        {
            newAbility(ability);
            ability.initialzeMyConstraint();
            newConstraint(ability.getMyConstraint());
            newAbilityUI(ability.getMyUI());
            Debug.Log(ability);
        }
    }

    /// <summary>
    /// Called when a unit has a new status.
    /// </summary>
    public void newAbility(UnitAbility newAbility)
    {
        myAbilities.AddFirst(newAbility);
    }

    /// <summary>
    /// Called when an ability is permanently removed from a unit's status.
    /// </summary>
    public void removeAbility(UnitAbility oldAbility)
    {
        foreach (UnitAbility ability in myAbilities)
        {
            if (ability.Equals(oldAbility))
            {
                myAbilities.Remove(ability);
            }
        }
    }

    /// <summary>
    /// Called when a unit has a new status.
    /// </summary>
    public void newConstraint(ActionConstraint newConstraint)
    {
        myConstraints.AddFirst(newConstraint);
    }

    /// <summary>
    /// Called when an ability is permanently removed from a unit's status.
    /// </summary>
    public void removeConstraint(ActionConstraint newConstraint)
    {
        foreach(ActionConstraint act in myConstraints)
        {
            if (act.Equals(newConstraint))
            {
                myConstraints.Remove(act);
            }
        }
    }

    /// <summary>
    /// Called when a unit ability's constraints are needed.
    /// </summary>
    public ActionConstraint getConstraint(UnitAbility abilityCheck)
    {
        ActionConstraint newConstraint = abilityCheck.getMyConstraint();
        foreach (ActionConstraint act in myConstraints)
        {
            if (act.Equals(newConstraint))
            {
                return act;
            }
        }
        return null;
    }

    public void newAbilityUI(AbilityUI newUI)
    {
        myUI.AddFirst(newUI);
    }

    public LinkedList<ActionConstraint> getConstraints()
    {
        return myConstraints;
    }

}
