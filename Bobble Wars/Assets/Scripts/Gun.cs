using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform launchPosition;

	void Start () {
	
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {//Check if mouse left button is down
			if (!IsInvoking("fireBullet")) {//Check if fireBullet is already being invoked
				InvokeRepeating("fireBullet", 0f, 0.15f);//Invoke it once every 0.1 seconds
			}
		}

		if (Input.GetMouseButtonUp(0)) {//If mouse button is up
			CancelInvoke("fireBullet");//Cancel the invokation of fireBullet
		}
	}

	void fireBullet() {
		// Create new bullet
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;
		// Set the position of the bullet to the barrel postition
		bullet.transform.position = launchPosition.position;
		// Move the bullet in the direction the player is facing (parent is player)
		bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;
	}
}
