using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFire : MonoBehaviour {
    private Vector3 startPos = new Vector3(-14f,0f,13f);
    public Vector3 target = new Vector3(-4f, 0f, 23f);
    public GameObject fireball;
    private UnitStatus Kyle;

	// Use this for initialization
	void Start () {
     

	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fireball = Instantiate(fireball);
            fireball.GetComponent<Fireball>().setTestFire(this);
            fireball.transform.position = Kyle.getMyPosition();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Vector3 getStart()
    {
        return startPos;
    }

    public Vector3 getTarget()
    {
        return target;
    }

}
