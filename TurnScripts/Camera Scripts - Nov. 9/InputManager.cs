using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public CameraMovement cameraMovement;

	// Use this for initialization
	void Start () {
		cameraMovement = GetComponent<CameraMovement> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!Input.GetKey (KeyCode.LeftShift) && !Input.GetKey (KeyCode.RightShift)) {
			cameraMovement.setCameraShift (CameraMovement.CameraMoveShift.none);


			if (Input.GetKey (KeyCode.RightArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.right);
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.left);
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.down);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.up);
			}

		}

		//Key inputs for rotating frontToBack & sideToSide
		else if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			cameraMovement.setCameraShift (CameraMovement.CameraMoveShift.shift);

			if (Input.GetKey (KeyCode.RightArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.right);
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.left);
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.down);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				cameraMovement.setCameraState (CameraMovement.CameraMoveState.active);
				cameraMovement.setCameraDirection (CameraMovement.CameraMoveDirection.up);
			}
				

		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			cameraMovement.setCameraState (CameraMovement.CameraMoveState.notActive);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			cameraMovement.setCameraState (CameraMovement.CameraMoveState.notActive);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			cameraMovement.setCameraState (CameraMovement.CameraMoveState.notActive);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			cameraMovement.setCameraState (CameraMovement.CameraMoveState.notActive);
		}
	}
}
