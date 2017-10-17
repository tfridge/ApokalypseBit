using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	RaycastHit HitInfo;
	RaycastHit hit;
	public Transform target;
	void Update () {
		if (Physics.Linecast (transform.position, target.position, out hit))
		if (hit.collider.gameObject.tag == "enemy") {
			Debug.DrawLine (transform.position, target.position, Color.red);

			print("You can attack");

		}
	}
}