using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fackel : MonoBehaviour {
	
	public Transform Player;
	
	void OnTriggerEnter(Collider touch) {				
		this.transform.SetParent(Player);
	}

}


