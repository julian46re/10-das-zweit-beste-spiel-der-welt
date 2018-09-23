using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalReturn : MonoBehaviour {

	void OnTriggerEnter(Collider touch) {
	
	// if (touch.gameObject.tag("player"))
      SceneManager.LoadScene("CollectScene");
}

	}
		
	 
	


