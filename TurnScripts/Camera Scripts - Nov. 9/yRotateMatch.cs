using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yRotateMatch : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = target.transform.localRotation;
	}
}
