using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNegativeCoconut : MonoBehaviour {
    int value = 10;
    
    void OnTriggerEnter() {
        GameManager.instance.CollectNegativeCoconut(value, gameObject);
        
        //AudioSource source = GetComponent<AudioSource>();
        //source.Play();
    }
}
