using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cooper Redfern
//Evan: testFire script needs to instantiated in front of the cube and rotate the cube itself in the 
//direction you are firing in

public class Fireball : MonoBehaviour {
    public Rigidbody rb;
    public bool fired = false;
    private testFire script;
    public float forceMult;
    public GameObject fireball;
    private bool hasFired = false;
    private UnitStatus Kyle;


 //   public float fireForce = 20f;
  

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
    }



    // Update is called once per frame
    void Update () {
		if(hasFired == false)
        {
            Fire(Kyle.getMyPosition(), script.getTarget());
            hasFired = true;
        }
	}

    public void Fire(Vector3 source,Vector3 target)
    {
        Vector3 direction = source - target;
        direction.Normalize();
        rb.AddForce(direction*forceMult);
    }

    //Sets the target destination of the fireball
    public void setTarget(Transform Target)
    {
        
    }

    public void checkPosition()//transform from kyle)
    {
        // if the target and fireballs position are in the same position
        // then the target has been hit()
    }

    public void hit()
    {
        //destroy the object
    }

    public void setTestFire(testFire script)
    {
        this.script = script;

    }


}
