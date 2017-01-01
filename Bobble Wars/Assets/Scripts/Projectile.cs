using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	//OnBecameInvisible is called when an object is no longer visible by the camera
	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		Destroy(gameObject);
	}
}
