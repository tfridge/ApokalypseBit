using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Camera cam;
	public GameObject root;
	public GameObject frontToBack;
	public GameObject sideToSide;
	public float speed;
	public float rotateSpeed;
	public CameraMoveShift shiftState;
	public CameraMoveDirection dirState;
	public CameraMoveState myState;


	public void setCameraShift(CameraMoveShift shift){
		shiftState = shift;
	}

	public void setCameraDirection(CameraMoveDirection direction){
		dirState = direction;
	}

	public void setCameraState(CameraMoveState state){
		myState = state;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (myState) {
		    case CameraMoveState.active:
			    switch (shiftState) {
			        case CameraMoveShift.none:
				        switch (dirState) {
				            case CameraMoveDirection.up:
					            transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
					            break;
				            case CameraMoveDirection.down:
					            transform.Translate (new Vector3 (0, 0, -speed * Time.deltaTime));
					            break;
				            case CameraMoveDirection.left:
					            transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
					            break;
				            case CameraMoveDirection.right:
					            transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
					            break;
				    }
				    break;
			    case CameraMoveShift.shift:
				    switch (dirState) {
				        case CameraMoveDirection.up:
					        frontToBack.transform.Rotate (Vector3.right * rotateSpeed * Time.deltaTime);
                            break;
				        case CameraMoveDirection.down:
					        frontToBack.transform.Rotate (-Vector3.right * rotateSpeed * Time.deltaTime);
                            break;
				        case CameraMoveDirection.left:
					        //sideToSide.transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
                            root.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                            break;
				        case CameraMoveDirection.right:
					        //sideToSide.transform.Rotate (-Vector3.up * rotateSpeed * Time.deltaTime);
                            root.transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
                            break;
				    }
				    break;
			    }
			    break;
		}

	}
	public enum CameraMoveShift{none, shift}
	public enum CameraMoveDirection{up, down, left, right}
	public enum CameraMoveState{notActive, active}
}
