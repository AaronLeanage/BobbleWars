using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 50.0f;
	private CharacterController characterController;
	public Rigidbody head;

	//Detect where the mouse is pointint in a 3D space using raycasting
	public LayerMask layerMask;
	private Vector3 currentLookTarget = Vector3.zero;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//Create new Vector3 and get movement in X,Z axis. Then set Y axis movement to 0 as no up/down movement is required.
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//SimpleMove allows movement in any direction but does not allow movement through objects.
		characterController.SimpleMove(moveDirection * moveSpeed);
	}

	//Fixed update is called at regular intervals so it can be used to handle physics better than frame-by-frame (update)
	void FixedUpdate() {
		//Create a Vector3 and get the movement of the character (as seen in CameraMovement.cs)
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (moveDirection == Vector3.zero) {//If no movement, 
			// TODO
		} 
		else {//Else, there is movement so make the head 'bobble' with the right amount of force
			head.AddForce(transform.right * 125, ForceMode.Acceleration);
		}

		//Creates an empty RaycastHit and if it hits something it will be populated with an object
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Debugging line to test raycasting detection
		//Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

		//Physics.Raycast actually casts it and 1000 is 1000m length and triggers are told not to activate on it
		if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore)) {
			if (hit.point != currentLookTarget) {//Current Look Target (Where the character is looking) is updated to mouse pointer location
				currentLookTarget = hit.point;
			}
		}

		// 1 - Get the target postition and use the character's head's Y as otherwise it would look at the floor
		Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
		// 2 - Determine the rotation of the target postition
		Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
		// 3 - Actually make the movements using Lerp, Lerp smoothly moves items over a period of time
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
	}
}
