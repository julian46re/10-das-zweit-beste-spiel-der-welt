using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour {

	public float lookRadius = 20f;

	Transform target;
	NavMeshAgent agent;


	void Start () {
		
		agent = gameObject.GetComponent<NavMeshAgent>();
		target = PlayerManager.instance.player.transform;

	}
	
	void Update () {

		float distance = Vector3.Distance(target.position, transform.position);

		//Gibt Laufrichtung zu Player vor
		if (distance <= lookRadius) {
			agent.SetDestination(target.position);
		}

	}

	//Funktion zeichnet WireSphere
	void OnDrawGizmosSelected()  {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius); 

	}

}
 