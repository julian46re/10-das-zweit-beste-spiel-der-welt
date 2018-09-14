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

		ShowScore();
		scOld = gameObject.GetComponent<GameManager>().score;

		ShowHealth();
		heOld = gameObject.GetComponent<GameManager>().health;

		if (heOld <= 0) {

			Restart();

		}

	}

	void Start() {

		StartCoroutine(DamagePlayerCR());

	}

	IEnumerator DamagePlayerCR () {

    	while(true) { 
        	
        	if (touchWater) {
        		gameObject.GetComponent<GameManager>().score -= 5;
        		gameObject.GetComponent<GameManager>().health -= 5;
        	}

        	yield return new WaitForSeconds(1);
    	}

	}

	public void ShowScore() {

        if (scOld != gameObject.GetComponent<GameManager>().score) {
            GameObject.Find("Score Text").GetComponent<Text>().text = "Score: " + gameObject.GetComponent<GameManager>().score.ToString();
        }

    }

    public void ShowHealth() {

    	if (heOld != gameObject.GetComponent<GameManager>().health) {

    		GameObject.Find("Health Text").GetComponent<Text>().text = "Health: " + gameObject.GetComponent<GameManager>().health.ToString();

    	}

    }

    void Restart () {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}