using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject followTarget;
	public float moveSpeed;

	void Start () {
	
	}

	void Update () {
		if (followTarget != null) {//Checks to see if a target is selectd, if none, camera does not follow 
			transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, Time.deltaTime * moveSpeed);
			//The above line gets the camera and the target postition then calculates the difference and moves based on it
		}
	}
}
