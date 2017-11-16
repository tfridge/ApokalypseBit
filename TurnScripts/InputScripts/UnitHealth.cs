using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour {
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int startHealth;
    [SerializeField]
    private int myHealth;
    [SerializeField]
    [Range(0,100)]
    private float damageMitigate;

	// Use this for initialization
	void Start () {
        UnitHealth[] falseHealth = GetComponents<UnitHealth>();
        if (falseHealth.GetLength(0) == 2) {  Destroy(falseHealth[0]);  }

        myHealth = startHealth;
	}
	
    /// <summary>
    /// Called to Kill
    /// </summary>
	public void damageUnit(int damage)
    {
        myHealth = myHealth - damage * (int)(damageMitigate / 100);
    }

    /// <summary>
    /// Called to heal the unit by a given integer. Sets health to max health if the heal is too large.
    /// </summary>
    /// <param name="heal"></param>
    public void healUnit(int heal)
    {
        myHealth = myHealth + heal;
        if(myHealth > maxHealth)
        {
            myHealth = maxHealth;
        }
    }

    /// <summary>
    /// Called to set the max health of a unit.
    /// </summary>
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    /// <summary>
    /// Called to set the start health of a unit.
    /// </summary>
    public void setStartHealth(int startHealth)
    {
        this.startHealth = startHealth;
    }

    /// <summary>
    /// Called to get the integer health of a unit.
    /// </summary>
    public int getMyHealth()
    {
        return myHealth;
    }

    /// <summary>
    /// Called to adjust the damage mitigation of a unit.
    /// </summary>
    public void setMyMitigate(float mitigate)
    {
        if (mitigate > 99)
        {
            mitigate = 99;
        }
        if(mitigate < 0)
        {
            mitigate = 0;
        }
        damageMitigate = mitigate;
    }
}
