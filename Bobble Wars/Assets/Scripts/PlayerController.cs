using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Get current position from character (Vector3 is x,y,z)
		Vector3 pos = transform.position;

		//Movement (Only x,z required as y is up and down) (Follows formula s=d/t)
		pos.x += moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime; //"Time.deltaTime" refers to the amount of time since update is last called (every frame unless lag)
		pos.z += moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime; //"Horizontal","Vertical" recieved from Unity and return -1 or 1 depending on movement direction

		//Set new position to characte
		transform.position = pos;
	}
}
