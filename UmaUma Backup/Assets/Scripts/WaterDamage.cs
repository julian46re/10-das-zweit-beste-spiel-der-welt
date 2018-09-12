using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour {

	//private float playerHeight = 2.08f;
	//public bool touchWater;


	void OnTriggerEnter (Collider touchWater) {
		if (touchWater.gameObject.name == "Water") {
			//gameObject.GetComponent<GameManager>().score -= 5;

			Debug.Log(gameObject.name + " touched " + touchWater.gameObject.name);
		}
	}

	
	// // Update is called once per frame
	// void FixedUpdate () {
	// 	if (gameObject.transform.position.y >= playerHeight) {
	// 		touchWater = true;
	// 	}

	// 	if (touchWater) {
	// 		gameObject.GetComponent<GameManager>().score -= 5;
	// 	}

	// }
}
