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

	//Funktion rotiert Enemy in Richtung des Players
	void FaceTarget () {

		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

	}

	//Funktion zeichnet WireSphere
	void OnDrawGizmosSelected()  {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius); 

	}

}
 