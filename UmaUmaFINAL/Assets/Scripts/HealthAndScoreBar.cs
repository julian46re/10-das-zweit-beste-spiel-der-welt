using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthAndScoreBar : MonoBehaviour {


	public Image currentHealthbar;
	public Image currentScorebar;
	
	public GameObject Health;
	public GameObject Score;

	public int health; 
	public int score; 

	public float healthMax = 100f;
	public float scoreMax = 200f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		health = GameObject.Find("hula").GetComponent<GameManager>().health;
		 score = GameObject.Find("hula").GetComponent<GameManager>().score; 

		// if (score <= 0) {
		// 	score = 0;
		// }


//		Debug.Log(health + " = health / " + score + " = score" );

		UpdateHealthBar();
		UpdateScoreBar();

	}

	private void UpdateHealthBar(){
		float ratio = health/healthMax;
		if (health >= 0) { 
			currentHealthbar.rectTransform.localScale = new Vector3(ratio,1,1);
		} 
	}

	private void UpdateScoreBar(){
		float ratio = score/scoreMax; 
			if (score < scoreMax) {
				currentScorebar.rectTransform.localScale = new Vector3(ratio,1,1);
			}
			if (score >= scoreMax) {
				currentScorebar.rectTransform.localScale = new Vector3(1,1,1);
			}
	}
}

