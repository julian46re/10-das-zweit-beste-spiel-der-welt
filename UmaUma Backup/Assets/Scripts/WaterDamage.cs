using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterDamage : MonoBehaviour {

	private float playerHeight = 0.83f;
	private int scOld;

	public bool touchWater;
	//public GameObject scoreTextObject;

	//Text scoreText;

	
	void Update () {

		if (gameObject.transform.position.y <= playerHeight) {
			touchWater = true;
		} else {
			touchWater = false;
		}

		ShowScore();
		scOld = gameObject.GetComponent<GameManager>().score;

	}

	void Start() {

		StartCoroutine(DamagePlayerCR());

	}

	IEnumerator DamagePlayerCR () {

    	while(true) { 
        	
        	if (touchWater) {
        		gameObject.GetComponent<GameManager>().score -= 5;
        	}

        	yield return new WaitForSeconds(1);
    	}

	}

	public void ShowScore() {

        if (scOld != gameObject.GetComponent<GameManager>().score) {
            GameObject.Find("Score Text").GetComponent<Text>().text = "Score: " + gameObject.GetComponent<GameManager>().score.ToString();
        }

    }

}