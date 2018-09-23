using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 

public class wachsendeUmaUmas : MonoBehaviour {

public int score;  
public int scold = 0;  
private GameObject head;
private float timestamp;


	// Use this for initialization
	void Start () {
		head = GameObject.Find("Head"); 

		InvokeRepeating("GrowHead", 1f, 0.1f); 

	}
	
	
	 	public void GrowHead() {
	 		score = GameObject.Find("hula").GetComponent<GameManager>().score;

	 		if (score > scold) {

			//Debug.Log("bevor angleichung: " + scold);
				head.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
			 
				scold = score;
			}

	 	}
	
	 	public void OnTriggerEnter(Collider TouchKaktus) {

	 		if(TouchKaktus.gameObject.tag == "cactus") {

			head.transform.localScale += new Vector3(-0.03f, -0.03f, -0.03f);
			 
	 		}



	 	}

}
