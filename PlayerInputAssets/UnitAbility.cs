using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAbility : MonoBehaviour {
    [SerializeField]
    [Range(0,10)]
    private int abilityIndex;
    [SerializeField]
    private string myName;
    [SerializeField]
    private int tileConstraint;
    [SerializeField]
    private int turnConstraint;
    [SerializeField]
    private AbilityTraits.LoSType losType;
    [SerializeField]
    private AbilityTraits.AreaOfEffect aoeType;
    [SerializeField]
    private AbilityUI myUI;
    [SerializeField]
    private AbilityVisual myVisuals;
    [SerializeField]
    private string myDescription;

    /// <summary>
    /// Created at runtime, can be adjusted as needed.
    /// </summary>
    private ActionConstraint myConstraint;

    // Use this for initialization
    void Start ()
    {
        
	}

    /// <summary>
    /// Called to generate the constraints of this ability.
    /// </summary>
    public void initialzeMyConstraint()
    {
        myConstraint = new ActionConstraint(myName, tileConstraint, turnConstraint, losType, aoeType);
    }
	
    public int getMyAbilityIndex()
    {
        return abilityIndex;
    }
	
    /// <summary>
    /// Called after this ability is initialized.
    /// </summary>
    public ActionConstraint getMyConstraint()
    {
        return myConstraint;
    }

    /// <summary>
    /// Called to retrieve this ability's UI components.
    /// </summary>
    public AbilityUI getMyUI()
    {
        return myUI;
    }

    /// <summary>
    /// Called to retrieve this ability's visual components.
    /// </summary>
    public AbilityVisual getMyVisuals()
    {
        return myVisuals;
    }
}
