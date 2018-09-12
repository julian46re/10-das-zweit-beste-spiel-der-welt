using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour {

	private float playerHeight = 0.83f;

	public bool touchWater;

	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.y <= playerHeight) {
			touchWater = true;
		} else {
			touchWater = false;
		}

	}

	void Start() {

		StartCoroutine(DamagePlayerCR());

	}

	IEnumerator DamagePlayerCR () {

    	while(true) { 
        	
        	if (touchWater) {
        		gameObject.GetComponent<GameManager>().score -= 5;
        	}


        	yield return new WaitForSeconds(2);
    	}

	}

}