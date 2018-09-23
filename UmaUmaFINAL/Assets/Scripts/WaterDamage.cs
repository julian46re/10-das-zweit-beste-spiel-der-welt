using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterDamage : MonoBehaviour {

	private float playerHeight = 0.83f;
	private int scOld;
	private int heOld;

	public bool touchWater;
	//public GameObject scoreTextObject;

	//Text scoreText;

	
	void Update () {

		if (gameObject.transform.position.y <= playerHeight) {
			touchWater = true;
		} else {
			touchWater = false;
		}

		//ShowHealth();
		heOld = gameObject.GetComponent<GameManager>().health;

	}

	void Start() {

		StartCoroutine(DamagePlayerCR());

	}

	IEnumerator DamagePlayerCR () {

    	while(true) { 
        	
        	if (touchWater) {
        		//gameObject.GetComponent<GameManager>().score -= 5;
        		gameObject.GetComponent<GameManager>().health -= 5;
        	}

        	yield return new WaitForSeconds(1);
    	}

	}

}