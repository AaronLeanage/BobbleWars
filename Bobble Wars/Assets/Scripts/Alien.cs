using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Alien : MonoBehaviour {
	public UnityEngine.Transform target; //Where the alien should go, in this case, the player. But not setting it to the player opens up other game mechanics such as alien powerups etc..
	private UnityEngine.NavMeshAgent agent; //The Alien itsself

	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		if (target != null) {
			agent.destination = target.position;
		}
	}
}
