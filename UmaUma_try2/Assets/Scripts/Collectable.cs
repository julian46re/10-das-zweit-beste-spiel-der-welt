using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    int value = 10;
    
    void OnTriggerEnter() {
        GameManager.instance.Collect(value, gameObject);
    	
  //      AudioSource source = GetComponent<AudioSource>();
		//source.Play();
	}
}
